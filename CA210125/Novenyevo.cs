using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210125
{
    class Novenyevo : Allat
    {
        private int _maxEletkor;
        public override int MaxEletkor
        {
            get => _maxEletkor;
            set 
            {
                if (value > 14) throw new Exception("rossz maxEletkor");
                _maxEletkor = value;
            }
        }

        public override bool VanKedveSzaporodni => eveSzaporodott > 1;


        public override Allat Szaporodik()
        {
            eveSzaporodott = 0;
            return new Novenyevo() { Eletkor = 0, };
        }
    }
}
