using System.Text.Json.Serialization;

namespace Application_Gestion.Model
{
    public class Categorie
    {
        private string _name;

        [JsonInclude]
        public string Name { get => _name; set => _name = value; }

        public float _limite;

        [JsonInclude]
        public float Limite { get => _limite; set => _limite = value; }

        private MTransaction _transactions;

        [JsonInclude]
        public MTransaction Transactions { get => _transactions; }

        public Categorie(string name, float limite)
        {
            _transactions = new MTransaction();
            _name = name;
            _limite = limite;
        }

        [JsonIgnore]
        public float SommeTotale { get => _transactions.SommeTotale; }
        [JsonIgnore]
        public float SommeCredit { get => _transactions.SommeCredit; }
        [JsonIgnore]
        public float SommeDebit { get => _transactions.SommeDebit; }
        [JsonIgnore]
        public float SommePrévisions { get => SommeTotale + Limite; }

        [JsonIgnore]
        public List<Transaction> TransactionCredit { get => _transactions.TransactionCredit; }
        [JsonIgnore]
        public List<Transaction> TransactionDebit { get => _transactions.TransactionDebit; }
        [JsonIgnore]
        public List<Transaction> TransactionTotale { get => _transactions.TransactionTotale; }

        public void AddTransaction(Transaction transaction)
        {
            _transactions.AddTransaction(transaction);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            _transactions.RemoveTransaction(transaction);
        }
    }
}
