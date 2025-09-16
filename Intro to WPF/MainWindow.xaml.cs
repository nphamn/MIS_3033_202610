using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Intro_to_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnGo.Background = Brushes.LightGray;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtName.Text;
            int age = int.Parse(txtAge.Text);

            lblOutput.Content = $"Welcome to our application {userName}!";
            MessageBox.Show($"Welcome to our application {userName}!");
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            btnGo.Background = Brushes.LightBlue;
        }

        private void btnGo_MouseLeave(object sender, MouseEventArgs e)
        {
            btnGo.Background = Brushes.LightGray;
        }
    }
}