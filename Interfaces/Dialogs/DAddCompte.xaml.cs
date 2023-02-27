using Application_Gestion.Controllers;
using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Dialogs;

public partial class DAddCompte : ContentView
{
    private MCompte _comptes;
    public DAddCompte(MCompte comptes)
    {
        _comptes = comptes;
        InitializeComponent();
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.ACCUEIL);
    }

    private async void Valider_Clicked(object sender, EventArgs e)
    {
        bool? res = CCompte.Add(_comptes, Name.Text);
        if (res == false)
        {
            await MainPage.Instance.DisplayAlert("Erreur", "Vous n'avez pas entrer le nom du compte.", "Ok");
        }
        MainPage.Instance.ShowPage(TypePage.ACCUEIL);
    }
}