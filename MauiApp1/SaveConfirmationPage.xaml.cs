using MusicCreator;

namespace MusicCreator;

public partial class SaveConfirmationPage : ContentPage
{
    public SaveConfirmationPage()
    {
        InitializeComponent();
    }

    private void OnYesClicked(object sender, EventArgs e)
    {
        // Handle save action
        // 
    }

    private void OnNoClicked(object sender, EventArgs e)
    {
        // Handle cancel action
        // Navigate back to the main page OR exit without saving 
        Shell.Current.Navigation.PushAsync(new MainPageApp());
    }

}