using System.Text.Json.Serialization;

namespace Application_Gestion.Model
{
    public class Transaction
    {
        public string _name;

        [JsonInclude]
        public string Name { get => _name; }

        public float _value;

        [JsonInclude]
        public float Value { get => _value; }

        public Transaction(string name, float value)
        {
            _name = name;
            _value = value;
        }
    }
}
