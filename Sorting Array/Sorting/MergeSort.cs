using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sorting_Array.Sorting
{
    class MergeSort : ISortAlgorithm
    {
        public long ElapsedMilliseconds { get; private set; }
        public int[] Sort(int[] arr)
        {
            var sw = Stopwatch.StartNew();
            if (arr.Length <= 1)
                return arr;

            int middle = arr.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[arr.Length - middle];

            for (int i = 0; i < middle; i++)
                left[i] = arr[i];

            for (int i = middle; i < arr.Length; i++)
                right[i - middle] = arr[i];

            left = Sort(left);
            right = Sort(right);

            sw.Stop();
            ElapsedMilliseconds = sw.ElapsedMilliseconds;

            return Merge(left, right);
            
        }

        private int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];

            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    result[k] = left[i];
                    i++;
                }
                else
                {
                    result[k] = right[j];
                    j++;
                }

                k++;
            }

            while (i < left.Length)
            {
                result[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                result[k] = right[j];
                j++;
                k++;
            }

            return result;
        }
    }

}
