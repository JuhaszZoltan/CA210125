using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210125
{
    struct Cella
    {

    }
    class Szavanna
    {


        public List<Allat> KornyezoAllatok(Allat allat)
        {
            throw new NotImplementedException();
        }

        public List<Cella> UresCellak(Allat allat)
        {
            throw new NotImplementedException();
        }

        public void Elhelyez(Allat allat)
        {
            if(allat.Eletkor == 0)
            {
                if (allat is Ragadozo) 
                    allat.MaxEletkor = Program.rnd.Next(9, 13);
                else if (allat is Novenyevo) 
                    allat.MaxEletkor = Program.rnd.Next(11, 15);
            }
        }
    }
}
