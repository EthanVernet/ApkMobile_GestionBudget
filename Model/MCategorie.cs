using System.Text.Json.Serialization;

namespace Application_Gestion.Model
{
    public class MCategorie
    {
        private List<Categorie> _categories;

        [JsonInclude]   
        public List<Categorie> Categories { get => _categories; }

        public MCategorie()
        {
            _categories = new List<Categorie>();
            AddCategorie(new Categorie("Défaut",0.0F));
        }

        #region Propertys

        [JsonIgnore]
        public float SommePrévisions { get => SommeLimite + SommeCredit; }

        [JsonIgnore]
        public float SommeLimite
        {
            get
            {
                float res = 0.0f;
                foreach (var categorie in _categories)
                {
                    res += categorie.Limite;
                }
                return res;
            }
        }

        [JsonIgnore]
        public float SommeTotal
        {
            get
            {
                float res = 0.0f;
                foreach (var categorie in _categories)
                {
                    res += categorie.SommeTotale;
                }
                return res;
            }
        }

        [JsonIgnore]
        public float SommeCredit
        {
            get
            {
                float res = 0.0f;
                foreach (var categorie in _categories)
                {
                    res += categorie.SommeCredit;
                }
                return res;
            }
        }

        [JsonIgnore]
        public float SommeDebit
        {
            get
            {
                float res = 0.0f;
                foreach (var categorie in _categories)
                {
                    res += categorie.SommeDebit;
                }
                return res;
            }
        }

        [JsonIgnore]
        public List<Transaction> TransactionCredit
        {
            get
            {
                List<Transaction> res = new List<Transaction>();
                foreach (var categorie in _categories)
                {
                    res.AddRange(categorie.TransactionCredit);
                }
                return res;
            }
        }

        [JsonIgnore]
        public List<Transaction> TransactionDebit
        {
            get
            {
                List<Transaction> res = new List<Transaction>();
                foreach (var categorie in _categories)
                {
                    res.AddRange(categorie.TransactionDebit);
                }
                return res;
            }
        }
        #endregion

        public void AddCategorie(Categorie categorie)
        {
            _categories.Add(categorie);
        }

        public void RemoveCategorie(Categorie categorie)
        {
            _categories.Remove(categorie);
        }

        public Categorie GetCategorie(Categorie categorie)
        {
            return _categories[_categories.IndexOf(categorie)];
        }
    }
}
