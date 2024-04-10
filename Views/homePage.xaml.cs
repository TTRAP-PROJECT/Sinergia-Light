using firstMobileApp.Class;
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
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ReservationModel.LoadData();

        }

        

        private async void ButtonTrash_Clicked(object sender, EventArgs e)
        {
            var tappedButton = sender as Button;
            // Obtenez l'ID de la réservation à partir du contexte de liaison
            var reservation = tappedButton.BindingContext as Reservation;
            if (reservation != null)
            {
                bool result = await ExceptionModel.AnnulerReservation(reservation.IdReservation);
                if (result)
                {
                    await DisplayAlert("Annulation réussie", "L'annulation du service a bien été effectuée", "OK");

                    UserSessionManager.UpdateUserData();
                    // Rechargez les données après l'annulation réussie
                    reservationModel.LoadData();
                }
                else
                {
                    await DisplayAlert("Annulation échouée", "L'annulation du service n'a pas bien été effectuée", "OK");
                }
            }
        }
    }

}
