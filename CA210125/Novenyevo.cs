using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210125
{
    class Novenyevo : Allat
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

        public override Allat Szaporodik()
        {
            return new Novenyevo();
        }
    }
}
