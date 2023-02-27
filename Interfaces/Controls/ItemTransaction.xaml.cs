using Application_Gestion.Controllers;
using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Controls;

public partial class ItemTransaction : ContentView
{
    private MCompte _comptes;
    private Compte _compte;
    private Categorie _categorie;
    private Transaction _transaction;
    private bool _isVueEnsemble; 

    public ItemTransaction(MCompte comptes, Compte compte, Categorie categorie, Transaction transaction, bool isVueEnsemble)
    {
        _comptes = comptes;
        _compte = compte;
        _categorie = categorie;
        _transaction = transaction;
        _isVueEnsemble = isVueEnsemble;
        InitializeComponent();
        Name.Text = _transaction.Name;

        if (_transaction.Value > 0) { Value.Text = _transaction.Value + " €"; }
        else { Value.Text = -_transaction.Value + " €"; }
    }

    private void DeleteTransaction_Clicked(object sender, EventArgs e)
    {
        CTransaction.Remove(_comptes, _categorie, _transaction);
        if (_isVueEnsemble) { MainPage.Instance.ShowPage(TypePage.VUE_ENSEMBLE, _compte); }
        else { MainPage.Instance.ShowPage(TypePage.VUE_CATEGORIE, _compte, _categorie); }
    }
}