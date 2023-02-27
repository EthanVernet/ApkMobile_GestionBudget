using Application_Gestion.Controllers;
using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Dialogs;

public partial class DAddCategorie : ContentView
{
    private MCompte _comptes;
    private Compte _compte;
    public DAddCategorie(MCompte comptes, Compte compte)
    {
        _comptes= comptes;
        _compte = compte;
        InitializeComponent();
    }

    private async void Valider_Clicked(object sender, EventArgs e)
    {

        Tuple<bool, string> res = CCategorie.Create(_comptes, _compte, Name.Text, Limit.Text);
        if (res.Item1 == false)
        {
            await MainPage.Instance.DisplayAlert("Erreur", res.Item2, "Ok");
        }
        MainPage.Instance.ShowPage(TypePage.CATEGORIES, _compte);
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.CATEGORIES, _compte);
    }

}