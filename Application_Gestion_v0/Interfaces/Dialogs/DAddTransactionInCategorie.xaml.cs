using Application_Gestion.Controllers;
using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Dialogs;

public partial class DAddTransactionInCategorie : ContentView
{
    private MCompte _comptes;
    private Compte _compte;
    private Categorie _categorie;

    public DAddTransactionInCategorie(MCompte comptes, Compte compte, Categorie categorie)
    {
        _comptes = comptes;
        _compte = compte;
        _categorie = categorie;
        InitializeComponent();
    }

    private async void Valider_Clicked(object sender, EventArgs e)
    {
        Tuple<bool, string> res = CTransaction.Create(_comptes, _categorie, Name.Text, Value.Text);
        if (res.Item1 == false)
        {
            await MainPage.Instance.DisplayAlert("Erreur", res.Item2, "Ok");
        }
        MainPage.Instance.ShowPage(TypePage.VUE_CATEGORIE, _compte, _categorie);
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.VUE_CATEGORIE, _compte, _categorie);
    }
}