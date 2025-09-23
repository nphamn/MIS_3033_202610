using System.IO;
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

namespace WPF_Classes_Files
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string[] lines = File.ReadAllLines("Toys.csv");

            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(',');

                if (parts.Length >= 4 && double.TryParse(parts[2], out double price))
                {
                    Toy toy = new Toy(parts[0], parts[1], price, parts[3]);
                    lstToys.Items.Add(toy);
                }
            }
        }

        private void btnAddToy_Click(object sender, RoutedEventArgs e)
        {
            string manufacturer = txtManufacturer.Text.Trim();
            string name = txtName.Text.Trim();
            string image = txtImage.Text.Trim();
            string priceText = txtPrice.Text.Trim();

            if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(image) || string.IsNullOrEmpty(priceText))
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            if (!double.TryParse(priceText, out double price))
            {
                MessageBox.Show("Price must be a valid number.");
                return;
            }

            Toy toy = new Toy(manufacturer, name, price, image);
            lstToys.Items.Add(toy);

            // Clear inputs
            txtManufacturer.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtImage.Clear();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
      

        private void lstToys_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Get the selected item and cast it to a Toy object
            Toy selectedToy = (Toy)lstToys.SelectedItem;

            if (selectedToy != null)
            {
                // Show aisle in a MessageBox
                MessageBox.Show($"Aisle: {selectedToy.GetAisle()}");

                // Load the image from the toy's URL
                try
                {
                    var uri = new Uri(selectedToy.Image);
                    var img = new BitmapImage(uri);

                    // Update Image control on GUI
                    imgToy.Source = img;
                }
                catch
                {
                    MessageBox.Show("Invalid image URL.");
                }
            }
        }

    }
}