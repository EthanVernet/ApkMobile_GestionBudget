using Application_Gestion.Controllers;
using Application_Gestion.Interfaces;
using Application_Gestion.Interfaces.Dialogs;
using Application_Gestion.Interfaces.Pages;
using Application_Gestion.Model;
using System;
using System.Text.Json;

namespace Application_Gestion;

public partial class MainPage : ContentPage
{
    private static MainPage _instance;
    public static MainPage Instance { get => _instance; }

    private MCompte _comptes;

    public MainPage()
    {
        _comptes = new MCompte();
        
        Observer.Comptes = _comptes;
        InitializeComponent();
        ShowPage(TypePage.ACCUEIL);
        _instance = this;   
    }

   

    public void ShowPage(TypePage type, Compte compte = null, Categorie categorie = null)
    {
        if ((compte == null) && (categorie == null)) { Show(type); }
        else if (categorie == null)                  { Show(type, compte); }
        else                                         { Show(type, compte, categorie); }
    }

    private void Show(TypePage type)
    {
        switch (type)
        {
            case TypePage.ACCUEIL: ContentPage.Content = new PAccueil(_comptes); break;
            case TypePage.DADD_COMPTE: ContentPage.Content = new DAddCompte(_comptes); break;
        }
    }

    private void Show(TypePage type, Compte compte)
    {
        switch (type)
        {
            case TypePage.VUE_ENSEMBLE: ContentPage.Content = new PVueEnsemble(_comptes, compte); break;
            case TypePage.DADD_TRASACTION: ContentPage.Content = new DAddTransaction(_comptes, compte); break;
            case TypePage.CATEGORIES: ContentPage.Content = new PCategories(compte); break;
            case TypePage.DADD_CATEGORIE: ContentPage.Content = new DAddCategorie(_comptes, compte); break;
            case TypePage.DPARAMETRE_COMPTE: ContentPage.Content = new DParametreCompte(_comptes, compte); break;
        }
    }

    private void Show(TypePage type, Compte compte, Categorie categorie)
    {
        switch (type)
        {
            case TypePage.VUE_CATEGORIE: ContentPage.Content = new PVueCategorie(_comptes, compte, categorie); break;
            case TypePage.DADD_TRANSACTION_CATEGORIE: ContentPage.Content = new DAddTransactionInCategorie(_comptes, compte, categorie); break;
            case TypePage.DPARAMETRE_CATEGORIE: ContentPage.Content = new DParametreCategorie(_comptes, compte, categorie); break;
        }
    }
}

