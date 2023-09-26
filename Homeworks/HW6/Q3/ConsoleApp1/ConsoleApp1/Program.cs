using System;

namespace ConsoleApp1
{
    class Program
    {
        static int v;
        static int FindMinKeyVertex(int[] k, bool[] visited)
        {
            int min = int.MaxValue, idx = -1;
            for (int i = 0; i < v; i++)
            {
                if (visited[i] == false && k[i] < min)
                {
                    min = k[i];
                    idx = i;
                }
            }
            return idx;
        }
        static int CalculateMST(int[,] edges, int e)
        {
            v = edges.GetLength(0);
            int[] parent = new int[v]; 
            int[] k = new int[v];
            bool[] visited = new bool[v];
            int sum = 0, vertex;
            for (int i = 0; i < v; i++)
            {
                k[i] = int.MaxValue;
                visited[i] = false;
            }
            k[0] = 0;
            parent[0] = -1;
            for (int i = 0; i < v - 1; i++)
            {
                vertex = FindMinKeyVertex(k, visited);
                visited[vertex] = true;
                for (int j = 0; j < v; j++)
                    if (edges[vertex, j] != 0 && visited[j] == false && edges[vertex, j] < k[j])
                    {
                        parent[j] = vertex;
                        k[j] = edges[vertex, j];
                    }
            }
            for (int i = 1; i < v; i++)
                sum += edges[i, parent[i]];

            return sum;
        }
        public static void Main()
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int v = int.Parse(inputs[0]);
            int e = int.Parse(inputs[1]);
            int vi, vj, w;
            int[,] edges = new int[v, v];
            for (int i = 0; i < e; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                vi = int.Parse(inputs[0]) - 1;
                vj = int.Parse(inputs[1]) - 1;
                w = int.Parse(inputs[2]);
                edges[vi, vj] = edges[vj, vi] = w;
            }
            Console.WriteLine(CalculateMST(edges, e));
        }
    }
}
