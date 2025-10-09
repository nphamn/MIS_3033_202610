using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace JSON_Game_of_Thrones_Quotes
{
    public partial class MainWindow : Window
    {
        // Declare HttpClient and a list to store quotes
        private HttpClient client;
        private List<Quote> quotes;

        public MainWindow()
        {
            InitializeComponent();
            client = new HttpClient(); // Initialize HttpClient
            quotes = new List<Quote>(); // Initialize quotes list
        }



        // Fetch a random quote from the Game of Thrones API
        private async void GetRandomQuoteButton_Click(object sender, RoutedEventArgs e)
{
    try
    {
        // Call the API to get a random quote
        var response = await client.GetStringAsync("https://api.gameofthronesquotes.xyz/v1/random");

        // Deserialize the quote into the Quote object
        var quote = JsonConvert.DeserializeObject<Quote>(response);

        // Check if quote is not null before using it
        if (quote != null && quote.Character != null)
        {
            // Display the quote and character in TextBlock
            tbQuote.Text = $"\"{quote.Sentence}\" - {quote.Character.Name}";

            // Store the quote in the quotes list
            quotes.Add(quote);
        }
        else
        {
            MessageBox.Show("The API returned an empty quote.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error fetching quote: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}



        // Save quotes to a file (quotes.json)
        private void SaveQuotesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Serialize the quotes list into a JSON string
                string json = JsonConvert.SerializeObject(quotes, Formatting.Indented);

                // Write the JSON string to a file
                string filePath = "quotes.json";
                System.IO.File.WriteAllText(filePath, json);

                MessageBox.Show("Quotes saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving quotes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
