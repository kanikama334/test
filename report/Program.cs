using System;

class Program
{
  static string fileName = "example.txt"; // ファイル名
  static string currentDirectory = Directory.GetCurrentDirectory();
  static StreamWriter? writer;
  static string? filePath;
  static void Main()
  {
    filePath = Path.Combine(currentDirectory, fileName);
    Console.Write("生成するランダムな整数の数を入力してください: ");
    int count = int.Parse(Console.ReadLine());
    Console.Write("1降順 2昇順 3ランダム を選択ソートで降順に: ");
    int flag = int.Parse(Console.ReadLine());
    using (writer = new StreamWriter(filePath))
    {
      writer.WriteLine("n,Compare,Swap");
    }
    for (int j = 0; j < 100; j++)
    {
      int[] numbers = GenerateRandomNumbers(count);
      // int[] numbers2 = new int[count];
      // int[] numbers3 = new int[count];
      // for (int i = 0; i < count; i++)
      // {
      //   numbers2[i] = numbers[i];
      //   numbers3[i] = numbers[i];
      // }
      Console.WriteLine("\n生成されたランダムな整数配列:");
      PrintArray(numbers);
      // Console.WriteLine("\n昇順にソートされた配列:");
      // InsertionSort(numbers3, SortOrder.Ascending);
      // PrintArray(numbers3);
      // Console.WriteLine("\n降順にソートされた配列:");
      // InsertionSort(numbers2, SortOrder.Descending);
      // PrintArray(numbers2);

      if (flag == 1)
      {
        Console.WriteLine("\n降順にソートされた配列:");
        InsertionSort(numbers, SortOrder.Descending);
        PrintArray(numbers);
        Console.WriteLine("\n生成された降順の整数配列を選択ソートで降順に:");
        SelectionSortDescending(numbers,count);
      }
      else if (flag == 2)
      {
        Console.WriteLine("\n昇順にソートされた配列:");
        InsertionSort(numbers, SortOrder.Ascending);
        PrintArray(numbers);
        Console.WriteLine("\n生成された昇順の整数配列を選択ソートで降順に:");
        SelectionSortDescending(numbers,count);
      }
      else if (flag == 3)
      {
        Console.WriteLine("\n生成されたランダム順の整数配列を選択ソートで降順に:");
        SelectionSortDescending(numbers,count);
      }
      else
      {

      }
      count = count + 100;
    }
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

  static int[] SelectionSortDescending(int[] array,int count)
  {
    int n = array.Length;
    int swap = 0;
    int compare = 0;
    for (int i = 0; i < n - 1; i++)
    {
      int maxIndex = i;
      for (int j = i + 1; j < n; j++)
      {
        if (array[j] > array[maxIndex])
        {
          maxIndex = j;
          compare++;
        }
      }

      if (maxIndex != i)
      {
        int temp = array[i];
        array[i] = array[maxIndex];
        array[maxIndex] = temp;
        swap++;
      }
    }
    using (writer = new StreamWriter(filePath,true))
    {
      writer.WriteLine(count.ToString()+"," + compare.ToString() + "," + swap.ToString());
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

  //0昇順　1降順
  static void InsertionSort(int[] array, SortOrder sortOrder)
  {
    int n = array.Length;

    for (int i = 1; i < n; i++)
    {
      int key = array[i];
      int j = i - 1;

      if (sortOrder == SortOrder.Ascending)
      {
        while (j >= 0 && array[j] > key)
        {
          array[j + 1] = array[j];
          j--;
        }
      }
      else if (sortOrder == SortOrder.Descending)
      {
        while (j >= 0 && array[j] < key)
        {
          array[j + 1] = array[j];
          j--;
        }
      }

      array[j + 1] = key;
    }
  }
}

enum SortOrder
{
  Ascending,
  Descending
}
