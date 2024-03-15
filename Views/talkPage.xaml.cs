using firstMobileApp.Class;

namespace firstMobileApp.Views;

public partial class talkPage : ContentPage
{
	public talkPage()
	{
		InitializeComponent();

        // Créer une instance de votre ViewModel
        UsersModel usersModel = new UsersModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = usersModel;

    }

}