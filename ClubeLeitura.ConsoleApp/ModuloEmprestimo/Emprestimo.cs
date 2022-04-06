using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo : EntidadeBase
    {
        public readonly Amigo amigo;
        public readonly Revista revista;
        public readonly DateTime emprestimoData;
        private DateTime _dataDevolucao;
        public bool devolucao;
        public Emprestimo(Amigo amigo, Revista revista, DateTime data)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.emprestimoData = data;
            this.DataDevolucao = data;
            this.devolucao = false;
        }
        
        public DateTime DataDevolucao { 
            get { return _dataDevolucao;} 
            private set 
            {
                int diasParaEmprestimo = this.revista.categoria.quantidadeDiasParaEmprestimo + 1;
                this._dataDevolucao = value.AddDays(diasParaEmprestimo);
            } 
        }

        public override string ToString()
        {
            string status = this.devolucao == false ? "Emprestado" : "Devolvido";
            string mensagem = $"Numero: {this.numero} | Data empréstimo: {this.emprestimoData.ToString("dd/MM/yyyy")} | Data devolução: {this.DataDevolucao.ToString("dd/MM/yyyy")} | Status: {status}";
            return mensagem;
        }

        public override void Validar()
        {

        }
    }
}
