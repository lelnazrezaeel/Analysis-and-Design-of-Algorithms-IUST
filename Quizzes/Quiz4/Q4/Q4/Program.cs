using System;
using System.Collections.Generic;
using System.Linq;

namespace Q4
{
    class Program
    {
        static int[] FindDistance(int[] edges, int node, int len)
        {
            var queue = new List<int>();
            queue.Add(node);
            var distance = Enumerable.Repeat(int.MaxValue, len).ToArray();
            distance[node] = 0;
            while (queue.Count > 0)
            {
                int vertex = queue[0];
                queue.RemoveAt(0);
                int v = edges[vertex];
                if (v == -1)
                {
                    continue;
                }
                if (distance[vertex] + 1 < distance[v])
                {
                    distance[v] = distance[vertex] + 1;
                    queue.Add(v);
                }
            }
            return distance;
        }
        static int NearestNeighbour(int[] edges, int node1, int node2, int len)
        {
            int[] distance1 = FindDistance(edges, node1, len);
            int[] distance2 = FindDistance(edges, node2, len);
            int answer = -1, idx = -1;
            for (int i = 0; i < len; i++)
            {
                if (distance1[i] == int.MaxValue || distance2[i] == int.MaxValue)
                {
                    continue;
                }
                int dist = Math.Max(distance1[i], distance2[i]);
                if (answer == -1 || dist < answer)
                {
                    answer = dist;
                    idx = i;
                }
            }
            return idx;
        }
        static void Main(string[] args)
        {
            int len = int.Parse(Console.ReadLine());
            string[] inputs = Console.ReadLine().Split(' ');
            int[] edges = new int[len];
            for (int i = 0; i < len; i++)
            {
                edges[i] = int.Parse(inputs[i]);
            }
            int node1 = int.Parse(Console.ReadLine());
            int node2 = int.Parse(Console.ReadLine());
            Console.WriteLine(NearestNeighbour(edges, node1, node2, len));
        }
    }
}
