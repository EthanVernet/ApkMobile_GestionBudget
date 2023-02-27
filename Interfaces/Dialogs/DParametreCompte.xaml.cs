using Application_Gestion.Controllers;
using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Dialogs;

public partial class DParametreCompte : ContentView
{
    private MCompte _comptes;
    private Compte _compte;
	public DParametreCompte(MCompte comptes, Compte compte)
	{
        _comptes = comptes; 
        _compte = compte;
		InitializeComponent();
        Name.Text = _compte.Name;
	}

    private async void Valider_Clicked(object sender, EventArgs e)
    {
        bool res = CCompte.Set(_comptes, _compte, Name.Text);
        if (res == false) { await MainPage.Instance.DisplayAlert("Erreur", "Vous n'avez pas entrer le nom du compte.", "Ok"); }
        MainPage.Instance.ShowPage(TypePage.ACCUEIL);
    }

    private async void RemoveCompte_Clicked(object sender, EventArgs e)
    {
        bool res = await MainPage.Instance.DisplayAlert("Suppression du compte " + _compte.Name, "Etes vous sur ?","Non", "Oui");
        if(res == false) 
        { 
            CCompte.Remove(_comptes, _compte);
            MainPage.Instance.ShowPage(TypePage.ACCUEIL);
        }
        else
        {
            MainPage.Instance.ShowPage(TypePage.VUE_ENSEMBLE, _compte);
        }
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.VUE_ENSEMBLE, _compte);
    }

}