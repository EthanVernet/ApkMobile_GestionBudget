using System.Text.Json.Serialization;

namespace Application_Gestion.Model
{
    public class MTransaction
    {
        
        private List<Transaction> _transactions;

        [JsonInclude]
        public List<Transaction> Transactions { get => _transactions; }
        
        public MTransaction()
        {
            _transactions = new List<Transaction>();
        }

        #region Propertys
        [JsonIgnore]
        public float SommeTotale { get => SommeCredit + SommeDebit; }

        [JsonIgnore]

        public float SommeCredit
        {
            get
            {
                float res = 0.0F;
                foreach (var transaction in _transactions)
                {
                    if (transaction.Value < 0)
                    {
                        res += transaction.Value;
                    }
                }
                return res;
            }
        }

        [JsonIgnore]
        public float SommeDebit
        {
            get
            {
                float res = 0.0F;
                foreach (var transaction in _transactions)
                {
                    if (transaction.Value > 0)
                    {
                        res += transaction.Value;
                    }
                }
                return res;
            }
        }

        [JsonIgnore]
        public List<Transaction> TransactionTotale { get => _transactions; }

        [JsonIgnore]
        public List<Transaction> TransactionCredit
        {
            get
            {
                List<Transaction> res = new List<Transaction>();
                foreach (var transaction in _transactions)
                {
                    if (transaction.Value < 0)
                    {
                        res.Add(transaction);
                    }
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
                foreach (var transaction in _transactions)
                {
                    if (transaction.Value > 0)
                    {
                        res.Add(transaction);
                    }
                }
                return res;
            }
        }
        #endregion

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
