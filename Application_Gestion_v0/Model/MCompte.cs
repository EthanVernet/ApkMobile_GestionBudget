using Application_Gestion.Controllers;

namespace Application_Gestion.Model
{
    public class MCompte
    {
        private List<Compte> _comptes ;

        public List<Compte> Comptes { get => _comptes; set => _comptes = value; }

        public float SommePrevisions { get => LimiteTotales + CreditTotales; }

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
                    Observer.Sets();
                }
            }
        }
    }
}
