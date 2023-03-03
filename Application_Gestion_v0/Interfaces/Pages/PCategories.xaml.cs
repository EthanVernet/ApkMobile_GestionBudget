using Application_Gestion.Controllers;
using Application_Gestion.Interfaces.Controls;
using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Pages;

public partial class PCategories : ContentView, IPages
{
    #region Propertys/Attributs
    private bool _isUpToDate;
    private Compte _compte;
    public Compte Compte { get => _compte; }

    #endregion

    public PCategories(Compte compte)
    {
        _compte = compte;
        Observer.Register(this);

        InitializeComponent();
        if (!_isUpToDate) { Update(); }
    }

    #region Interface
    public void Set() { _isUpToDate = false; }

    public void Update()
    {
        _isUpToDate = true;

        Title.Text = "Compte " + _compte.Name;
        SommeTotale.Text = _compte.SommeTotale + " €";
        SommePrevisions.Text = _compte.SommePrévision + " €";

        int x = 0, y = 0, c = 0;
        foreach (Categorie categorie in _compte.Categories.Categories)
        {
            if (x > 1) { x = 0; y++; }
            ConteneurButton.Children.Add(new ButtonMenu(c, x, y, _compte, categorie));
            x++; c++;
        }
    }
    #endregion

    #region Event
    private void ButtonMenu_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.ACCUEIL);
    }

    private void ButtonParametre_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.DPARAMETRE_COMPTE, _compte);
    }

    private void AddCategorie_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.DADD_CATEGORIE, _compte);
    }
    #endregion

    private void SwitchView_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.VUE_ENSEMBLE, _compte);
    }
}