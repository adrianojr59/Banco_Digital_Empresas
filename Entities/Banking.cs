using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace Curso.Entities
{
    internal class Banking
    {

        UserPhysical user = new UserPhysical(); // todo cadastro 



        public double Balance { get; set; }
        public double Credity { get; set; }
        public double Debtor { get; set; }

        public Banking() { }

        public Banking(double debtor)
        {

            Debtor = debtor;
        }



        public Banking(double credity, double debtor)
        {
            Credity = credity;
            Debtor = debtor;
        }




        public bool deposit(double Deposit)
        {

            Balance += Deposit;

            Console.WriteLine($"Saldo: {Balance}");

            return true;
        }


        /* public override void loan(double LoanCredity, Banking loan_Banking) //emprestimo
         {
                   loandepost(LoanCredity * 0.3);

             Console.WriteLine($"Credito: {Credity}");


         }*/


        public void loanSaq(double Loandebtor) //pagamento do emprestimo Saldo Devedor
        {
            Debtor -= Loandebtor;

            Console.WriteLine($"Devedor: {Debtor}");

        }




        public void loandepost(double LoanCredity) //deposito do credito
        {
            Credity += LoanCredity;

            loanSaq(LoanCredity);

            Console.WriteLine($"Saldo: {Balance}");

        }



        public void loanpay(double LoanCredity) //pagamento do emprestimo
        {

            if (saq(LoanCredity) && Debtor < 0)
            {
                Debtor += LoanCredity;

                if (Debtor > 0)
                {
                    Balance += Debtor;

                    Console.WriteLine($"Valor Extornado: {Debtor.ToString("F2", CultureInfo.InvariantCulture)}");
                    Debtor -= Debtor;
                }
                else
                {

                    Console.WriteLine($"Saldo: {Balance}");
                }

            }
        }




        public bool saq(double Saq) //sacar dinheiro
        {

            if (Balance - Saq < (Credity * -1))
            {
                Console.WriteLine("Saldo Insuficiente: ");
                return false;

            }
            Balance -= Saq;
            return true;

        }


        public void transfer(double transfer, Banking loan_Banking)   // transferencia bancaria 
        {
            if (saq(transfer))
            {

                loan_Banking.deposit(transfer);

            }

        }








        public override string ToString()
        {

            StringBuilder display = new StringBuilder();
            display.Append("\nSaldo: ");

            display.Append(Balance.ToString("F2", CultureInfo.InvariantCulture));
            display.Append("\nCredito: ");

            display.Append(Credity.ToString("F2", CultureInfo.InvariantCulture));

            display.Append("\nDevedor: ");
            display.Append(Debtor.ToString("F2", CultureInfo.InvariantCulture));

            return display.ToString();



        }

    }
}


