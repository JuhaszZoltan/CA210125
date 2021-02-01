using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210125
{
    class Ragadozo : Allat
    {

        private int _maxEletkor;
        public override int MaxEletkor
        {
            get => _maxEletkor;
            set
            {
                if (value > 12) throw new Exception("rossz maxEletkor");
                _maxEletkor = value;
            }
        }
        public override bool VanKedveSzaporodni 
        {
            get => eveSzaporodott > 2 && Ehseg == 0;
        }

        public override Allat Szaporodik()
        {
            eveSzaporodott = 0;
            return new Ragadozo() { Eletkor = 0, };
        }
    }
}
