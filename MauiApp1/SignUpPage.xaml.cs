namespace MusicCreator;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}

    private async void GoFromMainToLogInPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("LogIn");
    }
    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Main");
    }

}