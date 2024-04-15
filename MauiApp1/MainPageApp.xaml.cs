namespace MusicCreator;

public partial class MainPageApp : ContentPage
{
	public MainPageApp()
	{
		InitializeComponent();

        List<string> items = ["Track1", "Track2", "Track3", "Track4", "Track5"];
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

}