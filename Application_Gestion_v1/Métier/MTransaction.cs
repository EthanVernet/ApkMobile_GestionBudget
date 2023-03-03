using System;
using System.Runtime.InteropServices;

namespace Métier
{
    public class MTransaction
    {
        private List<Transaction> _transactions;

        public MTransaction()
        {
            _transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction); 
        }

        public void RemoveTransaction(Transaction transaction)
        {
            _transactions.Remove(transaction);
        }
    }

}