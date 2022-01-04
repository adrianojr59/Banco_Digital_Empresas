using Curso.Entities;
using System.Linq;

UserPhysical physical = new UserPhysical(); // todos cadastro  CPF
UserBusiness business = new UserBusiness(); // todos cadastro CNPJ

Banking banking = new Banking(); // criando um novo objeto tipo banking

List<UserPhysical> ListClient = new List<UserPhysical>(); // lista cliente CPF (obs use para acessar o CNPJ boas praticas )

List<UserBusiness> ListUserBusiness = new List<UserBusiness>(); // lista cliente CNPJ  (obs: foram feito herança  não a necessidade de acessar  por aqui)

List<UserAddress> ListUserAddress2 = new List<UserAddress>(); // lista endereço exemplo adicionar mais endereços

List<Tel> TelList = new List<Tel>(); //lista telefone exemplo adicionar mais telefones

List<Banking> ListBanking = new List<Banking>(); //lista banco exemplo historico de transferencia





Cliente();

void Cliente()
{


    string option;
    do
    {


        Console.WriteLine("1- Historico da Conta ");
        Console.WriteLine("2- Inserir nova conta");
        Console.WriteLine("3- Transferir");
        Console.WriteLine("4- Emprestimo Credito: ");
        Console.WriteLine("5- Pagar Emprestimo");
        Console.WriteLine("6- Depositar");
        Console.WriteLine("7- Sacar");

        Console.WriteLine("X- Sair");
        option = Console.ReadLine();


        switch (option)
        {
            case "1":
                historic();
                break;

            case "2":
                cadastro();

                break;

            case "3":
                Transferir();
                break;

            case "4":
                SaqCredito();
                break;


            case "5":
                Deposit();
                break;

            case "6":
                DepositCredito();
                break;
            case "7":
                sacar();

                break;
            default:
                Console.WriteLine("Comando Invalido ! ");

                break;


        }

    }

    while (option.ToUpper() != "X");

}
void cadastro()
{




    Console.WriteLine("Nome: ");
    string Name = Console.ReadLine();

    Console.WriteLine("Cpf: ");
    string Cpf = Console.ReadLine();

    Console.WriteLine("Cidade: ");
    string city = Console.ReadLine();

    Console.WriteLine("Estado: ");
    string state = Console.ReadLine();

    Console.WriteLine("Rua: ");
    string street = Console.ReadLine();

    Console.WriteLine("Documento: ");
    string document = Console.ReadLine();

    Console.WriteLine("Data Nascimento: Exemplo 30/12/2000 ");
    string birthdate = Console.ReadLine();

    Console.WriteLine("Telefone: ");
    string tel = Console.ReadLine();

    Console.WriteLine("Email: ");
    string email = Console.ReadLine();




    //calculo de idade inicio
    DateTime Year = DateTime.Now;

    int year = (int)Year.Year;// ano atual // convertendo para string data atual exemplo  30/12/2021 e convertendo para tipo inteiro somente o  ano  ( 2021 )
    int yearnasciment = int.Parse(birthdate.Substring(6, 4)); // ano de nascimento
    int age = year - yearnasciment;

    //fim calculo de idade 

    Console.WriteLine("Nivel De Acesso ");
    Console.WriteLine(" (1) - Admin (2) - Suporte (3) Usuario ");
    string TypeAcess = Console.ReadLine();
    TypeofAcess typeofAcess = Enum.Parse<TypeofAcess>(TypeAcess); // tipo de nivel de acesso 


    Console.WriteLine("Ativação Da Conta ");
    Console.WriteLine("(1) - Desabilitada (2) - Habilitada ");
    string permissionaccount = Console.ReadLine();

    LoanCard loanCardBanking = Enum.Parse<LoanCard>(permissionaccount);// ativação da conta





    UserAddress Address = new UserAddress(city, state, street); // endereço
    ListUserAddress2.Add(Address); // adicionando a lista 


    Tel telephon = new Tel(tel); // telefone 
    TelList.Add(telephon); // adicionando a lista 










    Console.WriteLine("(1)-Pessoa_Fisica , (2)-Pessoa_Juridica");
    Console.WriteLine("Selecionar: ");
    string select = Console.ReadLine();
    TypeAccount typeAccount = Enum.Parse<TypeAccount>(select); // tipo de conta 
    string config = typeAccount.ToString();


    string selectphysical = " ", selectbusiness = " ";


    if (config == "Pessoa_Juridica")
    {

        Console.WriteLine("(1) - Conta_Corrente\n(2) - Conta_Digital\n(3) - Conta_Salario\n(4) - Conta_Universitaria\n(5) - Conta_Poupança");
        selectbusiness = Console.ReadLine();
        selectphysical = "0";// disable default
    }

    else if (config == "Pessoa_Fisica")
    {

        Console.WriteLine("(1) - Conta_Corrente\n(2) - Conta_Digital\n(3) - Conta_Universitaria\n(4) - Conta_Poupança");
        selectphysical = Console.ReadLine();
        selectbusiness = "0";// disable default

    }


    Console.WriteLine("Depositar: ");
    double deposit = double.Parse(Console.ReadLine());
    double debtor = 00.00F;
    double credity = 00.00F;

    Banking banking = new Banking(credity, debtor);


    banking.deposit(deposit);
    ListBanking.Add(banking);



    AccountPhysical accountPhysical = Enum.Parse<AccountPhysical>(selectphysical); // Conta Fisica 
    AccountBusiness accountBusiness = Enum.Parse<AccountBusiness>(selectbusiness); // Conta Juridica


    if (config == "Pessoa_Fisica")
    {


        UserPhysical physical = new UserPhysical(Name, Cpf, Address, document, birthdate, age, email, banking, loanCardBanking, DateTime.Now, typeAccount, accountPhysical, typeofAcess, tel); // todos cadastro  CPF
        ListClient.Add(physical);// adicionando a lista 


    }

    else
    {

        UserBusiness business = new UserBusiness(Name, Cpf, Address, document, birthdate, age, email, banking, loanCardBanking, DateTime.Now, typeAccount, accountPhysical, typeofAcess, tel); // todos cadastro   CNPJ
        ListUserBusiness.Add(business); // adicionando a lista 

    }



}


