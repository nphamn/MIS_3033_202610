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
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace JSON_From_A_File
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<CarOwner> data;
        public MainWindow()
        {
            InitializeComponent();
            string json = File.ReadAllText("Mock_Data_Car_Owners.json");

            data = JsonConvert.DeserializeObject<List<CarOwner>>(json);
            var distinctColors = data.Select(co => co.Color).Distinct().OrderBy(color => color).ToList();
           
            colorComboBox.ItemsSource = distinctColors;
        }

        private void colorComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Get the selected color from the ComboBox
            string selectedColor = colorComboBox.SelectedItem as string;

            // Filter the car owners based on the selected color
            var filteredCarOwners = data.Where(car => car.Color == selectedColor).ToList();

            // Display filtered car owners in the ListBox
            carListBox.Items.Clear(); // Clear previous items
            foreach (var owner in filteredCarOwners)
            {
                carListBox.Items.Add(owner.ToString());
            }
        }
    }
}