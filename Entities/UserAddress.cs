using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Entities
{
    internal class UserAddress
    {
        public string City { get; set; }
        public string Estate { get; set; }
        public string Street { get; set; }


       

        public UserAddress(string city, string estate, string street)
        {
            City = city;

            Estate = estate;

            Street = street;
        }




        public override string ToString()
        {
            StringBuilder display = new StringBuilder();

            display.Append("\nCidade: ");
            display.Append(City);
            display.Append("\nEstado: ");
            display.Append(Estate);
            display.Append("\nRua: ");
            display.Append(Street);

            return display.ToString();
        }

    }
}