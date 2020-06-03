using System;
using Refactoring.FraudDetection.Models;

namespace Refactoring.FraudDetection.Handlers.NormalizeHandlers
{
    public class NormalizeEmailHandler : IHandler<Order>
    {
        public Order Handle(Order request)
            => request.UpdateEmail(NormalizeEmail(request.Email));

        static Email NormalizeEmail(Email email)
            => Email.NewEmail(Normalize(email.Address));

        static string Normalize(string address) {
            var parts = SplitEmailByAt(address);

            parts[0] = RemoveDots(parts[0]);
            parts[0] = RemoveIfPlus(parts[0]);

            return JoinParts(parts);
        }

        static string[] SplitEmailByAt(string email) 
            => email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

        static string JoinParts(string[] parts) 
            => string.Join("@", new string[] { parts[0], parts[1] });

        static string RemoveDots(string text) 
            => text.Replace(".", "");

        static string RemoveIfPlus(string text)
        {
            var atIndex = FindPlus(text);

            return atIndex < 0
                ? text
                : text.Remove(atIndex);
        }

        static int FindPlus(string text) 
            => text.IndexOf("+", StringComparison.Ordinal);
    }
}
