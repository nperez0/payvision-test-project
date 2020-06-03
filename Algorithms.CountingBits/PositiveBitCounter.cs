// <copyright file="PositiveBitCounter.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;

    public class PositiveBitCounter
    {
        public IEnumerable<int> Count(int input)
        {
            if (input < 0)
                throw new ArgumentException();
            
            var binary = Convert.ToString(input, 2);
            var result = new List<int>() { 0 };
            var last = binary.Length - 1;

            for (int i = last; i >= 0; i--)
            {
                if (binary[i] == '1')
                {
                    result[0]++;
                    result.Add(-(i - last));
                }
            }

            return result;
        }
    }
}
