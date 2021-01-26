using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210125
{
    class Program
    {
        public static Random rnd = new Random();
        static void Main()
        {

            Szavanna sz = new Szavanna(10, 10);


            Console.WriteLine(sz.Megkeres(new Ragadozo()) is null);

            Console.ReadKey();
        }
    }
}
