using Music.MusicDomain;
using MusicCreator.Services;

namespace MusicCreator;

public partial class MainPageApp : ContentPage
{
    Service service = Service.GetService();
    bool isButtonClicked;

    public MainPageApp()
	{
		InitializeComponent();
        List<Track> auxList = service.GetCreationTracks();
        List<string> items = (from t in auxList
                             select t.getTitle()).ToList();

        tracksListView.ItemsSource = items;
        isButtonClicked = false;
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
        Button button = (Button)sender;
        string category = button.Text.ToLower();
        service.category = category;
        await Shell.Current.GoToAsync("Search");
    }
    
    private async void GoFromMainToSavePage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Save");
    }

    
    private void PlayCreation(object sender, EventArgs e)
    {
        if (!isButtonClicked && service.GetCreationTracks().Count() != 0)
        {
            playButton.BackgroundColor = Color.FromRgb(255, 0, 0);
            isButtonClicked = true;
        }
        else
        {
            playButton.BackgroundColor = Color.FromRgb(57, 208, 71);
            isButtonClicked = false;
        }

        service.PlayCreation();
    }

}