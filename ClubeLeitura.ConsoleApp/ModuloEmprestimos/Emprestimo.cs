using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimos
{
    internal class Emprestimo
    {
        private int _numero;
        private Amigo _amigo;
        private Revista _revista;
        private DateTime _emprestimoData;

        public Emprestimo(Amigo amigo, Revista revista, DateTime data)
        {
            this._amigo = amigo;
            this._revista = revista;
            this._emprestimoData = data;
        }
        public int Numero { get { return _numero; } set { _numero = value; } }

        public Amigo Amigo { get { return _amigo; } }

        public Revista Revista { get { return _revista;  } }

        public DateTime EmprestimoData { get { return _emprestimoData; } }
    }
}
