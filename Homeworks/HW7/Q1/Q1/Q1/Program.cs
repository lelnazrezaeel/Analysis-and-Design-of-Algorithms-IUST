using System;
using System.Collections.Generic;

namespace Q1
{
    class Program
    {
        static void FindShortestPath(int n, List<int>[] edges, int[,] time) 
        {
            int[] parent = new int[n];
            int[] distance = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = -1;
                distance[i] = int.MaxValue;
            }
            distance[0] = 0;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    foreach (int neighbor in edges[j])
                    {
                        if (distance[neighbor] > distance[j] + time[j, neighbor])
                        {
                            distance[neighbor] = distance[j] + time[j, neighbor];
                            parent[neighbor] = j;
                        }
                    }
                }
            }
            bool flag = false;
            int vertexIndex = 0;
            for (; vertexIndex < n; vertexIndex++)
            {
                foreach (int neighbor in edges[vertexIndex])
                {
                    if (distance[neighbor] > distance[vertexIndex] + time[vertexIndex, neighbor])
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                    break;
            }
            if (!flag)
                Console.WriteLine(-1);
            else
            {
                string round = "";
                int startVertex = vertexIndex;
                do
                {
                    round += startVertex + " ";
                    startVertex = parent[startVertex];
                } while (startVertex != vertexIndex);

                round += vertexIndex;

                string[] roundVertices = round.Split(' ');
                Array.Reverse(roundVertices);

                foreach (string vertex in roundVertices)
                {
                    Console.Write(vertex + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);
            List<int>[] edges = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                edges[i] = new List<int>();
            }
            int[,] time = new int[n, n];
            for (int i = 0; i < m; i++)
            {
                inputs = Console.ReadLine().Split();
                int u = int.Parse(inputs[0]);
                int v = int.Parse(inputs[1]);
                int w = int.Parse(inputs[2]);
                edges[u].Add(v);
                time[u, v] = w;
            }
            FindShortestPath(n, edges, time);
        }
    }
}
