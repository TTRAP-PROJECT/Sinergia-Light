using firstMobileApp.Models;

namespace firstMobileApp
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            AnnoncesModel annonceModel = new AnnoncesModel();
            BindingContext = annonceModel;
        }

        


    }

}
