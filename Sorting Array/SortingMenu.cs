using Sorting_Array.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Array
{
    class SortingMenu
    {
        Operation operation = new Operation();
        bool exitProgram = false;

        public void DisplayMainMenu()
        {
            while (!exitProgram)
            {
                Console.WriteLine();
                Console.WriteLine("/////////////////////////// Choose your Array ///////////////////////////");
                Console.WriteLine();
                Console.WriteLine("  Click 1: Enter Array Manually");
                Console.WriteLine("  Click 2: Generate Random Array");
                Console.WriteLine("  Click R: Refresh");
                Console.WriteLine("  Click Esc: Exit");
                Console.WriteLine();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        int[] inputArray = operation.GetInputArray();
                        Console.WriteLine();
                        Console.WriteLine("/////////////////////////// Array Entered: ///////////////////////////");
                        Console.WriteLine();
                        Console.WriteLine(string.Join(", ", inputArray));
                        Console.WriteLine();
                        DisplaySortingMenu(inputArray);
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        inputArray = operation.GenerateRandomArray();
                        Console.WriteLine();
                        Console.WriteLine("/////////////////////////// Generated Array: ///////////////////////////");
                        Console.WriteLine();
                        Console.WriteLine(string.Join(", ", inputArray));
                        Console.WriteLine();
                        DisplaySortingMenu(inputArray);
                        break;

                    case ConsoleKey.R:
                        Console.Clear();
                        break;

                    case ConsoleKey.Escape:
                        Console.WriteLine("Program Ended!");
                        exitProgram = true;
                        break;

                    default:
                        break;
                }
            }
        }

        public void DisplaySortingMenu(int[] inputArray)
        {
            while (!exitProgram)
            {
                Console.WriteLine();
                Console.WriteLine("/////////////////////////// Select Sorting Algorithm: ///////////////////////////");
                Console.WriteLine();
                Console.WriteLine("  Click 1: Genetic Algorithm");
                Console.WriteLine("  Click 2: MergeSort");
                Console.WriteLine("  Click R: Refresh");
                Console.WriteLine("  Click Esc: Back to Main Menu");
                Console.WriteLine();

                ConsoleKeyInfo keyInfo2 = Console.ReadKey(true);
                switch (keyInfo2.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        var sorter = new GeneticSort();
                        var sortedArray = sorter.Sort(inputArray);
                        Console.WriteLine("/////////////////////////// Sorted Array By GeneticSort: ///////////////////////////");
                        Console.WriteLine();
                        Console.WriteLine(string.Join(", ", sortedArray));
                        Console.WriteLine();
                        Console.WriteLine("RunTime: " + sorter.ElapsedMilliseconds + "ms");
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        var sorter2 = new MergeSort();
                        var sortedArray2 = sorter2.Sort(inputArray);
                        Console.WriteLine("/////////////////////////// Sorted Array By MergeSort: ///////////////////////////");
                        Console.WriteLine();
                        Console.WriteLine(string.Join(", ", sortedArray2));
                        Console.WriteLine();
                        Console.WriteLine("RunTime: " + sorter2.ElapsedMilliseconds + "ms");
                        break;

                    case ConsoleKey.R:
                        Console.Clear();
                        break;

                    case ConsoleKey.Escape:
                        Console.Clear();
                        return;

                    default:
                        break;
                }

                Console.WriteLine("> Press <Enter> to Continue");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
        }
    }
}
