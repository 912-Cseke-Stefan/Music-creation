namespace MusicCreator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("Main", typeof(MainPageApp));
            Routing.RegisterRoute("LogIn", typeof(LogInPage));
            Routing.RegisterRoute("SignUp", typeof(SignUpPage));
        }
    }
}
