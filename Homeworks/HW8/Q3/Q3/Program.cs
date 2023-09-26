using System;
using System.Collections.Generic;

namespace MaxFlow
{
    class Program
    {
        const int SIZE = 5000;
        static int[] cap = new int[SIZE];
        static int[][] capac = new int[SIZE][];
        static int[][] res = new int[SIZE][];
        static int[] parent = new int[SIZE];
        static bool[] visited = new bool[SIZE];

        static bool BFS(int source, int destination, int v)
        {
            Array.Fill(visited, false);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);
            visited[source] = true;
            parent[source] = -1;
            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                for (int i = 1; i <= v; i++)
                {
                    if (!visited[i] && res[u][i] > 0)
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                        parent[i] = u;
                    }
                }
            }
            return visited[destination];
        }

        static int MaxCapacity(int source, int destination, int num_vertices)
        {
            Array.Copy(capac, res, SIZE);
            int max = 0;
            while (BFS(source, destination, 2 * num_vertices))
            {
                int path = int.MaxValue;
                int u = destination;
                while (u != source)
                {
                    int v = parent[u];
                    path = Math.Min(path, res[v][u]);
                    u = parent[u];
                }
                u = destination;
                while (u != source)
                {
                    int v = parent[u];
                    res[v][u] -= path;
                    res[u][v] += path;
                    u = parent[u];
                }
                max += path;
            }
            return max;
        }

        public static void Main()
        {
            int v, e, src, dst, c, source, destination;
            string[] input1 = Console.ReadLine().Split();
            v = int.Parse(input1[0]);
            e = int.Parse(input1[1]);
            for (int i = 0; i < SIZE; ++i)
            {
                capac[i] = new int[SIZE];
                res[i] = new int[SIZE];
            }
            for (int i = 0; i < e; ++i)
            {
                string[] input2 = Console.ReadLine().Split();
                src = int.Parse(input2[0]);
                dst = int.Parse(input2[1]);
                c = int.Parse(input2[2]);
                capac[2 * src][2 * dst - 1] = c;
            }
            string[] input3 = Console.ReadLine().Split();
            for (int i = 0; i < v; ++i)
            {
                cap[i + 1] = int.Parse(input3[i]);
                capac[2 * (i + 1) - 1][2 * (i + 1)] = cap[i + 1];
            }
            string[] input4 = Console.ReadLine().Split();
            source = int.Parse(input4[0]);
            destination = int.Parse(input4[1]);
            int maxFlow = MaxCapacity(2 * source - 1, 2 * destination, v);
            Console.WriteLine(maxFlow);
        }
    }
}
