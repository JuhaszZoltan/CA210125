﻿using System;
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
        public void Torol(Allat allat)
        {
            var c = Megkeres(allat);
            if (c != null) Terulet[c.X, c.Y] = null;
        }
        public void Athelyez(Allat allat, Cella ujCella)
        {
            Torol(allat);
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
                    x <= Math.Min(c.X + 1, Terulet.GetLength(0) -1);
                    x++)
                {
                    for (int y = Math.Max(c.Y - 1, 0);
                        y <= Math.Min(c.Y + 1, Terulet.GetLength(1) -1);
                        y++)
                    {
                        if (x != c.X && y != c.Y && Terulet[x, y] != null)
                        {
                            kornyezoAllatok.Add(Terulet[x, y]);
                        }
                    }
                }
                return kornyezoAllatok;
            }
        }
        public List<Cella> UresCellak(Allat allat)
        {
            var c = Megkeres(allat);

            if (c is null) return null;
            else
            {
                var kornyezoCellak = new List<Cella>();

                for (int x = Math.Max(c.X - 1, 0);
                    x <= Math.Min(c.X + 1, Terulet.GetLength(0) - 1);
                    x++)
                {
                    for (int y = Math.Max(c.Y - 1, 0);
                        y <= Math.Min(c.Y + 1, Terulet.GetLength(1) -1);
                        y++)
                    {
                        if (x != c.X && y != c.Y && Terulet[x, y] == null)
                        {
                            kornyezoCellak.Add(new Cella(x, y));
                        }
                    }
                }
                return kornyezoCellak;
            }
        }
        public void Elhelyez(Allat allat, Cella cella)
        {
            if (Terulet[cella.X, cella.Y] is null) Terulet[cella.X, cella.Y] = allat;
        }

        public void EltelikEgyEv()
        {
            var allatok = Megkever();

            foreach (var a in allatok)
            {
                if (a.El)
                {
                    if (a is Novenyevo) a.Eszik();
                    else
                    {
                        if (VanNovenyevoKorulotte(a as Ragadozo))
                        {
                            int i = 0;
                            while (KornyezoAllatok(a)[i] is Ragadozo) i++;
                            KornyezoAllatok(a)[i].El = false;
                            Torol(KornyezoAllatok(a)[i]);
                            a.Eszik();
                        }
                    }

                    if(a.VanKedveSzaporodni && UresCellak(a).Count != 0)
                    {
                        var ujAllt = a.Szaporodik();
                        Elhelyez(ujAllt, UresCellak(a)[Program.rnd.Next(UresCellak(a).Count)]);
                    }

                    if(UresCellak(a) != null && UresCellak(a).Count != 0)
                    {
                        Athelyez(a, UresCellak(a)[Program.rnd.Next(UresCellak(a).Count)]);
                    }

                    a.Oregszik();
                    if (!a.El) Torol(a);
                }
            }
        }
        List<Allat> Megkever()
        {
            var allatok = new List<Allat>();
            foreach (var a in Terulet) if (a != null) allatok.Add(a);
            for (int i = 0; i < allatok.Count; i++)
            {
                var x = Program.rnd.Next(allatok.Count);
                var y = Program.rnd.Next(allatok.Count);

                var s = allatok[x];
                allatok[x] = allatok[y];
                allatok[y] = s;
            }
            return allatok;
        }
        bool VanNovenyevoKorulotte(Ragadozo r)
        {
            if (KornyezoAllatok(r) is null) return false;

            foreach (var a in KornyezoAllatok(r))
            {
                if (a is Novenyevo) return true;
            }
            return false;
        }

        public void Kirajzol()
        {
            for (int x = 0; x < Terulet.GetLength(0); x++)
            {
                for (int y = 0; y < Terulet.GetLength(1); y++)
                {
                    if(Terulet[x, y] is null)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write('.');
                    }
                    else if (Terulet[x, y] is Ragadozo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('R');
                    }
                    else if (Terulet[x, y] is Novenyevo)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('N');
                    }

                    Console.ResetColor();
                }
                Console.Write("\n");
            }
        }

        public Szavanna(int teruletX, int teruletY)
        {
            Terulet = new Allat[teruletX, teruletY];
        }
    }
}
