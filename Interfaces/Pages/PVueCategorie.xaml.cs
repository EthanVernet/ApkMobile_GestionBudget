using Application_Gestion.Controllers;
using Application_Gestion.Interfaces.Controls;
using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Pages;

public partial class PVueCategorie : ContentView, IPages
{
    #region Propertys/Attributs
    private bool _isUpToDate;
    private MCompte _comptes;
    private Categorie _categorie;
    public Categorie Categorie { get => _categorie; }
    private Compte _compte;
    public Compte Compte { get => _compte; }
    #endregion

    public PVueCategorie(MCompte comptes, Compte compte, Categorie categorie)
    {
        _comptes = comptes;
        _compte = compte;
        _categorie = categorie;
        Observer.Register(this);

        InitializeComponent();

        if (!_isUpToDate) { Update(); }
    }

    #region Interface
    public void Set()
    {
        _isUpToDate = false;
    }

    private void Update()
    {
        _isUpToDate = true;
        Title.Text = _categorie.Name;

        SommeTotale.Text = _compte.SommeTotale + " €";
        SommePrevisions.Text = _compte.SommePrévision + " €";
        ViewTransaction.Children.Clear();

        foreach (Transaction t in _categorie.TransactionTotale)
        {
            ViewTransaction.Children.Add(new ItemTransaction(_comptes, _compte, _categorie, t, false));
        }
    }
    #endregion

    private void ButtonMenu_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.ACCUEIL);
    }

    private void ButtonParametre_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.DPARAMETRE_CATEGORIE, _compte, _categorie);
    }

    private void AddTransaction_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.DADD_TRANSACTION_CATEGORIE, _compte, _categorie);
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.CATEGORIES, _compte);
    }
}