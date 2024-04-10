using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class accountPage : ContentPage
{
    ToolbarItem soldeToolbarItem;

    public accountPage()
	{
		InitializeComponent();
        soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
        email.Text = UserSessionManager.Email;
		nom.Text = UserSessionManager.Nom + " " + UserSessionManager.Prenom;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        
        await UserSessionManager.UpdateUserData();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰";
    }
}