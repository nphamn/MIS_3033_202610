using System.Net.Http;
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
using Newtonsoft.Json;

namespace Rick_and_Morty_API
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadCharactersAsync();
        }

        private async void LoadCharactersAsync()
        {
            string url = "https://rickandmortyapi.com/api/character";
            HttpClient client = new HttpClient();

            while (url != null)
            {
                string json = await client.GetStringAsync(url);
                RickAndMortyAPI api = JsonConvert.DeserializeObject<RickAndMortyAPI>(json);

                foreach (Result result in api.results.OrderBy(x => x.name))
                {
                    cboCharacters.Items.Add(result);
                }

                url = api.info.next;
            }
        }

        private void cboCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Result selectedItem = (Result)cboCharacters.SelectedItem;
            txtName.Text = selectedItem.name;
            txtURL.Text = selectedItem.url;
            imgPicture.Source = new BitmapImage(new Uri(selectedItem.image));
        }
    }
}