using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CA23100203
{
    class Program
    {
        static void Main()
        {
            List<Karakter> bank = Beolvas(@"..\..\..\src\bank.txt");
            Console.WriteLine($"5. feladat: Karakterek száma: {bank.Count}");
        }

        static List<Karakter> Beolvas(string utvonal)
        {
            var lista = new List<Karakter>();
            using var sr = new StreamReader(utvonal, Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                char karakter = char.Parse(sr.ReadLine());
                bool[,] matrix = new bool[7, 4];
                for (int s = 0; s < matrix.GetLength(0); s++)
                {
                    string bSor = sr.ReadLine();
                    for (int o = 0; o < matrix.GetLength(1); o++)
                    {
                        matrix[s, o] = bSor[o] == '1';
                    }
                }
                lista.Add(new Karakter(karakter, matrix));
            }
            return lista;
        }
    }
}
