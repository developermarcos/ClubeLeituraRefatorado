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
        public int numero;
        public readonly string nome;
        public readonly int quantidadeDiasParaEmprestimo;

        public CategoriaRevista(string nome, int quantidade)
        {
            this.nome = nome;
            this.quantidadeDiasParaEmprestimo = quantidade;
        }

        public override string ToString()
        {
            string mensagem = $"Numero: {this.numero} | Nome: {this.nome} | Dias para empréstimo: {this.quantidadeDiasParaEmprestimo}";
            return mensagem;
        }
    }
}
