using System.Diagnostics;

namespace Refactoring.FraudDetection.Models
{
    [DebuggerDisplay("{Value}")]
    public struct StringValue
    {
        public string Value { get; }

        private StringValue(string value)
        {
            Value = value;
        }

        public static implicit operator StringValue(string value)
            => value != null
                ? new StringValue(value)
                : new StringValue(string.Empty);

        public static implicit operator string(StringValue str)
            => str.Value;
    }
}
