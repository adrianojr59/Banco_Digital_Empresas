using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Entities
{


    internal class UserBusiness : UserPhysical
    {
        public UserBusiness() { }
        public UserBusiness(string Name, string Cpf, UserAddress address, string document, string birthdate, int date_nasciment, string email, Banking banking, LoanCard loancard, DateTime date_create
                            , TypeAccount typeAccount, AccountPhysical accountPhysical, TypeofAcess typeofAcess, string Telephon)

                            : base(Name, Cpf, address, document, birthdate, date_nasciment, email, banking, loancard, date_create, typeAccount, accountPhysical, typeofAcess, Telephon)
        {

        }



        public override void loan(double LoanCredity, Banking loan_Banking) //emprestimo
        {

            Banking.loandepost(LoanCredity * 2);

            Console.WriteLine($"Credito: {Banking.Credity}");


        }



    }
}
