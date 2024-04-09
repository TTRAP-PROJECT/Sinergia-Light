using firstMobileApp.Class;

namespace firstMobileApp.Views;

public partial class accountPage : ContentPage
{
	public accountPage()
	{
		InitializeComponent();
        ToolbarItem soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
        email.Text = UserSessionManager.Email;
		nom.Text = UserSessionManager.Nom + " " + UserSessionManager.Prenom;
	}
}