using System;

namespace Métier
{
    public class MBudget
    {
        private Budget _annuel;
        private Budget _mensuel;
        private MCompte _comptes;

        public MBudget()
        {
            _annuel = new Budget();
            _mensuel = new Budget();
            _comptes = new MCompte();
        }

        public void AddTransactionAnnuel(ref Transaction transaction)
        {
            throw new System.NotImplementedException("Not implemented");
        }

        public void RemoveTransactionAnnuel(ref Transaction transaction)
        {
            throw new System.NotImplementedException("Not implemented");
        }

        public void AddTransactionMensuel(ref Transaction transaction)
        {
            throw new System.NotImplementedException("Not implemented");
        }

        public void RemoveTransactionMensuel(ref Transaction transaction)
        {
            throw new System.NotImplementedException("Not implemented");
        }

        public void AddCompte(ref Compte compte)
        {
            throw new System.NotImplementedException("Not implemented");
        }

        public void RemoveCompte(ref Compte compte)
        {
            throw new System.NotImplementedException("Not implemented");
        }
    }
}