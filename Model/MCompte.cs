using Application_Gestion.Controllers;
using Application_Gestion.Data;
using System.Text.Json.Serialization;

namespace Application_Gestion.Model
{
    public class MCompte
    {
        private List<Compte> _comptes ;

        [JsonInclude]
        public List<Compte> Comptes { get => _comptes; set => _comptes = value; }

        [JsonIgnore]
        public float SommePrevisions { get => LimiteTotales + CreditTotales; }

        [JsonIgnore]
        public float SommeTotales
        {
            get
            {
                float res = 0.0F;
                foreach (Compte compte in Comptes)
                {
                    res += compte.SommeTotale;
                }
                return res;
            }
        }

        [JsonIgnore]
        public float CreditTotales
        {
            get
            {
                float res = 0.0F;
                foreach (Compte compte in Comptes)
                {
                    res += compte.SommeCredit;
                }
                return res;
            }
        }

        [JsonIgnore]
        public float LimiteTotales
        {
            get
            {
                float res = 0.0F;
                foreach (Compte compte in Comptes)
                {
                    res += compte.SommeLimit;
                }
                return res;
            }
        }

        public MCompte()
        {
            _comptes = new List<Compte> { };
        }

        public void AddCompte(Compte compte)
        {
            _comptes.Add(compte);
        }

        public void RemoveCompte(Compte compte)
        {
            _comptes.Remove(compte);
        }

        public void RemoveAllTransaction()
        {
            foreach(Compte compte in Comptes)
            {
                foreach(Categorie categorie in compte.Categories.Categories)
                {
                    categorie.Transactions.Transactions.Clear();
                    Serializer.SaveComptes(this);
                    Observer.Sets();
                }
            }
        }
    }
}
