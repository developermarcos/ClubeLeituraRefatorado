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

            Console.WriteLine("Digite 1 para Cadastrar");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

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