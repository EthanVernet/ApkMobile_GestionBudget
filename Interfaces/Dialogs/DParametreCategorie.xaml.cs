using Application_Gestion.Controllers;
using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Dialogs;

public partial class DParametreCategorie : ContentView
{
    private MCompte _comptes;
    private Compte _compte;
    private Categorie _categorie;
    public DParametreCategorie(MCompte comptes, Compte compte, Categorie categorie)
    {
        _comptes = comptes;
        _compte = compte;
        _categorie = categorie;
        InitializeComponent();
        
        Name.Text = _categorie.Name;
        Limit.Text = _categorie.Limite.ToString();
    }

    private async void Valider_Clicked(object sender, EventArgs e)
    {

        Tuple<bool, string> res = CCategorie.Set(_comptes, _categorie, Name.Text, Limit.Text);
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

    private async void RemoveCategorie_Clicked(object sender, EventArgs e)
    {
        bool res = await MainPage.Instance.DisplayAlert("Suppression du compte " + _compte.Name, "Si vous faite cela les transactions contenues dans cette catégorie seront perdu.\nEtes vous sur ?","Non", "Oui");
        if (res == false)
        {
            bool res2 = CCategorie.Remove(_comptes, _compte, _categorie);
            if(res2 == false)
            {
                await MainPage.Instance.DisplayAlert("Erreur", "Vous ne pouvez pas avoir 0 catégorie", "Ok");
                MainPage.Instance.ShowPage(TypePage.VUE_CATEGORIE, _compte, _categorie);
            }
            else
            {
                MainPage.Instance.ShowPage(TypePage.CATEGORIES, _compte);
            }
        }
        else
        {
            MainPage.Instance.ShowPage(TypePage.VUE_CATEGORIE, _compte, _categorie);
        }
    }
}