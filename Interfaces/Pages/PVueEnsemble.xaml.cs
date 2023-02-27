using Application_Gestion.Controllers;
using Application_Gestion.Interfaces.Controls;
using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Pages;

public partial class PVueEnsemble : ContentView, IPages
{
    #region Propertys/Attributs
    private bool _isUpToDate;
    private MCompte _comptes;
    private Compte _compte;
    public Compte Compte { get => _compte; }
    #endregion

    public PVueEnsemble(MCompte comptes, Compte compte)
    {
        _comptes = comptes;
        _compte = compte;
        Observer.Register(this);

        InitializeComponent();
        if (!_isUpToDate) { Update(); }
    }

    #region Interface
    public void Set() { _isUpToDate = false; }

    private void Update()
    {
        _isUpToDate = true;

        Title.Text = "Compte " + _compte.Name;
        SommeTotale.Text = _compte.SommeTotale + " €";
        SommePrevisions.Text = _compte.SommePrévision + " €";

        SommeCredit.Text = " = " + -_compte.SommeCredit + " €";
        SommeDebit.Text = " = " + _compte.SommeDebit + " €";

        ViewDebit.Children.Clear();
        ViewCredit.Children.Clear();

        foreach (Categorie c in _compte.Categories.Categories)
        {
            foreach (Transaction t in c.TransactionCredit)
            {
                ViewCredit.Children.Add(new ItemTransaction(_comptes, _compte, c, t, true));
            }
        }

        foreach (Categorie c in _compte.Categories.Categories)
        {
            foreach (Transaction t in c.TransactionDebit)
            {
                ViewDebit.Children.Add(new ItemTransaction(_comptes, _compte, c, t, true));
            }
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

    private void SwitchView_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.CATEGORIES, _compte);
    }
    #endregion

    private void AddTransaction_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.DADD_TRASACTION, _compte);

    }
}