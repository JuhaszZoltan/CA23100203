using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA23100203
{
    class Program
    {
        static void Main()
        {
            var bank = Beolvas(@"..\..\..\src\bank.txt");
            Console.WriteLine($"5. feladat: Karakterek száma: {bank.Count}");

            char inputChr;
            bool isParsed;
            do
            {
                Console.Write("6. feladat: Kérek egy angol nagyvetűt: ");
                isParsed = char.TryParse(Console.ReadLine(), out inputChr);
            } while (!isParsed || inputChr < 65 || inputChr > 90);

            Console.Write("7. feladat: ");
            var megj = bank.SingleOrDefault(k => k.Betu == inputChr);
            Console.WriteLine(
                megj is null 
                ? "Nincs ilyen karakter a bakban!" 
                : $"\n{megj.KarakterKep}");

            var dekodolando = Beolvas(@"..\..\..\src\dekodol.txt");

            Console.WriteLine("9. feladat: Dekódolás");
            foreach (var k in dekodolando)
            {
                var bk = bank.FirstOrDefault(b => b.Felismer(k));
                Console.Write(bk is null ? "?" : bk.Betu);
            }
            Console.Write('\n'); 
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
