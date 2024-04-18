using MusicCreator.Repository;
using Music.MusicDomain;
using MusicCreator;
using MusicCreator.Services;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;


namespace MusicCreator;

public partial class SearchPage : ContentPage
{

    Service service;
    List<Track> tracksData;

    public SearchPage()
    {
        InitializeComponent();

        service = Service.GetService();
        //q: how do I get the parameter from the query string?
        //a: I can get the query string from the location property of the current state of the shell

        string category = service.category;
        int categoryInt;

        if (category == "drums")
        {
            categoryInt = 1;
        }
        else if(category == "music")
        {
            categoryInt = 2;
        }
        else if(category == "fx")
        {
            categoryInt = 3;
        }
        else if(category == "mic")
        {
            categoryInt = 4;
        }
        else
        {
            categoryInt = 0;
        }

        tracksData = service.GetTracksByType(categoryInt);
        TracksListView.ItemsSource = tracksData;
        

        //SearchBar.SearchButtonPressed += OnSearchButtonPressed;
    }

    public void OnPlayClicked(object sender, EventArgs e)
    {

        //TO DO
        //PLAY THE TRACK
        service.StopAll();
        int id = (int)((Button)sender).CommandParameter;
        Track track = service.GetTrackById(id);
        track.Play();

    }


    public void OnTrackTapped(object sender, ItemTappedEventArgs e)
    {
        Track track = e.Item as Track;
        service.AddTrack(track);
        service.StopAll();
       
        Shell.Current.GoToAsync("Main");
    }

    // Method to create dynamic buttons for sentences containing the search query
    /*private void CreateButtons(string searchQuery)
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
    */
    // Event handler for the search bar's search button pressed event
    private void OnSearchButtonPressed(object sender, EventArgs e)
    {
        string searchQuery = SearchBar.Text;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            //CreateButtons(searchQuery);
        }
        else
        {
            // Handle empty search query
            DisplayAlert("Empty Search", "Please enter a search query", "OK");
        }
    }
    /*
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
    */

}