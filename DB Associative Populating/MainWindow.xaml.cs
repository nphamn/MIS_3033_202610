using DB_Associative_Populating.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
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

namespace DB_Associative_Populating
{
    
    public partial class MainWindow : Window
    {
        
        SoonerCoContext db = new SoonerCoContext();
        
        private bool ShouldLoadToys=false;
        private bool ShouldLoadOwners=false;
        private bool ShouldLoadDogs=true;
        public MainWindow()
        {

            InitializeComponent();
            
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            //LoadToys(ShouldLoadToys);


            //LoadOwnners(ShouldLoadOwners);


            // LoadDogs(ShouldLoadDogs);
            DisplayDatabaseContent();
        }



        private void DisplayDatabaseContent()
        {
            lstDogs.Items.Clear();
            lstToys.Items.Clear();
            lstDogToys.Items.Clear();



            foreach (var dogs in db.Dogs.Include(x => x.Owner))
            {
                lstDogs.Items.Add(dogs);
            }

            foreach (var toy in db.Toys)
            {
                lstToys.Items.Add(toy);
            }

            foreach (var dogToy in db.DogToys.Include(x => x.Dog).Include(y => y.Toy))
            {
                lstDogToys.Items.Add(dogToy);

            }

        }



        private void lstToys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Toy selected = (Toy)lstToys.SelectedItem;

            if (selected is null)
            {
                return;
            }
            imgToy.Source = new BitmapImage(new Uri(selected.Image));

            imgToy.Visibility = Visibility.Visible;

        }

        private void lstDogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dog selected = (Dog)lstDogs.SelectedItem;

            if (selected is null)
            {
                return;
            }
            imgDog.Source = new BitmapImage(new Uri(selected.Image));
            imgDog.Visibility = Visibility.Visible;

            lblOwner.Content = $"{selected.Name} is owned by {selected.Owner.Name}";
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            Dog selectedDog = (Dog)lstDogs.SelectedItem;
            Toy selectedToy = (Toy)lstToys.SelectedItem;

            if (selectedDog is null || selectedToy is null)
            {
                return;
            }

            DogToy dt = new DogToy()
            {
                DogId = selectedDog.Id,
                ToyId = selectedToy.Id
            };

            db.DogToys.Add(dt);
            db.SaveChanges();


            DisplayDatabaseContent();
        }

       

        private void btnDeleteDogToy_Click(object sender, RoutedEventArgs e)
        {
            DogToy selectedDog = (DogToy)lstDogToys.SelectedItem;
            db.DogToys.Remove(selectedDog);
            db.SaveChanges();

            DisplayDatabaseContent();
        }

        private void btnSharedWithFriend_Click(object sender, RoutedEventArgs e)
        {
            DogToy selectedDogToy = (DogToy)lstDogToys.SelectedItem;
            Dog selectedDog = (Dog)lstDogs.SelectedItem;

            if(selectedDogToy is null || selectedDog is null)
            {
                return;
            }
            var updatedToy = db.DogToys.Find(selectedDogToy);
            updatedToy.DogId = selectedDog.Id;

            
            db.SaveChanges();

            DisplayDatabaseContent();
        }
    }
}


