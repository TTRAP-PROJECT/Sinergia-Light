using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Covoiturage : ContentPage
{
	public Covoiturage()
	{
		InitializeComponent();

        // Créer une instance de votre ViewModel
        CovoituragesModel covoituragesModel = new CovoituragesModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = covoituragesModel;
    }

    private async void NavigateToCovoiturageDetails(object sender, TappedEventArgs e)
    {
        var tappedLabel = sender as Label;
        var idTrajet = (tappedLabel.BindingContext as Class.Covoiturage).Service.IdService;

        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
        if (idTrajet != null)
        {
            await Navigation.PushAsync(new CovoiturageDetail(idTrajet));
        }
    }
}