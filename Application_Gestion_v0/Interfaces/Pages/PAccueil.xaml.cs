using Application_Gestion.Controllers;
using Application_Gestion.Interfaces.Controls;
using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Pages;


public partial class PAccueil : ContentView, IPages /*, IDisposable*/
{
    #region Propertys/Attributs
    private bool _isUpToDate;
    private MCompte _comptes;
    #endregion

    public PAccueil(MCompte comptes)
    {
        _comptes = comptes;
        Observer.Register(this);
        InitializeComponent();
        if (!_isUpToDate) { Update(); }
    }

    #region Interface
    public void Set() { _isUpToDate = false; }

    public void Update()
    {
        _isUpToDate = true;
        SommeTotale.Text = _comptes.SommeTotales + " €";
        SommePrevisions.Text = _comptes.SommePrevisions + " €";

        int x = 0, y = 0, c = 0;
        foreach (Compte compte in _comptes.Comptes)
        {
            if (x > 1) { x = 0; y++; }
            ConteneurButton.Children.Add(new ButtonMenu(c, x, y, compte));
            x++; c++;
        }
    }
    #endregion

    #region Event
    private void ButtonMenu_Clicked(object sender, EventArgs e)
    {

    }

    private void ButtonHistory_Clicked(object sender, EventArgs e)
    {/*
        string res = await MainPage.Instance.DisplayPromptAsync("Remise à zero", "Voulez vous supprimer toutes les transactions ?");
        if(res == "OK")
        {
            _comptes.RemoveAllTransaction();

        }*/
    }

    private void AddCompte_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.DADD_COMPTE);
    }
    #endregion
}