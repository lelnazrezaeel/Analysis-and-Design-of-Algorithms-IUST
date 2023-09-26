using System;
using System.Collections.Generic;
enum Colors
{
    white, gray, black
}
class program
{
    class Coordinates
    {
        public int x_i;
        public int y_i;
        public int num;
        public Colors colors;
        public Coordinates parent;
        public List<Coordinates> neighbours;
        public Coordinates(int x, int y, int number)
        {
            this.x_i = x;
            this.y_i = y;
            this.num = number;
            colors = Colors.white;
            parent = null;
            neighbours = new List<Coordinates>();
        }

    }
    static void Visited(Coordinates coordinate)
    {
        int len = coordinate.neighbours.Count;
        coordinate.colors = Colors.gray;
        for (int i = 0; i < len; i++)
        {
            if (coordinate.neighbours[i].colors == Colors.white)
            {
                coordinate.neighbours[i].parent = coordinate;
                Visited(coordinate.neighbours[i]);
            }
        }
        coordinate.colors = Colors.black;
    }
    static void DFS(Coordinates[] coordinates, ref int min)
    {
        int len = coordinates.Length;
        for (int i = 0; i < len; i++)
        {
            if (coordinates[i].colors == Colors.white)
            {
                Visited(coordinates[i]);
                min += 1;
            }
        }
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int x, y, min = 0, answer;
        Coordinates[] coordinates = new Coordinates[n];
        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            x = int.Parse(inputs[0]);
            y = int.Parse(inputs[1]);
            coordinates[i] = new Coordinates(x, y, i);
        }
        for (int i = 0; i <= n - 2; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (coordinates[i].x_i == coordinates[j].x_i)
                {
                    coordinates[i].neighbours.Add(coordinates[j]);
                    coordinates[j].neighbours.Add(coordinates[i]);
                }
                if (coordinates[i].y_i == coordinates[j].y_i)
                {
                    coordinates[i].neighbours.Add(coordinates[j]);
                    coordinates[j].neighbours.Add(coordinates[i]);
                }
            }
        }
        DFS(coordinates, ref min);
        answer = min - 1;
        Console.WriteLine(answer);
    }
}