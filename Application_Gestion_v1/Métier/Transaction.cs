using System;
using System.Runtime.InteropServices;

namespace M�tier
{
    public class Transaction
    {
        public string _name;
        public float _value;

        public Transaction(string name, float value)
        {
            _name = name;
            _value = value;
        }
    }
}
