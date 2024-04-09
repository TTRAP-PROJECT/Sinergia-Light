using firstMobileApp.Models;

namespace firstMobileApp
{
    public partial class HomePage : ContentPage
    {
        AnnoncesModel annoncesModel;
        ReservationModel reservationModel;
        HomePageViewModel viewModel;
        public HomePage()
        {
            InitializeComponent();
            annoncesModel = new AnnoncesModel();
            reservationModel = new ReservationModel();

            // Créer un objet contenant les deux modèles
            viewModel = new HomePageViewModel
            {
                AnnoncesModel = annoncesModel,
                ReservationModel = reservationModel
            };
            BindingContext = viewModel;
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            annoncesModel = new AnnoncesModel();
            reservationModel = new ReservationModel();

            // Créer un objet contenant les deux modèles
            viewModel = new HomePageViewModel
            {
                AnnoncesModel = annoncesModel,
                ReservationModel = reservationModel
            };
            BindingContext = viewModel;
        }
    }

}
