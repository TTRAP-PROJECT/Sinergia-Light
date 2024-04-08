using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class EchangeCompetences : ContentPage
{
	public EchangeCompetences()
	{
		InitializeComponent();

        // Créer une instance de votre ViewModel
        EchangesCompetencesModel echangesCompetencesModel = new EchangesCompetencesModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = echangesCompetencesModel;
    }

    private async void NavigateToCoursDetails(object sender, TappedEventArgs e)
    {

        var tappedLabel = sender as Label;
        var idCours = (tappedLabel.BindingContext as Class.EchangeCompetences).Service.IdService;
        var test = idCours;

        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
        if (idCours != null)
        {
            await Navigation.PushAsync(new EchangeCompetencesDetails(idCours));
        }

    }
}