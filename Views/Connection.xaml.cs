using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Connection : ContentPage
{
	public Connection()
	{
		InitializeComponent();
        Shell.SetTabBarIsVisible(this, false);
        // Masquer la flèche de navigation (bouton de retour)
        NavigationPage.SetHasBackButton(this, false);

    }
    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        ConnectionModel connectionModel = new(UsernameEntry.Text, PasswordEntry.Text);
        // Navigate to the desired page
        if (connectionModel.estValide)
        {
            await Navigation.PopAsync();
        }
    }
}