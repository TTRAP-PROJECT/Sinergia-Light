using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class EchangeCompetencesDetails : ContentPage
{
	public EchangeCompetencesDetails(int idCours)
	{
		InitializeComponent();
        InitializeAsync(idCours);
    }

    private async void InitializeAsync(int idCours)
    {
        // Créer une instance de votre ViewModel
        EchangeCompetencesModel echangeCompetences = new EchangeCompetencesModel(idCours);

        // Attendre que les données soient chargées
        await echangeCompetences.LoadData();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = echangeCompetences;
        description.Text = "Description : " + echangeCompetences.Cours.Service.Description;
    }

    private void ReserverButton_Clicked(object sender, EventArgs e)
    {
    }
}