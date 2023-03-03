using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Controls;

public partial class ButtonMenu : ContentView
{
	private Compte _compte;
	private Categorie _categorie;
	private List<Color> _colors = new List<Color> { new Color(33, 137, 235), new Color(47, 194, 70), new Color(47, 194, 70), new Color(33, 137, 235), new Color(33, 137, 235), new Color(47, 194, 70) };

    public ButtonMenu(int indexColor, int x, int y, Compte compte, Categorie categorie)
	{
        _compte = compte;
		_categorie = categorie;
		InitializeComponent();
		Button.Text = _categorie.Name + "\n" + _categorie.SommeTotale + " €";
		Button.BorderColor =_colors[indexColor];
		this.SetValue(Grid.ColumnProperty, x);
		this.SetValue(Grid.RowProperty, y);
	}

    public ButtonMenu(int indexColor, int x, int y, Compte compte)
    {
        _compte = compte;
        InitializeComponent();
        Button.Text = _compte.Name + "\n" + _compte.SommeTotale + " €";
        Button.BorderColor = _colors[indexColor];
        this.SetValue(Grid.ColumnProperty, x);
        this.SetValue(Grid.RowProperty, y);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		if(_categorie != null)
		{
            MainPage.Instance.ShowPage(TypePage.VUE_CATEGORIE, _compte, _categorie);
        }
		else
		{
            MainPage.Instance.ShowPage(TypePage.VUE_ENSEMBLE, _compte);
        }
    }
}