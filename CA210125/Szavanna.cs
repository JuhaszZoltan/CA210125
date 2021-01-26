using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210125
{
    class Szavanna
    {
        public Allat[,] Terulet { get; set; }

        public Cella Megkeres(Allat allat)
        {

            for (int x = 0; x < Terulet.GetLength(0); x++)
            {
                for (int y = 0; y < Terulet.GetLength(1); y++)
                {
                    if (Terulet[x, y] == allat) return new Cella(x, y);
                }
            }
            return null;
        }


        public void Torol(Allat allat, bool megdoglik)
        {
            var c = Megkeres(allat);
            if (c != null)
            {
                allat.El = !megdoglik;
                Terulet[c.X, c.Y] = null;
            }
        }

        public void Athelyez(Allat allat, Cella ujCella)
        {
            Torol(allat, false);
            Terulet[ujCella.X, ujCella.Y] = allat;
        }

        public List<Allat> KornyezoAllatok(Allat allat)
        {
            var c = Megkeres(allat);

            if (c is null) return null;
            else
            {
                var kornyezoAllatok = new List<Allat>();

                for (int x = Math.Max(c.X - 1, 0);
                    x <= Math.Min(c.X + 1, Terulet.GetLength(0));
                    x++)
                {
                    for (int y = Math.Max(c.Y - 1, 0);
                        y <= Math.Min(c.Y + 1, Terulet.GetLength(1));
                        y++)
                    {
                        if(x != c.X && y != c.Y && Terulet[x, y] != null)
                        {
                            kornyezoAllatok.Add(Terulet[x, y]);
                        }
                    }
                }
                return kornyezoAllatok;
            }
        }

        public List<Allat> UresCellak(Allat allat)
        {
            throw new NotImplementedException();
        }

        public void Elhelyez(Allat allat)
        {
            throw new NotImplementedException();
        }


        public Szavanna(int teruletX, int teruletY)
        {
            Terulet = new Allat[teruletX, teruletY];
        }
    }
}
