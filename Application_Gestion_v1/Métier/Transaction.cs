using _Exception;
using System;
using System.Runtime.InteropServices;

namespace Métier
{
    public class Transaction
    {
        public string Name 
        { 
            get => _name;
            set
            {
                if (value == null || value == "") { throw new ExceptionNameIsNull(); }
                _name = value;
            }
        }
        private string _name;
        public float Value 
        { 
            get => _value;
            set
            {
                if (value <= 0) { throw new ExceptionValueEqualZero(); }
                _value = (float)Math.Truncate((double)value);
            }
        }
        private float _value;


        public Transaction(string name, float value)
        {
            Name = name;
            Value = value;
        }
    }
}
