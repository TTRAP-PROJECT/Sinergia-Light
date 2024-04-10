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
        try
        {
            ConnectionModel connectionModel = new(UsernameEntry.Text, PasswordEntry.Text);
            await connectionModel.LoadData();
            // Navigate to the desired page
            if (connectionModel.estValide)
            {
                UserSessionManager.SetUser(UsernameEntry.Text);
                await UserSessionManager.UpdateUserData();
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Connexion échouée", "Login ou mot de passe incorrect.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur connexion", "Une erreur est survenue", "OK");

        }

    }
}