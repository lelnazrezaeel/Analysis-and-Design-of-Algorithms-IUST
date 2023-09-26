using System;

namespace Q3
{
    class Program
    {
        static int FindShortestPath(int[,] edges, int n, int s, int d)
        {
            bool[] visited = new bool[n];
            int[] distances = new int[n];
            for (int i = 0; i < n; i++)
                distances[i] = int.MaxValue;
            distances[s] = 0;
            for (int i = 0; i < n - 1; i++)
            {
                int idx = FindMinDistance(distances, visited);

                if (idx == -1)
                    break;
                visited[idx] = true;
                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && edges[idx, j] > 0)
                    {
                        int newDistance = edges[idx, j] + distances[idx];

                        if (newDistance < distances[j])
                            distances[j] = newDistance;
                    }
                }
            }
            if (distances[d] != int.MaxValue)
            {
                return distances[d];
            }
            else
            {
                return -1;
            }
        }
        static int FindMinDistance(int[] distances, bool[] visited)
        {
            int min = int.MaxValue;
            int idx = -1;
            for (int i = 0; i < distances.Length; i++)
            {
                if (!visited[i] && distances[i] < min)
                {
                    min = distances[i];
                    idx = i;
                }
            }
            return idx;
        }
        static void Main()
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);
            int k = int.Parse(inputs[2]);
            int[,] edges = new int[n, n];
            for (int i = 0; i < m; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int u = int.Parse(inputs[0]) - 1;
                int v = int.Parse(inputs[1]) - 1;
                int w = int.Parse(inputs[2]);
                edges[u, v] = w;
            }
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int d = FindShortestPath(edges, n, k - 1, i);
                if (d == -1)
                {
                    max = -1;
                    break;
                }
                else if (max < d)
                    max = d;
            }
            Console.WriteLine(max);
        }
    }
}