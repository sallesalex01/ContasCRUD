using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATcsharp.Utils;

namespace ATcsharp {
    internal class CRUD {
        public static void IncluirConta(List<Conta> contas) {
            try {
                int id = GetNumeroConta(contas);
                string nome = ValidarNome();
                double saldo = ValidarSaldoInicial();

                contas.Add(new Conta(id, nome, saldo));
                Console.WriteLine("Conta adicionada com sucesso.");

            } catch (Exception e) { 
                Console.WriteLine("Erro ao cadastrar a conta: " + e.ToString());
            }
   
        }

        public static void AlterarSaldo(List<Conta> contas) {
            try {
                if (contas.Count == 0) {
                    Console.WriteLine("Nenhuma conta cadastrada.");
                    return;
                }

                int id = ValidarIdConta();

                Conta conta = EncontrarContaPorId(contas, id);

                if (conta == null) {
                    Console.WriteLine("Nenhuma conta encontrada");
                } else {
                    AlterarSaldoDaConta(conta);
                }

            } catch (Exception e) {
                Console.WriteLine("Erro ao alterar o saldo: " + e.ToString());
            }
        }

        public static void ExcluirConta(List<Conta> contas) {
            try {
                if (contas.Count == 0) {
                    Console.WriteLine("Nenhuma conta cadastrada");
                    return;
                }

                int id = ValidarIdConta();
                Conta conta = EncontrarContaPorId(contas, id);

                if (conta == null) {
                    Console.WriteLine("Nenhuma conta encontrada");
                    return;
                }

                if (conta.Saldo != 0) {
                    Console.WriteLine("Não é possível deletar uma conta com saldo maior que zero");
                } else {
                    contas.Remove(conta);
                    Console.WriteLine("Conta Excluida com sucesso");
                }

            } catch (Exception e) {
                Console.WriteLine("Algo deu errado ao excluir a conta" + e.ToString());
            }
            
        }

        public static void RelatoriosGerenciais(List<Conta> contas) {
            try {
                if (contas.Count == 0) {
                    Console.WriteLine("Nenhuma conta cadastrada.");
                    return;
                }

                MenuRelatorios();

                if (int.TryParse(Console.ReadLine(), out int opcao)) {
                    switch (opcao) {
                        case 1:
                            ListarTodasAsContas(contas);
                            break;
                        case 2:
                            ListarClientesComSaldoAcimaDeUmValor(contas);
                            break;
                        case 3:
                            ListarClientesComSaldoNegativo(contas);
                            break;
                    }
                } else {
                    Console.WriteLine("Opção inválida.");
                }

            } catch(Exception e) {
                Console.WriteLine("Erro ao gerar relatorios: " + e.ToString());
            }
        }
    }
}
