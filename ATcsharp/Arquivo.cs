using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATcsharp {
    public class Arquivo {

        public static void CarregarContas(List<Conta> contas) {
            const string NOME_ARQ = "contas.csv";
            const string DIR = @"C:\Users\alexs\Downloads";
            string caminho = Path.Combine(DIR, NOME_ARQ);

            if (!File.Exists(caminho)) {
                Console.WriteLine("Erro: arquivo não existe");
                return;
            }

            try {
                using (var arquivo = new StreamReader(caminho)) {
                    string linha = arquivo.ReadLine();

                    while (linha != null) {
                        string[] campos = linha.Split(',');

                        if (campos.Length == 3 && int.TryParse(campos[0], out int id) && double.TryParse(campos[2], out double saldo)) {
                            contas.Add(new Conta(id, campos[1], saldo));
                        }

                        linha = arquivo.ReadLine();
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Erro ao carregar contas do arquivo: " + ex.Message);
            }
        }

        public static void SalvarContas(List<Conta> contas) {
            const String NOME_ARQ = "contas.csv";
            const String DIR = @"C:\Users\alexs\Downloads";
            string caminho = Path.Combine(DIR, NOME_ARQ);
            try {
                using (StreamWriter writer = new StreamWriter(caminho)) {
                    foreach (var conta in contas) {
                        writer.WriteLine($"{conta.Id}, {conta.Nome}, {conta.Saldo}");
                    }
                }
            } catch (IOException ex) {
                Console.WriteLine("Erro ao salvar contas no arquivo: " + ex.Message);
            }
        }
    }
}
