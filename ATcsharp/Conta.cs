using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATcsharp
{
    public class Conta : OperacoesConta {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }

        public Conta(int id, string nome, double saldo) {
            Id = id;
            Nome = nome;
            Saldo = saldo;
        }

        public void Creditar(double valor) {
            if (valor > 0) {
                Saldo += valor;
            } else {
                throw new Exception("Valor invalido para creditar");
            }
        }

        public void Debitar(double valor) {
            if (valor > 0 && valor < Saldo) {
                Saldo -= valor;
            } else {
                throw new Exception("Valor invalido para debitar ou saldo insuficiente");
            }
        }

        public override string ToString() {
            return $"Numero da conta: {Id}\nNome: {Nome}\nSaldo: {Saldo}";

        }
    }
}
