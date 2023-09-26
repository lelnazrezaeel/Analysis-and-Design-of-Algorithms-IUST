using System;

namespace Q5
{
    class Program
    {
        static void CheckMix(string s1, string s2, string m)
        {
            int lenS1 = s1.Length;
            int lenS2 = s2.Length;
            int lenM = m.Length;
            int[,] table = new int[lenS1 + 1, lenS2 + 1];
            if (lenS1 + lenS2 != lenM)
                Console.WriteLine("False");
            
            for (int i = 0; i < lenS1 + 1; i++)
            {
                for (int j = 0; j < lenS2 + 1; j++)
                {
                    if (i == 0 && j ==0)
                        table[i, j] = 1;
                    else if (i == 0)
                    {
                        if (s2[j - 1] == m[j - 1])
                            table[i, j] = table[i, j - 1];
                    }    
                    else if (j == 0)
                    {
                        if (s1[i - 1] == m[i - 1])
                            table[i, j] = table[i - 1, j];
                    }
                    else
                    {
                        if (s1[i - 1] == m[i + j - 1] && s2[j - 1] != m[i + j - 1])
                            table[i, j] = table[i - 1, j];
                        else if (s1[i - 1] != m[i + j - 1] && s2[j - 1] == m[i + j - 1])
                            table[i, j] = table[i, j - 1];
                        else
                        {
                            if (table[i - 1, j] == 0 && table[i, j - 1] == 0)
                                table[i, j] = 0;
                            else
                                table[i, j] = 1;
                        }
                    }
                }
            }
            if (table[lenS1, lenS2] == 1)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            string mix = Console.ReadLine();
            CheckMix(input1, input2, mix);
        }
    }
}
