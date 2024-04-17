using MusicCreator;
using MusicCreator.Services;

namespace MusicCreator;

public partial class SaveConfirmationPage : ContentPage
{
    Service service = Service.GetService();
    public SaveConfirmationPage()
    {
        InitializeComponent();
    }

    private void OnYesClicked(object sender, EventArgs e)
    {
        service.SaveCreation("Suntem bosi");
    }

    private void OnNoClicked(object sender, EventArgs e)
    {
        // Handle cancel action
        // Navigate back to the main page OR exit without saving 
        Shell.Current.Navigation.PushAsync(new MainPageApp());
    }

}