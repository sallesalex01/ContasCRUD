using static ATcsharp.Utils;
using static ATcsharp.Arquivo;
using static ATcsharp.CRUD;

namespace ATcsharp
{
    class Program {
        static void Main(string[] args) {
            List<Conta> contas = new List<Conta>();
            CarregarContas(contas);

            while(true) {
                Menu();

                int opcao;
                if( int.TryParse(Console.ReadLine(), out opcao) ) {
                    switch (opcao) {
                        case 1:
                            IncluirConta(contas);
                            break;
                        case 2:
                            AlterarSaldo(contas);
                            break;
                        case 3:
                            ExcluirConta(contas);
                            break;
                        case 4:
                            RelatoriosGerenciais(contas);
                            break;
                        case 5:
                            SalvarContas(contas);
                            return;
                    }
                } else {
                    Console.WriteLine("Opção invalida");
                }
            }
        }
    }
}