using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeLeitura.ConsoleApp
{
    public abstract class TelaBase
    {
        protected string titulo;
        public TelaBase(string titulo)
        {
            this.titulo = titulo;
        }
        public virtual string MostrarOpcoes()
        {
            string opcaoSelecionada;

            MostrarTitulo(this.titulo);

            Console.WriteLine("Digite 1 para Cadastrar Caixas");
            Console.WriteLine("Digite 2 para Cadastrar Revistinhas");
            Console.WriteLine("Digite 3 para Cadastrar Amiguinhos");
            Console.WriteLine("Digite 4 para Gerenciar Empréstimos");
            Console.WriteLine("Digite 5 para Gerenciar Categorias");
            Console.WriteLine("Digite 6 para Gerenciar Reservas");

            Console.WriteLine("Digite s para sair");

            opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        protected void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }
    }
}