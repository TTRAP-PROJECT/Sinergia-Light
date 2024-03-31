using firstMobileApp.Class;

namespace firstMobileApp.Views;

public partial class accountPage : ContentPage
{
	public accountPage()
	{
		InitializeComponent();
		email.Text = UserSessionManager.Email;
		solde.Text = UserSessionManager.Solde.ToString();
		nom.Text = UserSessionManager.Nom + " " + UserSessionManager.Prenom;
	}
}