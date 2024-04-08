using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class LoisirsDetail : ContentPage
{
    LoisirModel loisirModel;

    public LoisirsDetail(int idLoisir)
	{
		InitializeComponent();
        InitializeAsync(idLoisir);
        ToolbarItem soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
    }

    private async void InitializeAsync(int idLoisir)
    {
        // Créer une instance de votre ViewModel
        loisirModel = new LoisirModel(idLoisir);

        // Attendre que les données soient chargées
        await loisirModel.LoadData();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = loisirModel;
        description.Text = "Description : " + loisirModel.Loisir.Service.Description;
    }

    private async void ReserverButton_Clicked(object sender, EventArgs e)
    {
        
        var idLoisir = loisirModel.Loisir.Service.IdService;
        var libelle = loisirModel.Loisir.LibelleLoisir;
        var prix = loisirModel.Loisir.Service.Prix;


        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
        if (idLoisir != null)
        {
            await Navigation.PushAsync(new Paiment(idLoisir, libelle, (int)prix));
        }
    }
}