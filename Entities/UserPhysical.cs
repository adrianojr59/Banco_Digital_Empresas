using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Entities
{
    internal class UserPhysical : Tel
    {

        public string Name { get; set; }
        public string Cpf { get; set; }
        public UserAddress Address { get; set; }
        public string Document { get; set; }
        public string BirthDate { get; set; }
        public int Date_Nasciment { get; set; }
        public Tel Telephone { get; set; }
        public string Email { get; set; }
        public Banking Banking { get; set; }
        public DateTime Date_Create { get; set; }
        public LoanCard loanCard { get; set; }
        public TypeofAcess typeofAcess { get; set; }
        public TypeAccount typeAccount { get; set; }
        public AccountPhysical accountPhysical { get; set; }
        public AccountBusiness AccountBusiness { get; set; }





        public UserPhysical() { }

        public UserPhysical(string name, string cpf, UserAddress address, string document, string birthdate, int date_nasciment, string email, Banking banking, LoanCard loancard, DateTime date_create
            , TypeAccount typeAccount, AccountPhysical accountPhysical, TypeofAcess typeofAcess, string Telephon) : base(Telephon)
        {

            Name = name;
            Cpf = cpf;
            Address = address;
            Document = document;
            BirthDate = birthdate;
            Date_Nasciment = date_nasciment;
            Email = email;
            Banking = banking;
            loanCard = loancard;
            Date_Create = date_create;
            this.typeAccount = typeAccount;
            this.accountPhysical = accountPhysical;
            this.typeofAcess = typeofAcess;
        }



        public virtual void loan(double LoanCredity, Banking loan_Banking) //emprestimo
        {

            Banking.loandepost(LoanCredity * 0.3);

            Console.WriteLine($"Credito: {Banking.Credity}");


        }



        public override string ToString()
        {

            StringBuilder display = new StringBuilder();

            //display.Append("\nId: ");
            //display.Append(Id);
            display.Append("\nNome: ");
            display.Append(Name);

            display.Append("\nData_Nascimento:");
            display.Append(BirthDate);
            display.Append("\nIdade: ");
            display.Append(Date_Nasciment);
            display.Append("\nTelefone: ");
            display.Append(Telephon);
            display.Append("\nEmail: ");
            display.Append(Email);
            display.Append("\nCPF: ");
            display.Append(Cpf);
            display.Append("\nStatus : ");
            display.Append(loanCard);
            display.Append("\nData_De_Abertura_Conta: ");
            display.Append(Date_Create);
            display.Append("\nTipo De Conta: ");
            display.Append(typeAccount);
            display.Append("\n");
            display.Append(accountPhysical);
            display.Append("  ");
            display.Append(typeofAcess);

            display.Append(Banking);
            return display.ToString();





        }



    }
}
