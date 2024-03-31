namespace firstMobileApp.Views;

public partial class CookieClicker : ContentPage
{
    private int cookieCount = 0;

    public CookieClicker()
    {
        InitializeComponent();
    }

    private void CookieButton_Clicked(object sender, System.EventArgs e)
    {
        // Incrémente le nombre de cookies collectés
        cookieCount++;

        // Met à jour l'affichage du nombre de cookies
        CookieCountLabel.Text = cookieCount.ToString();
    }
}