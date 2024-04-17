using Music.MusicDomain;
using MusicCreator.Services;

namespace MusicCreator;

public partial class MainPageApp : ContentPage
{
    Service service = Service.GetService();
   
    public MainPageApp()
	{
		InitializeComponent();
        List<Track> auxList = service.GetCreationTracks();
        List<string> items = (from t in auxList
                             select t.getTitle()).ToList();

        tracksListView.ItemsSource = items;
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if (sender is Button { CommandParameter: string item } && tracksListView.ItemsSource is List<string> items)
        {
            items.Remove(item);
            
            tracksListView.ItemsSource = null;
            tracksListView.ItemsSource = items;
        }
    }

    private async void GoFromMainToLogInPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("LogIn");
    }

    private void GoToListenTrack(object sender, EventArgs e)
    {

    }
    private async void GoToSearchTracks(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Search");
    }
    
    private async void GoFromMainToSavePage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Save");
    }

    private void PlayCreation(object sender, EventArgs e)
    {
        service.PlayCreation();
    }

}