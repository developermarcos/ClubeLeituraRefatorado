using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloCategoriaRevista
{
    public class CategoriaRevista
    {
        private int _numero;
        private string _nome;
        private int _quantidadeDiasParaEmprestimo;

        public CategoriaRevista(string nome, int quantidade)
        {
            this._nome = nome;
            this._quantidadeDiasParaEmprestimo = quantidade;
        }

        public int Numero { get { return this._numero; } set { this._numero = value; } }

        public string Nome { get { return _nome; } set { _nome = value; } }

        public int QuantidadeDiasParaEmprestimo { get { return _quantidadeDiasParaEmprestimo; } }

        public override string ToString()
        {
            string mensagem = $"Numero: {this.Numero} | Nome: {this.Nome} | Dias para empréstimo: {this.QuantidadeDiasParaEmprestimo}";
            return mensagem;
        }
    }
}
