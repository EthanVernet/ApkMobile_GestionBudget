using Application_Gestion.Controllers;
using Application_Gestion.Interfaces.Controls;
using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Dialogs;

public partial class DAddTransaction : ContentView
{
    private MCompte _comptes;
    private Compte _compte;
    private CategorieSelecter _selecter;

    public DAddTransaction(MCompte comptes, Compte compte)
    {
        _comptes = comptes;
        _compte = compte;
        InitializeComponent();

        _selecter = new(_compte.Categories);
        _selecter.SetValue(Grid.RowProperty, 6);
        _selecter.Margin = new Thickness(40, 0, 40, 0);
        _selecter.VerticalOptions = LayoutOptions.Center;
        _selecter.HeightRequest = 40;

        MainGrid.Children.Add(_selecter);
    }

    private async void Valider_Clicked(object sender, EventArgs e)
    {
        Tuple<bool, string> res = CTransaction.Create(_comptes, _selecter.GetCategorieSelected, Name.Text, Value.Text);
        if (res.Item1 == false)
        {
            await MainPage.Instance.DisplayAlert("Erreur", res.Item2, "Ok");
        }
        MainPage.Instance.ShowPage(TypePage.VUE_ENSEMBLE, _compte);
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        MainPage.Instance.ShowPage(TypePage.VUE_ENSEMBLE, _compte);
    }
}