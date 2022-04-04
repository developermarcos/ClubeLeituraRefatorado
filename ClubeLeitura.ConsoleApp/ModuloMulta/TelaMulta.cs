/**
 * O sistema deve permirtir o usuário escolher qual opção ele deseja
 *  -Para acessar o cadastro de caixas, ele deve digitar "1"
 *  -Para acessar o cadastro de revistas, ele deve digitar "2"
 *  -Para acessar o cadastro de amigquinhos, ele deve digitar "3"
 *  
 *  -Para gerenciar emprestimos, ele deve digitar "4"
 *  
 *  -Para sair, usuário deve digitar "s"
 */
using ClubeLeitura.ConsoleApp.ModuloMulta;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using System;

namespace ClubeLeitura.ConsoleApp
{
    public class TelaMulta
    {
        private RepositorioMulta repositorioMulta;
        private TelaAmigo telaAmigo;
        public TelaMulta(RepositorioMulta repositorioMulta, TelaAmigo telaAmigo)
        {
            this.repositorioMulta=repositorioMulta;
            this.telaAmigo=telaAmigo;
        }

        public bool VisualizarMultas(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de multas");

            Multa[] multas = (Multa[])repositorioMulta.ObterTodosRegistros();

            if (multas.Length == 0)
                return false;

            for (int i = 0; i < multas.Length; i++)
            {
                Multa m = multas[i];

                Console.WriteLine();

                Console.WriteLine(m.ToString());

                Console.WriteLine();
            }

            return true;
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }
    }
}