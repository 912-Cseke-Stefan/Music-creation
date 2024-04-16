using MusicCreator;

namespace MauiApp1;

public partial class SearchPage : ContentPage
{
    private List<string> tracksData = new List<string>()
    {
      "Track 1 - My life",
      "Track 2 - My world",
      "Track 3 - hello darkness my old friend",
      "Track 4 - Hello (adele)",
      "Track 5 - HeLlo there",
      // Add more sentences as needed
    };

    private List<string> list_of_tracks = new List<string>();

    public SearchPage()
    {
        InitializeComponent();
        SearchBar.SearchButtonPressed += OnSearchButtonPressed;
    }

    // Method to create dynamic buttons for sentences containing the search query
    private void CreateButtons(string searchQuery)
    {
        ButtonsLayout.Children.Clear(); // Clear existing buttons

        foreach (string track in tracksData)
        {
            if (track.ToLower().Contains(searchQuery.ToLower()))
            {
                var button = new Button { Text = track };
                button.Clicked += Button_Clicked; // Add event handler for button click
                ButtonsLayout.Children.Add(button);
            }
        }
    }

    // Event handler for the search bar's search button pressed event
    private void OnSearchButtonPressed(object sender, EventArgs e)
    {
        string searchQuery = SearchBar.Text;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            CreateButtons(searchQuery);
        }
        else
        {
            // Handle empty search query
            DisplayAlert("Empty Search", "Please enter a search query", "OK");
        }
    }

    // Event handler for dynamic button click
    private void Button_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        string track = button.Text;
        //list_of_tracks.Add(track);
        // You can do additional actions here if needed
        //TO DO
        //SEND BACK TO MAIN PAGE THE LIST OF TRACK
        Shell.Current.Navigation.PushAsync(new MainPageApp(track));
        }
}