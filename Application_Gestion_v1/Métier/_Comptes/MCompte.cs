using System;
using System.Runtime.InteropServices;

namespace Métier
{
    public class MCompte
    {
        private List<Compte> _comptes;

        public MCompte()
        {
            _comptes = new List<Compte>();
        }

        public void AddCompte(Compte compte)
        {
            _comptes.Add(compte);
        }

        public void RemoveCompte(Compte compte)
        {
            _comptes.Remove(compte);
        }
    }
}