using firstMobileApp.Views;

namespace firstMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            spawn();
        }
        public async void spawn()
        {
            await Navigation.PushAsync(new Connection());
            
        }
    }
}
