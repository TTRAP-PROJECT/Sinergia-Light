using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class EvenementSportifsDetails : ContentPage
{
    public EvenementSportifsDetails(int idSport)
    {
        InitializeComponent();
        InitializeAsync(idSport);
    }

    private async void InitializeAsync(int idSport)
    {
        // Cr�er une instance de votre ViewModel
        EvenementSportifModel evenementSportifModel = new EvenementSportifModel(idSport);

        // Attendre que les donn�es soient charg�es
        await evenementSportifModel.LoadData();

        // D�finir le BindingContext sur votre ViewModel
        BindingContext = evenementSportifModel;
        description.Text = "Description : " + evenementSportifModel.Sport.Service.Description;
    }

    private void ReserverButton_Clicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}