using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210125
{
    class Ragadozo : Allat
    {
        public override int MaxEletkor
        { 
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public override int Ehseg 
        { 
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public override bool VanKedveSzaporodni 
        { 
            get => throw new NotImplementedException();
        }

        public override void Eszik()
        {
            throw new NotImplementedException();
        }

        public override void Szaporodik()
        {
            if (VanKedveSzaporodni && VanHova && VanKivel)
                Szavanna.Elhelyez(new Ragadozo { Eletkor = 0 });
        }
    }
}
