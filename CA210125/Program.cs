using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA210125
{
    class Program
    {
        public static Random rnd = new Random();
        static void Main()
        {
            var szavanna = new Szavanna(20, 20);

            for (int i = 0; i < 200; )
            {
                int x = rnd.Next(szavanna.Terulet.GetLength(0));
                int y = rnd.Next(szavanna.Terulet.GetLength(1));

                if (szavanna.Terulet[x, y] is null)
                {

                   if(rnd.Next(100) < 65)
                   {
                        int me = rnd.Next(11, 15);
                        int ek = rnd.Next(0, me);
                        szavanna.Elhelyez(new Novenyevo() { MaxEletkor = me, Eletkor = ek }, new Cella(x, y));
                   }
                   else
                   {
                        int me = rnd.Next(9, 13);
                        int ek = rnd.Next(0, me);
                        szavanna.Elhelyez(new Ragadozo() { MaxEletkor = me, Eletkor = ek }, new Cella(x, y));
                    }
                    i++;
                }
            }


            for (int i = 0; i < 100; i++)
            {
                szavanna.Kirajzol();
                szavanna.EltelikEgyEv();
                Thread.Sleep(500);
                Console.Clear();
            }

            Console.ReadKey();
            
        }
    }
}
