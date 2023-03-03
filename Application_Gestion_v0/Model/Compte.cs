using System.Text.Json.Serialization;

namespace Application_Gestion.Model
{
    public class Compte
    {
        private string _name;

        [JsonInclude]
        public string Name { get => _name; set => _name = value; }

        private MCategorie _categories;

        [JsonInclude]
        public MCategorie Categories { get => _categories; }

        [JsonIgnore]
        public float SommeTotale { get => _categories.SommeTotal; }
        [JsonIgnore]
        public float SommeCredit { get => _categories.SommeCredit; }
        [JsonIgnore]
        public float SommeDebit { get => _categories.SommeDebit; }
        [JsonIgnore]
        public float SommeLimit { get => _categories.SommeLimite; }
        [JsonIgnore]
        public float SommePrévision { get => SommeLimit + SommeCredit; }

        public Compte(string name)
        {
            _name = name;
            _categories = new();
        }

        public Categorie GetCategorie(Categorie categorie)
        {
            return _categories.GetCategorie(categorie);
        }

        public void AddCategorie(Categorie categorie)
        {
            _categories.AddCategorie(categorie);
        }

        public void RemoveCategorie(Categorie categorie)
        {
            _categories.RemoveCategorie(categorie);
        }
    }
}
