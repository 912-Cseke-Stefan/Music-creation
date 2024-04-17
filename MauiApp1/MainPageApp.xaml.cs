namespace MusicCreator;

public partial class MainPageApp : ContentPage
{
    List<string> items = ["Track 1"];
    public MainPageApp()
	{
		InitializeComponent();
        //List<string> items = [];
        items = new List<string>();

        tracksListView.ItemsSource = items;
    }

    public MainPageApp(string track)
    {
        InitializeComponent();
        items.Add(track);
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


}