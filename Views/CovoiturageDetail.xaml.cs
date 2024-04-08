using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class CovoiturageDetail : ContentPage
{
    public CovoiturageDetail(int idTrajet)
    {
        InitializeComponent();
        InitializeAsync(idTrajet);
    }

    private async void InitializeAsync(int idTrajet)
    {
        // Cr�er une instance de votre ViewModel
        CovoiturageModel covoiturageModel = new CovoiturageModel(idTrajet);

        // Attendre que les donn�es soient charg�es
        await covoiturageModel.LoadData();

        // D�finir le BindingContext sur votre ViewModel
        BindingContext = covoiturageModel;
        description.Text = "Description : " + covoiturageModel.Trajet.Service.Description;
        trajet.Text = covoiturageModel.Trajet.LieuDepart + " --> " + covoiturageModel.Trajet.LieuArrivee;
    }

    private void ReserverButton_Clicked(object sender, EventArgs e)
    {
    }
}
