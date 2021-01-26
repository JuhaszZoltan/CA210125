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
            }
        }
        abstract public int MaxEletkor { get; set; }
        abstract public int Ehseg { get; set; }
        public bool El { get; protected set; } = true;
        //-----------------------
        public void Oregszik()
        {
            Eletkor++;
            if (Eletkor == MaxEletkor) El = false;
        }

        abstract public bool VanKedveSzaporodni { get; }

        abstract public Allat Szaporodik();
        abstract public void Eszik();
    }
}
