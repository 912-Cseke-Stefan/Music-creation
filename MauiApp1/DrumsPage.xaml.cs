namespace MusicCreator;

public partial class DrumsPage : ContentPage
{
	public DrumsPage()
	{
		InitializeComponent();
	}
    private async void OnNextClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Main");
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Main");
    }
}