using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        List<int> arr = new List<int>();
        List<int> indexArr = new List<int>();
        List<int> result = new List<int>(new int[n]);
        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
            arr.Add(int.Parse(Console.ReadLine()));

        for (int i = 0; i < m; i++)
            indexArr.Add(int.Parse(Console.ReadLine()));

        for (int i = n - 1; i >= 0; i--)
        {
            if (dict.ContainsKey(arr[i]))
                dict[arr[i]]++;
            else
                dict.Add(arr[i], 1);

            result[i] = dict.Count;
        }

        foreach (int index in indexArr)
            Console.WriteLine(result[index - 1]);
    }
}