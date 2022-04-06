using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloCategoriaRevista;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.ModuloReserva;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class TelaMenuPrincipal
    {
        private Notificador notificador;
        private string opcaoSelecionada;

        private const int QUANTIDADE_REGISTROS = 10;

        #region Declaração telas e repositórios
        //CAIXAS
        private RepositorioCaixa repositorioCaixa;

        private TelaCaixa telaCaixa;

        // CATEGORIAS
        private RepositorioCategoriaRevista repositorioCategoriaRevista;

        private TelaCategoriaRevista telaCategoriaRevista;

        // REVISTAS
        private RepositorioRevista repositorioRevista;

        private TelaRevista telaRevista;

        // AMIGOS
        private RepositorioAmigo repositorioAmigo;
        private TelaAmigo telaAmigo;

        // EMPRÉSTIMOS
        private RepositorioEmprestimo repositorioEmprestimo;

        private TelaEmprestimo telaEmprestimo;

        // RESERVAS
        private RepositorioReserva repositorioReserva;

        private TelaReserva telaReserva;
        #endregion

        public TelaMenuPrincipal(Notificador notificador)
        {
            this.notificador = notificador;

            repositorioCaixa = new RepositorioCaixa(QUANTIDADE_REGISTROS);
            telaCaixa = new TelaCaixa(repositorioCaixa, notificador);
            repositorioCategoriaRevista = new RepositorioCategoriaRevista(QUANTIDADE_REGISTROS);
            telaCategoriaRevista = new TelaCategoriaRevista(repositorioCategoriaRevista, notificador);
            repositorioRevista = new RepositorioRevista(QUANTIDADE_REGISTROS);

            telaRevista = new TelaRevista(
                telaCategoriaRevista,
                repositorioCategoriaRevista,
                telaCaixa,
                repositorioCaixa,
                repositorioRevista,
                notificador
            );

            repositorioAmigo = new RepositorioAmigo(QUANTIDADE_REGISTROS);
            telaAmigo = new TelaAmigo(repositorioAmigo, notificador);
            repositorioEmprestimo = new RepositorioEmprestimo(QUANTIDADE_REGISTROS);

            telaEmprestimo = new TelaEmprestimo(
                notificador,
                repositorioEmprestimo,
                repositorioRevista,
                repositorioAmigo,
                telaRevista,
                telaAmigo
            );

            repositorioReserva = new RepositorioReserva(QUANTIDADE_REGISTROS);

            telaReserva = new TelaReserva(
                notificador,
                repositorioReserva,
                repositorioAmigo,
                repositorioRevista,
                telaAmigo,
                telaRevista,
                repositorioEmprestimo
            );
        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Clube da Leitura 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Cadastrar Caixas");
            Console.WriteLine("Digite 2 para Cadastrar Amigos");
            Console.WriteLine("Digite 3 para Cadastrar Amiguinhos");
            Console.WriteLine("Digite 4 para Gerenciar Categorias");
            Console.WriteLine("Digite 5 para Gerenciar Categorias");
            Console.WriteLine("Digite 6 para Gerenciar Reservas");

            Console.WriteLine("Digite s para sair");

            opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public TelaBase ObterTela()
        {
            string opcao = MostrarOpcoes();

            TelaBase tela = null;

            if (opcao == "1")
                tela = telaCaixa;

            else if (opcao == "2")
                tela = telaAmigo;

            else if (opcao == "3")
                tela = telaRevista;

            else if (opcao == "4")
                tela = telaCategoriaRevista;

            else if (opcao == "5")
                tela = telaEmprestimo;

            else if (opcao == "6")
                tela = telaReserva;

            return tela;
        }

    }
}