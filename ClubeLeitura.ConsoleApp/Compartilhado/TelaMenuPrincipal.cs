using System;

namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class TelaMenuPrincipal : TelaBase
    {
        private string opcaoSelecionada;

        public override string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Clube da Leitura 1.0");

            Console.WriteLine();

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

    }
}