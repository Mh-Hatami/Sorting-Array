using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Array
{
    class Operation
    {
        public int[] GetInputArray()
        {
            Console.WriteLine("/////////////////////////// Enter Numbers Separated by Space: ///////////////////////////");
            Console.WriteLine();
            string input = Console.ReadLine();
            string[] numbersAsString = input.Split(' ');
            int[] inputArray = new int[numbersAsString.Length];

            for (int i = 0; i < numbersAsString.Length; i++)
            {
                inputArray[i] = Convert.ToInt32(numbersAsString[i]);
            }
            return inputArray;
        }

        public int[] GenerateRandomArray()
        {
            Random random = new Random();
            int[] numbers = new int[10000];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 10001);
            }
            return numbers;
        }
    }
}
