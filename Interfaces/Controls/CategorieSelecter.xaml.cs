using Application_Gestion.Model;

namespace Application_Gestion.Interfaces.Controls;

public partial class CategorieSelecter : ContentView
{
    private MCategorie _categories;
    private int _index;

    public CategorieSelecter(MCategorie categories)
    {
        _categories = categories;
        _index = 0;

        InitializeComponent();
        viewCategorie.Text = _categories.Categories[0].Name;
    }

    public Categorie GetCategorieSelected { get => _categories.Categories[_index]; }

    private void Up_Clicked(object sender, EventArgs e)
    {
        if (_index > 0)
        {
            _index--;
        }
        viewCategorie.Text = _categories.Categories[_index].Name;
    }

    private void Down_Clicked(object sender, EventArgs e)
    {
        if (_index < _categories.Categories.Count - 1)
        {
            _index++;
        }
        viewCategorie.Text = _categories.Categories[_index].Name;
    }
}