void historic()
{
    Console.WriteLine("Confirme Seu CPF: ");
    string Consult = Console.ReadLine();

    if (Consult.Length <= 11)
    {

        var cpf = ListClient.OrderBy(c => c.typeAccount.ToString() == "Pessoa_Fisica").ThenByDescending(c => c.Cpf == Consult);



        foreach (var Cpf in cpf)
        {

            Console.WriteLine(Cpf);  // resultado dados do cliente 

        }


    }


    var cnpj = ListUserBusiness.OrderBy(c => c.typeAccount.ToString() == "Pessoa_Juridica").ThenByDescending(c => c.Cpf == Consult);


    foreach (var Cnpj in cnpj)
    {

        Console.WriteLine(Cnpj);  // resultado dados do cliente 
    }

}


void Transferir()
{
    Console.WriteLine("Confirme Seu CPF: ");
    string Consult = Console.ReadLine();

    Console.WriteLine("Digite o Valor Do Saldo A Transferir ");
    double Balance = double.Parse(Console.ReadLine());

    Console.WriteLine("Digite o CPF para o Destino: ");
    string Received = Console.ReadLine();

    var target = ListClient.First(x => x.Cpf == Consult);

    var destiny = ListClient.First(x => x.Cpf == Received);

    target.Banking.transfer(Balance, destiny.Banking);

}


void SaqCredito()
{

    Console.WriteLine("Confirme Seu CPF: ");
    string Consult = Console.ReadLine();

    Console.WriteLine("Sacar Emprestimo ");
    double debtor = double.Parse(Console.ReadLine());


    var target = ListClient.First(x => x.Cpf == Consult);

    target.Banking.loan(debtor, target.Banking);

}



void Deposit()
{



    Console.WriteLine("Confirme Seu CPF: ");
    string Consult = Console.ReadLine();

    Console.WriteLine("Depositar ");
    double deposit = double.Parse(Console.ReadLine());

    var target = ListClient.First(x => x.Cpf == Consult);
    target.Banking.deposit(deposit);

}


void DepositCredito()
{

    // para acessar o deposito de credito  de business precisa de uma condição antes do jeito que esta
    // esta acessando a class physical 

    Console.WriteLine("Digite Seu CPF: ");
    string cpf = Console.ReadLine();

    Console.WriteLine("Valor a Pagar: ");
    double Value = double.Parse(Console.ReadLine());

    var DepositCredit = ListClient.First(x => x.Cpf == cpf);

    DepositCredit.Banking.loanpay(Value);


}



void sacar()
{

    Console.WriteLine("Digite Seu Cpf");
    string cpf = Console.ReadLine();

    Console.WriteLine("Valor do saque ");
    double Valor = double.Parse(Console.ReadLine());

    var Cpf = ListClient.First(x => x.Cpf == cpf);

    Cpf.Banking.saq(Valor);

}