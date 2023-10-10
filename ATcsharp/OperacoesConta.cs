using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATcsharp
{
    interface OperacoesConta {
        void Creditar(double valor);
        void Debitar(double valor);
    }
}
