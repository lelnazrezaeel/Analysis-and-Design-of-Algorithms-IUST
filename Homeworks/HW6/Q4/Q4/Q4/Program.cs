using System;

namespace Q4
{
    class Program
    {
        static int FindMST(int v, int[,] edges)
        {
            int[] parent = new int[v];
            int[] distance = new int[v];
            bool[] visited = new bool[v];
            for (int i = 0; i < v; i++)
            {
                parent[i] = -1;
                distance[i] = int.MaxValue;
            }
            distance[0] = 0;
            for (int i = 0; i < v; i++)
            {
                int idx = -1;
                int minDistance = int.MaxValue;
                for (int j = 0; j < v; j++)
                {
                    if (!visited[j] && distance[j] < minDistance)
                    {
                        idx = j;
                        minDistance = distance[j];
                    }
                }
                if (idx == -1)
                {
                    break;
                }
                visited[idx] = true;
                for (int j = 0; j < v; j++)
                {
                    if (!visited[j] && edges[idx, j] < int.MaxValue && edges[idx, j] < distance[j])
                    {
                        distance[j] = edges[idx, j];
                        parent[j] = idx;
                    }
                }
            }
            int minCost = 0;
            for (int i = 0; i < v; i++)
            {
                if (parent[i] != -1)
                {
                    minCost += distance[i];
                }
            }
            int answer = int.MaxValue;
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    if (edges[i, j] < int.MaxValue && parent[i] != j && parent[j] != i)
                    {
                        int newCost = minCost - distance[Math.Max(parent[i], parent[j])] + edges[i, j];
                        answer = Math.Min(answer, newCost);
                    }
                }
            }
            if (answer == int.MaxValue)
            {
                return -1;
            }
            else
            {
                return answer;
            }
        }
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int v = int.Parse(inputs[0]); 
            int e = int.Parse(inputs[1]); 
            int[,] edges = new int[v, v];
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    edges[i, j] = int.MaxValue;
                }
            }
            for (int i = 0; i < e; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int vi = int.Parse(inputs[0]) - 1;
                int vj = int.Parse(inputs[1]) - 1;
                int w = int.Parse(inputs[2]);
                edges[vi, vj] = edges[vj, vi] = w;
            }
            Console.WriteLine(FindMST(v, edges));
        }
    }
}
