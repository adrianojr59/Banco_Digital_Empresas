using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Entities
{
    enum AccountPhysical : int
    {
        CNPJ = 0,
        Conta_Corrente = 1,
        Conta_Digital = 2,
        Conta_Salario = 3,
        Conta_Universitaria = 4,
        Conta_Poupança = 5
    }
}
