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

        public void AddTransactionAnnuel(Transaction transaction)
        {
            _annuel.AddTransaction(transaction);
        }

        public void RemoveTransactionAnnuel(Transaction transaction)
        {
            _annuel.RemoveTransaction(transaction);
        }

        public void AddTransactionMensuel(Transaction transaction)
        {
            _mensuel.AddTransaction(transaction);
        }

        public void RemoveTransactionMensuel(Transaction transaction)
        {
            _mensuel.RemoveTransaction(transaction);
        }

        public void AddCompte(Compte compte)
        {
            _comptes.AddCompte(compte);
        }

        public void RemoveCompte(ref Compte compte)
        {
            _comptes.RemoveCompte(compte);
        }
    }
}