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
            await Shell.Current.GoToAsync("Main");
        }

        private async void OnForgotPasswordClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Main");
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SignUp");
        }
    }

}
