using System;

namespace Refactoring.FraudDetection.Models
{
    public struct Email
    {
        public StringValue Address { get; }

        private Email(StringValue address)
        {
            Address = address;
        }

        public static Email NewEmail(StringValue address)
        {
            if (!address.Value.Contains("@"))
                throw new ArgumentException("Invalid email address");

            return new Email(address);
        }
    }
}
