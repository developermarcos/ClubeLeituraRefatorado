using ClubeLeitura.ConsoleApp.ModuloEmprestimos;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloMulta
{
    public class Multa
    {
        public int numero;
        private decimal _valor;
        public readonly Emprestimo emprestimo;
        private decimal valorBaseMulta = 1.50m;
        public bool fechada;

        public Multa(Emprestimo emprestimoDevolucao)
        {
            this.emprestimo=emprestimoDevolucao;
            this._valor = CalculaValorMulta();
        }
        public decimal Valor { get { return _valor; } }

        public override string ToString()
        {
            string status = this.fechada == true ? "Fechada" : "Aberta";
            string mensagem = $"Numero: {this.numero} | Valor: {this._valor} | Numero emprestimo: {this.emprestimo.numero} | Amigo: {this.emprestimo.amigo.Nome} | Status: {status}";
            return mensagem;
        }

        private decimal CalculaValorMulta()
        {
            int diferencaDias = (int)DateTime.Now.Subtract(this.emprestimo.DataDevolucao).TotalDays;
            
            return (Convert.ToDecimal(diferencaDias) * this.valorBaseMulta);
        }
    }
}
