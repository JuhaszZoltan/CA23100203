using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA23100203
{
    class Karakter
    {
        public char Betu { get; set; }
        public bool[,] Matrix { get; set; }

        public string KarakterKep
        {
            get
            {
                string kep = string.Empty;
                for (int s = 0; s < Matrix.GetLength(0); s++)
                {
                    for (int o = 0; o < Matrix.GetLength(1); o++)
                    {
                        kep += Matrix[s, o] ? 'X' : ' ';
                    }
                    kep += '\n';
                }
                return kep[..^1];
            }
        }

        public bool Felismer(Karakter felism)
        {
            for (int s = 0; s < Matrix.GetLength(0); s++)
            {
                for (int o = 0; o < Matrix.GetLength(1); o++)
                {
                    if (this.Matrix[s, o] != felism.Matrix[s, o]) return false;
                }
            }
            return true;
        }

        public Karakter(char betu, bool[,] matrix)
        {
            Betu = betu;
            Matrix = matrix;
        }
    }
}
