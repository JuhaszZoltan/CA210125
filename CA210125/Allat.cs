using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210125
{
    abstract class Allat
    {
        private int _eletkor;
        //-----------------------
        public int Eletkor
        {
            get => _eletkor;
            set
            {
                if (value < 0 || value > MaxEletkor)
                    throw new Exception("hibás életkor");
                _eletkor = value;
            }
        }
        abstract public int MaxEletkor { get; set; }
        public int Ehseg { get; set; } = 0;
        public bool El { get; set; } = true;
        //-----------------------
        public void Oregszik()
        {
            eveSzaporodott++;
            Eletkor++;
            Ehseg++;
            if (Ehseg == 3) El = false;
            if (Eletkor >= MaxEletkor) El = false;
        }
        public int eveSzaporodott;
        abstract public bool VanKedveSzaporodni { get; }
        abstract public Allat Szaporodik();
        public void Eszik()
        {
            Ehseg = 0;
        }
    }
}
