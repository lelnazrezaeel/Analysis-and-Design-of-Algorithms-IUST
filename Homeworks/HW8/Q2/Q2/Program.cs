using System;
using System.Collections.Generic;

namespace Q2
{
    class Program
    {
        static List<int>[] edges;
        static bool[] visited;
        static List<int> matching;
        static bool BipartiteMatch(int u, int n)
        {
            foreach (var vertex in edges[u])
            {
                if (!visited[vertex])
                {
                    visited[vertex] = true;
                    if (matching[vertex] == -1 || BipartiteMatch(matching[vertex], n))
                    {
                        matching[u] = vertex - n;
                        matching[vertex] = u;
                        return true;
                    }
                }
            }
            return false;
        }

        static void MaximumMatch(int n, int m)
        {
            for (int i = 1; i <= n; i++)
            {
                visited = new bool[n + m + 1]; 
                BipartiteMatch(i, n);
            }
        }

        static void Main()
        {
            string[] inputs = Console.ReadLine().Split();
            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);
            edges = new List<int>[n + m + 1];
            for (int i = 1; i <= n + m; i++)
            {
                edges[i] = new List<int>();
            }
            for (int i = 1; i <= n; i++)
            {
                inputs = Console.ReadLine().Split();
                for (int j = 1; j <= m; j++)
                {
                    int temp = int.Parse(inputs[j - 1]);
                    if (temp == 1)
                    {
                        edges[i].Add(j + n);
                        edges[j + n].Add(i);
                    }
                }
            }
            matching = new List<int>();
            for (int i = 0; i <= n + m; i++)
            {
                matching.Add(-1);
            }
            MaximumMatch(n, m);
            for (int i = 1; i <= n; i++)
            {
                if (matching[i] != -1)
                {
                    Console.Write(matching[i] + " ");
                }
                else
                {
                    Console.Write(-1 + " ");
                }
            }
        }
    }
}
