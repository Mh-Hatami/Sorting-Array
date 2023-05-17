using System.Diagnostics;

namespace Sorting_Array.Sorting
{
    public class GeneticSort : ISortAlgorithm
    {
        private const int MaxGenerations = 1000;
        public long ElapsedMilliseconds { get; private set; }
        public int[] Sort(int[] inputArray)
        {
            var stopwatch = Stopwatch.StartNew(); // شروع کردن محاسبات با استفاده از کلاس Stopwatch
            var population = InitializePopulation(inputArray);
            var random = new Random();
            int generation = 0;

            while (generation < MaxGenerations && Fitness(population[0]) < inputArray.Length - 1)
            {
                var offspring = new List<int[]>();
                foreach (var parent1 in population)
                {
                    foreach (var parent2 in population)
                    {
                        if (parent1 != parent2)
                        {
                            var children = Crossover(parent1, parent2);
                            foreach (var child in children)
                            {
                                if (random.NextDouble() < 0.01) // احتمال جهش
                                {
                                    Mutate(child);
                                }
                                offspring.Add(child);
                            }
                        }
                    }
                }
                population.AddRange(offspring);
                population = Selection(population);
                generation++;
            }
            var result = population[0];
            stopwatch.Stop(); // پایان دادن به محاسبات با استفاده از کلاس Stopwatch
            ElapsedMilliseconds = stopwatch.ElapsedMilliseconds; // محاسبه مدت زمان صرف شده برای اجرای متد

            return result;
        }

        private List<int[]> InitializePopulation(int[] inputArray)
        {
            var ascendingArray = inputArray.OrderBy(x => x).ToArray();
            var reversedArray = inputArray.Reverse().ToArray();
            return new List<int[]> { (int[])ascendingArray.Clone(), (int[])reversedArray.Clone() };
        }

        private List<int[]> Crossover(int[] parent1, int[] parent2)
        {
            int halfLength = parent1.Length / 2;
            return new List<int[]>
            {
                parent1.Take(halfLength).Concat(parent2.Skip(halfLength)).ToArray(),
                parent2.Take(halfLength).Concat(parent1.Skip(halfLength)).ToArray(),
                parent1.Skip(halfLength).Concat(parent2.Take(halfLength)).ToArray(),
                parent2.Skip(halfLength).Concat(parent1.Take(halfLength)).ToArray()
            };
        }

        private void Mutate(int[] array)
        {
            var random = new Random();
            int index1 = random.Next(array.Length);
            int index2 = random.Next(array.Length);
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        private int Fitness(int[] array)
        {
            int score = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] <= array[i + 1])
                {
                    score++;
                }
            }
            return score;
        }

        private List<int[]> Selection(List<int[]> population)
        {
            return population.OrderByDescending(Fitness).Take(2).ToList();
        }
    }
}