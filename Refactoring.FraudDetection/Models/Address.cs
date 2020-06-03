using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Models
{
    public struct Address
    {
        public StringValue Street { get; }

        public StringValue City { get; }

        public StringValue State { get;}

        public StringValue ZipCode { get; }

        private Address(
            StringValue street,
            StringValue city,
            StringValue state,
            StringValue zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public Address UpdateStreet(StringValue street)
            => new Address(
                street,
                City,
                State,
                ZipCode);

        public Address UpdateState(StringValue state)
            => new Address(
                Street,
                City,
                state,
                ZipCode);

        public static Address NewAddress(
            StringValue street,
            StringValue city,
            StringValue state,
            StringValue zipCode)
            => new Address(
                street, 
                city, 
                state, 
                zipCode);
    }
}
