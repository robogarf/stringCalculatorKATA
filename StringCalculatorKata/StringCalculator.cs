using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == String.Empty)
            {
                return 0;
            }

            var splittedNumbers = SplitNumbers(numbers);
            int sum = 0;
            var negativeNumbers = new List<int>();

            foreach (var splittedNumber in splittedNumbers)
            {
                var number = int.Parse(splittedNumber);

                if (number < 0)
                {
                    negativeNumbers.Add(number);
                }

                sum += number;
            }

            HandleNegativeNumbers(negativeNumbers);

            return sum;

            //for (int i = 0; i < splittedNumbers.Length; i++)
            //{
            //    sum += int.Parse(splittedNumbers[i]);
            //}

            //return numbers
            //    .Split(',')
            //    .Select(number => int.Parse(number))
            //    .Sum();
        }

        private void HandleNegativeNumbers(List<int> negativeNumbers)
        {
            if (negativeNumbers.Any())
            {
                var message = String.Join(", ", negativeNumbers);
                throw new NegativesNotAllowedException(message);
            }
        }

        private string[] SplitNumbers(string numbers)
        {
            var delimeters = new char[] { ',', '\n' };

            if (numbers.StartsWith("//"))
            {
                delimeters = new char[] { numbers[2] };
                numbers = numbers.Substring(4);
            }

            return numbers.Split(delimeters);
        }
    }
}
