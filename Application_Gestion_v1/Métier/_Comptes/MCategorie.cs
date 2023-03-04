using System;

namespace Métier
{
    public class MCategorie
    {
        private List<Categorie> _categories;

        public MCategorie()
        {
            _categories = new List<Categorie>();
        }

        public void AddCategorie(Categorie categorie)
        {
            _categories.Add(categorie);
        }

        public void RemoveCategorie(Categorie categorie)
        {
            _categories.Remove(categorie);
        }
    }
}