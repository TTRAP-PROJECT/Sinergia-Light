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
        // Incr�mente le nombre de cookies collect�s
        cookieCount++;

        // Met � jour l'affichage du nombre de cookies
        CookieCountLabel.Text = cookieCount.ToString();
    }
}