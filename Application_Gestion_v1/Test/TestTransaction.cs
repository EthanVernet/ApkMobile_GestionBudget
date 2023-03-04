using _Exception;
using Métier;

namespace Test
{
    public class TestTransaction
    {
        [Fact]
        public void TestName()
        {
            bool res = false;
            try
            {
                Transaction t = new("nomAchat", 12);
                res = true;
            }
            catch(ExceptionNameIsNull) { }
            Assert.True(res);

            Assert.Throws<ExceptionNameIsNull>(() => { Transaction t = new("", 12); });
            Assert.Throws<ExceptionNameIsNull>(() => { Transaction t = new(null, 12); });
        }

        [Fact]
        public void TestValue()
        {
            bool res = false;
            try
            {
                Transaction t = new("nomAchat", 12);
                res = true;
            }
            catch (ExceptionValueEqualZero) { }
            Assert.True(res);

            Assert.Throws<ExceptionValueEqualZero>(() => { Transaction t = new("nomAchat", 0); });
        }
    }
}