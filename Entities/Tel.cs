using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Entities
{
    internal class Tel
    {
        public string Telephon { get; protected set; }





        public Tel() { }
        public Tel(string telephon)
        {
            Telephon = telephon;
        }




        public string setTelephon
        {

            set { Telephon = value; }

        }


        public override string ToString()
        {
            return "\nTelefone: " + Telephon;
        }


    }
}
