using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static JSON_Pokemon.PokeAPIService;
using JSON_Pokemon;


namespace JSON_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PokeAPIService _pokeAPIService;
       
        private List<PokemonListItem>? _pokemonList;
        private PokemonDetail? _currentPokemonDetail;
        private bool _isFrontSprite = true;
        public MainWindow()
        {
            InitializeComponent();
            _pokeAPIService = new PokeAPIService();
            LoadPokemonList();
        }
        private async void LoadPokemonList()
        {
            var pokemonList = await _pokeAPIService.GetPokemonListAsync();
            _pokemonList = pokemonList;
            PokemonListBox.ItemsSource = _pokemonList;
        }
        private async void PokemonListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PokemonListBox.SelectedItem != null)
            {
                var selectedPokemon = (PokemonListItem)PokemonListBox.SelectedItem;
                _currentPokemonDetail = await _pokeAPIService.GetPokemonDetailAsync(selectedPokemon.name);

                // Update UI with selected Pokémon details
                PokemonNameText.Text = _currentPokemonDetail.Name;
                PokemonHeightText.Text = $"Height: {_currentPokemonDetail.Height / 10.0} meters";
                PokemonWeightText.Text = $"Weight: {_currentPokemonDetail.Weight / 10.0} kg";

                // Display front sprite by default
                DisplaySprite(_currentPokemonDetail.Sprites.front_default);
            }
        }

        // Display sprite (front or back)
        private void DisplaySprite(string spriteUrl)
        {
            PokemonSpriteImage.Source = new BitmapImage(new Uri(spriteUrl));
        }

        // Toggle between front and back sprites
        private void ToggleSpriteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPokemonDetail?.Sprites != null)
            {
                string? spriteUrl = _isFrontSprite
                    ? _currentPokemonDetail.Sprites.back_default
                    : _currentPokemonDetail.Sprites.front_default;

                if (!string.IsNullOrEmpty(spriteUrl))
                {
                    DisplaySprite(spriteUrl);
                }
                else
                {
                    // Optionally, handle missing sprite (e.g., clear image or show placeholder)
                    PokemonSpriteImage.Source = null;
                }
                _isFrontSprite = !_isFrontSprite;
            }
            else
            {
                PokemonSpriteImage.Source = null;
            }
        }
    }
}