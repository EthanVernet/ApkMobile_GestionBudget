using Métier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestMTransaction
    {
        private MTransaction _transactions = new();
        private Transaction t1 = new("t", 1);
        private Transaction t2 = new("t", 2);
        private Transaction t3 = new("t", 3);

        [Fact]
        public void TestAddTransaction()
        {
            Assert.Empty(_transactions.Transactions);

            _transactions.AddTransaction(t1);
            Assert.Single(_transactions.Transactions);

            _transactions.AddTransaction(t2);
            _transactions.AddTransaction(t3);
            Assert.Equal(3, _transactions.Transactions.Count);
        }

        [Fact]
        public void TestRemoveTransaction()
        {
            _transactions.AddTransaction(t1);
            _transactions.AddTransaction(t2);
            _transactions.AddTransaction(t3);   
            Assert.Equal(3, _transactions.Transactions.Count);

            _transactions.RemoveTransaction(t1);
            Assert.Equal(2, _transactions.Transactions.Count);

            _transactions.RemoveTransaction(t2);
            _transactions.RemoveTransaction(t3);
            Assert.Empty(_transactions.Transactions);

        }
    }
}
