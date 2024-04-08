using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class EchangeCompetencesDetails : ContentPage
{
    EchangeCompetencesModel echangeCompetences;

    public EchangeCompetencesDetails(int idCours)
	{
		InitializeComponent();
        InitializeAsync(idCours);
        ToolbarItem soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
    }

    private async void InitializeAsync(int idCours)
    {
        // Créer une instance de votre ViewModel
        echangeCompetences = new EchangeCompetencesModel(idCours);

        // Attendre que les données soient chargées
        await echangeCompetences.LoadData();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = echangeCompetences;
        description.Text = "Description : " + echangeCompetences.Cours.Service.Description;
    }

    private async void ReserverButton_Clicked(object sender, EventArgs e)
    {
        var idService = echangeCompetences.Cours.Service.IdService;
        var libelle = echangeCompetences.Cours.Service.LibelleService;
        var prix = echangeCompetences.Cours.Service.Prix;


        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
        if (idService != null)
        {
            await Navigation.PushAsync(new Paiment(idService, libelle, (int)prix));
        }
    }
}