using System;
using System.Collections.Generic;
class Program
{
    static long value_gold = 0;
    static long value_silver = 0;
    class Edge
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public long Gold { get; set; }
        public long Silver { get; set; }

        public Edge(int x, int y, long gold, long silver)
        {
            Source = x;
            Destination = y;
            Gold = gold;
            Silver = silver;
        }
    }
    static int FindParent(int[] parent, int vertex)
    {
        while (parent[vertex] != vertex)
        {
            parent[vertex] = parent[parent[vertex]];
            vertex = parent[vertex];
        }
        return vertex;
    }
    static void MergeSet(int[] parent, int vertex1, int vertex2)
    {
        int root1 = FindParent(parent, vertex1);
        int root2 = FindParent(parent, vertex2);
        parent[root1] = root2;
    }
    static void Main(string[] args)
    {
        int n, m, x, y, idx = 0;
        long g, s, gi, si, min_cost = (long)1e10 + 5;
        string[] inputs = Console.ReadLine().Split(' ');
        n = int.Parse(inputs[0]);
        m = int.Parse(inputs[1]);
        inputs = Console.ReadLine().Split(' ');
        g = long.Parse(inputs[0]);
        s = long.Parse(inputs[1]);
        value_gold = g;
        value_silver = s;
        List<Edge> edges = new List<Edge>();
        int[] parent = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            parent[i] = i;
        }
        for (int i = 0; i < m; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            x = int.Parse(inputs[0]);
            y = int.Parse(inputs[1]);
            gi = long.Parse(inputs[2]);
            si = long.Parse(inputs[3]);
            Edge edge = new Edge(x, y, gi, si);
            edges.Add(edge);
        }
        edges.Sort((a, b) => a.Gold.CompareTo(b.Gold));
        Edge[] helper = new Edge[n + 1];
        for (int i = 0; i < m; i++)
        {
            helper[idx] = edges[i];
            int count = 0;
            for (int j = 0; j <= n; j++)
            {
                parent[j] = j;
            }
            idx++;
            Array.Sort(helper, 0, idx, Comparer<Edge>.Create((a, b) => a.Silver.CompareTo(b.Silver)));
            for (int j = 0; j < idx; j++)
            {
                if (FindParent(parent, helper[j].Destination) != FindParent(parent, helper[j].Source))
                {
                    MergeSet(parent, helper[j].Destination, helper[j].Source);
                    helper[count++] = helper[j];
                }
            }
            if (count == n - 1)
            {
                min_cost = Math.Min(min_cost, edges[i].Gold * value_gold + helper[count - 1].Silver * value_silver);
            }
            idx = count;
        }
        if (min_cost == 1e10 + 5)
        {
            min_cost = -1;
        }
        Console.WriteLine(min_cost);
    }
}