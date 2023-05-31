using System;

class Program
{
    static void Main()
    {
        Console.Write("生成するランダムな整数の数を入力してください: ");
        int count = int.Parse(Console.ReadLine());

        int[] numbers = GenerateRandomNumbers(count);

        Console.WriteLine("生成されたランダムな整数配列:");
        PrintArray(numbers);

        Console.WriteLine("\n昇順にソートされた配列:");
        int[] sortedNumbers = SelectionSort(numbers, SortOrder.Ascending);
        PrintArray(sortedNumbers);

        Console.WriteLine("\n降順にソートされた配列:");
        sortedNumbers = SelectionSort(numbers, SortOrder.Descending);
        PrintArray(sortedNumbers);

        Console.WriteLine("\nランダムな順番の配列:");
        sortedNumbers = SelectionSort(numbers, SortOrder.Random);
        PrintArray(sortedNumbers);
    }

    static int[] GenerateRandomNumbers(int count)
    {
        Random random = new Random();
        int[] numbers = new int[count];

        for (int i = 0; i < count; i++)
        {
            numbers[i] = random.Next(1, 100); // 適宜範囲を調整
        }

        return numbers;
    }

    static int[] SelectionSort(int[] array, SortOrder sortOrder)
    {
        int length = array.Length;

        for (int i = 0; i < length - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < length; j++)
            {
                bool shouldSwap = false;

                if (sortOrder == SortOrder.Ascending)
                {
                    shouldSwap = array[j] < array[minIndex];
                }
                else if (sortOrder == SortOrder.Descending)
                {
                    shouldSwap = array[j] > array[minIndex];
                }
                else if (sortOrder == SortOrder.Random)
                {
                    shouldSwap = (new Random()).Next(0, 2) == 0;
                }

                if (shouldSwap)
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }

        return array;
    }

    static void PrintArray(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}

enum SortOrder
{
    Ascending,
    Descending,
    Random
}