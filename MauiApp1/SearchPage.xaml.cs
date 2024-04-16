using MauiApp1.Repository;
using Music.MusicDomain;
using MusicCreator;

namespace MauiApp1;

public partial class SearchPage : ContentPage
{

    TrackRepository trackRepository = new TrackRepository();
    List<Track> tracksData;


    private List<string> list_of_tracks = new List<string>();

    public SearchPage()
    {
        tracksData = trackRepository.getAll();
        InitializeComponent();
        SearchBar.SearchButtonPressed += OnSearchButtonPressed;
    }

    // Method to create dynamic buttons for sentences containing the search query
    private void CreateButtons(string searchQuery)
    {
        ButtonsLayout.Children.Clear(); // Clear existing buttons

        foreach (Track track in tracksData)
        {
            string title = track.getTitle();
            if (title.ToLower().Contains(searchQuery.ToLower()))
            {
                var button = new Button { Text = title };
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