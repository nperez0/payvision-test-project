using System;

namespace Refactoring.FraudDetection
{
    public static class StringExtensions
    {
        public static string[] SplitBySemicolon(this string line)
            => line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    }
}
