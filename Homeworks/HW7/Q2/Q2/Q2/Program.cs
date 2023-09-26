using System;
using System.Collections.Generic;
using System.Linq;

namespace Q2
{
    class Program
    {
        private static List<List<int>> CreateGraph(int n)
        {
            List<List<int>> edges = new List<List<int>>();
            for (int i = 0; i < n; i++)
                edges.Add(new List<int>());
            return edges;
        }
        private static void AddEdge(List<List<int>> edges, int s, int d)
        {
            edges[s].Add(d);
            edges[d].Add(s);
        }
        private static void AddChain(List<List<int>> edges, int s, int d, int chainLength, ref int n)
        {
            int previous = s;
            for (int i = 0; i < chainLength; i++)
            {
                edges.Add(new List<int>());
                AddEdge(edges, previous, n);
                previous = n;
                n++;
            }
            AddEdge(edges, previous, d);
        }
        private static int CountReachableNodes(List<List<int>> edges, int max)
        {
            int n = edges.Count;
            bool[] visited = new bool[n];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            visited[0] = true;
            while (queue.Count > 0 && max > 0)
            {
                max--;
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    int currentNode = queue.Dequeue();
                    foreach (int neighbor in edges[currentNode])
                    {
                        if (!visited[neighbor])
                        {
                            visited[neighbor] = true;
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }
            return visited.Count(x => x);
        }
        public static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);
            List<List<int>> edges = CreateGraph(n);
            for (int i = 0; i < m; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int s = int.Parse(inputs[0]);
                int d = int.Parse(inputs[1]);
                int c = int.Parse(inputs[2]);
                if (c == 0)
                {
                    AddEdge(edges, s, d);
                }
                else
                {
                    AddChain(edges, s, d, c, ref n);
                }
            }
            int max = int.Parse(Console.ReadLine());
            int reachableNodesCount = CountReachableNodes(edges, max);
            Console.WriteLine(reachableNodesCount);
        }
    }
}