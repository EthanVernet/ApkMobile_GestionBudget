namespace _Exception
{
    public class ExceptionNameIsNull : Exception
    {
        public ExceptionNameIsNull() : base("Error : Transaction name was empty !") { }
    }

    public class ExceptionValueEqualZero : Exception 
    { 
        public ExceptionValueEqualZero() : base("Error : Transaction value was equal 0 !") { }
    }
}