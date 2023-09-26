using System;
using System.Collections.Generic;

namespace Q1
{
    class Program
    {
        static int SIZE = 3000;
        static int[,] cap = new int[SIZE, SIZE];
        static int[,] residual = new int[SIZE, SIZE];
        static int[] parent = new int[SIZE];
        static bool[] visited = new bool[SIZE];

        static bool BFS(int src, int dst, int n)
        {
            Array.Fill(visited, false);
            Queue<int> q = new Queue<int>();
            q.Enqueue(src);
            visited[src] = true;
            parent[src] = -1;
            while (q.Count > 0)
            {
                int u = q.Dequeue();
                for (int v = 0; v < n; v++)
                {
                    if (!visited[v] && residual[u, v] > 0)
                    {
                        q.Enqueue(v);
                        visited[v] = true;
                        parent[v] = u;
                    }
                }
            }
            return visited[dst];
        }

        static int FordFulkersonAlgorithm(int src, int dst, int n)
        {
            residual = (int[,])cap.Clone();
            while (BFS(src, dst, n))
            {
                int pathFlow = int.MaxValue;
                for (int v = dst; v != src; v = parent[v])
                {
                    int u = parent[v];
                    pathFlow = Math.Min(pathFlow, residual[u, v]);
                }
                for (int v = dst; v != src; v = parent[v])
                {
                    int u = parent[v];
                    residual[u, v] -= pathFlow;
                    residual[v, u] += pathFlow;
                }
            }
            int maxFlow = 0;
            for (int v = 0; v < n; v++)
            {
                if (visited[v])
                {
                    for (int u = 0; u < n; u++)
                    {
                        if (!visited[u] && cap[v, u] > 0)
                        {
                            Console.WriteLine($"{v} - {u}");
                        }
                    }
                }
            }
            return maxFlow;
        }

        static void Main()
        {
            int n, src, dst, u, v, c;
            n = int.Parse(Console.ReadLine());
            src = int.Parse(Console.ReadLine());
            dst = int.Parse(Console.ReadLine());
            while (true)
            {
                string[] inputs = Console.ReadLine().Split();
                u = int.Parse(inputs[0]);
                if (u == -1) 
                    break;
                v = int.Parse(inputs[1]);
                c = int.Parse(inputs[2]);
                cap[u, v] = c;
            }
            FordFulkersonAlgorithm(src, dst, n);
        }
    }
}
