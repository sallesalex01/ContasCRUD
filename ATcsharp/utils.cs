using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATcsharp {
    public class Utils {

        public static void Menu() {

            Console.WriteLine("Bem vindo! selecione uma das opções a baixo");
            Console.WriteLine("1 - Incluir conta");
            Console.WriteLine("2 - Alterar saldo");
            Console.WriteLine("3 - Excluir conta");
            Console.WriteLine("4 - Relatorios Gerenciais");
            Console.WriteLine("5 - Sair do programa");
        }

        public static void MenuRelatorios() {
            Console.WriteLine("Relatórios Gerenciais:");
            Console.WriteLine("1 - Listar todas as contas");
            Console.WriteLine("2 - Listar clientes com saldo acima de um valor");
            Console.WriteLine("3 - Listar clientes com saldo negativo");
        }

        //Id
        public static int ValidarIdConta() {
            int id;
            while (true) {
                Console.WriteLine("Número da conta: ");
                if (!int.TryParse(Console.ReadLine(), out id) || id <= 0) {
                    Console.WriteLine("Número da conta invalido, tente novamente");
                } else {
                    return id;
                }
            }
        }

        public static int GetNumeroConta(List<Conta> contas) {
            int id;
            while (true) {
                id = ValidarIdConta();

                if (contas.Any(c => c.Id == id)) {
                    Console.WriteLine("Já existe uma conta com este número. Tente novamente.");
                } else {
                    return id;
                }
            }
        }

        //Nome 

        public static string ValidarNome() {
            string nome;
            while (true) {
                Console.Write("Nome e sobrenome: ");
                nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome) || nome.Split(' ').Length < 2) {
                    Console.WriteLine("Deve conter pelo menos nome e sobrenome. Tente novamente.");
                } else {
                    return nome;
                }
            }
        }

        // Conta

        public static double ValidarSaldoInicial() {
            double saldo;
            while (true) {
                Console.Write("Saldo Inicial: ");
                if (!double.TryParse(Console.ReadLine(), out saldo) || saldo < 0) {
                    Console.WriteLine("Saldo inválido. Tente novamente.");
                } else {
                    return saldo;
                }
            }
        }

        public static double ValidarSaldoMinimo() {
            double saldoMinimo;
            while (true) {
                Console.Write("Saldo minimo: ");
                if (!double.TryParse(Console.ReadLine(), out saldoMinimo) || saldoMinimo < 0) {
                    Console.WriteLine("Saldo inválido. Tente novamente.");
                } else {
                    return saldoMinimo;
                }
            }
        }

        public static Conta EncontrarContaPorId(List<Conta> contas, int id) {
            Conta conta = contas.FirstOrDefault(c => c.Id == id);

            if (conta == null) {
                Console.WriteLine("Conta nao encontrada");
            }

            return conta;
        }

        public static double PedirValor() {
            while (true) {
                Console.Write("Valor para crédito/débito: ");
                if (!double.TryParse(Console.ReadLine(), out double valor) || valor <= 0) {
                    Console.WriteLine("Valor inválido, tente novamente.");
                } else {
                    return valor;
                }
            }
        }

        public static int EscolherOpcao() {
            while (true) {
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1 - Creditar");
                Console.WriteLine("2- Debitar");

                if (!int.TryParse(Console.ReadLine(), out int opcao)) {
                    Console.WriteLine("Opção inválida, tente novamente.");
                } else if (opcao < 1 || opcao > 2) {
                    Console.WriteLine("Escolha uma opção somente entre 1 e 2");
                } else {
                    return opcao;
                }
            }
        }

        public static void AlterarSaldoDaConta(Conta conta) {
            int opcao = EscolherOpcao();

            switch (opcao) {
                case 1:
                    double valorCredito = PedirValor();
                    conta.Creditar(valorCredito);
                    Console.WriteLine("Credito realizado com sucesso");
                    break;
                case 2:
                    double valorDebito = PedirValor();
                    conta.Debitar(valorDebito);
                    Console.WriteLine("Debito realizado com sucesso");
                    break;
            }
        }

        //Relatorios conta

        public static void ListarTodasAsContas(List<Conta> contas) {
            Console.WriteLine("Contas: ");
            foreach (var conta in contas) {
                Console.WriteLine($"{conta}\n");
            }
        }

        public static void ListarClientesComSaldoAcimaDeUmValor(List<Conta> contas) {

            double saldoMinimo = ValidarSaldoMinimo();

            var clientesComSaldoAcimaDoValor = contas.Where(c => c.Saldo >= saldoMinimo).ToList();

            if (clientesComSaldoAcimaDoValor.Count > 0) {
                Console.WriteLine($"Contas com saldo acima de {saldoMinimo}:");

                foreach (var cliente in clientesComSaldoAcimaDoValor) {
                    Console.WriteLine($"{cliente}\n");
                }
            } else {
                Console.WriteLine($"Nenhuma conta com saldo acima de {saldoMinimo} encontrada.");
            }
        }

        public static void ListarClientesComSaldoNegativo(List<Conta> contas) {
            var clientesComSaldoNegativo = contas.Where(c => c.Saldo < 0).ToList();

            if (clientesComSaldoNegativo.Count > 0) {
                Console.WriteLine("Contas com saldo negativo:");

                foreach (var cliente in clientesComSaldoNegativo) {
                    Console.WriteLine($"{cliente}\n");
                }
            } else {
                Console.WriteLine("Nenhuma conta com saldo negativo encontrada");
            }
        }

    }
}

