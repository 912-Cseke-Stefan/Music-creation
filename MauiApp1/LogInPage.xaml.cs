namespace MusicCreator
{
    public partial class LogInPage : ContentPage
    {

        public LogInPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UsernameEntry.Text) && !string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                // Both fields are not empty, proceed with login
                await Shell.Current.GoToAsync("Main");
            }
            else
            {
                // Show an alert indicating that both fields are required
                await DisplayAlert("Error", "Username and password are required fields", "OK");
            }
        }

        private async void OnForgotPasswordClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ForgotPassword");
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SignUp");
        }
    }

}
