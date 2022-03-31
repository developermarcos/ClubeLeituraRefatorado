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
using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using ClubeLeitura.ConsoleApp.ModuloEmprestimos;
using System;
using ClubeLeitura.ConsoleApp.ModuloCategoriaRevista;
using ClubeLeitura.ConsoleApp.ModeloReserva;
using ClubeLeitura.ConsoleApp.ModuloMulta;

namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal();

            Notificador notificador = new Notificador();

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa(new Caixa[10]);
            TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa, notificador);

            RepositorioAmigo repositorioAmigo = new RepositorioAmigo(new Amigo[10]);
            TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo, notificador);

            RepositorioCategoriaRevista repositorioCategoriaRevista = new RepositorioCategoriaRevista(new CategoriaRevista[10]);
            TelaCategoriaRevista telaCategoriaRevista = new TelaCategoriaRevista(repositorioCategoriaRevista, notificador);

            RepositorioRevista repositorioRevista = new RepositorioRevista(new Revista[10]);
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, telaCaixa, telaCategoriaRevista, notificador);

            RepositorioEmprestimo RepositorioEmprestimo = new RepositorioEmprestimo(new Emprestimo[10]);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(RepositorioEmprestimo, telaAmigo, telaRevista, notificador);
            
            RepositorioReserva repositorioReserva = new RepositorioReserva(new Reserva[10]);
            TelaReserva telaReserva = new TelaReserva(repositorioReserva, telaAmigo, telaRevista, telaEmprestimo, notificador);

            RepositorioMulta repositorioMulta = new RepositorioMulta(new Multa[10]);
            TelaMulta telaMulta = new TelaMulta(repositorioMulta, telaAmigo);
            telaAmigo.telaMulta = telaMulta;
            telaAmigo.repositorioMulta = repositorioMulta;
            telaEmprestimo.repositorioMulta = repositorioMulta;

            #region Popular arrays
            repositorioAmigo.PopularAmigos("homem", "mae", "132456", "rua 1");
            repositorioAmigo.PopularAmigos("mulher", "mae", "007007", "rua 2");

            repositorioCaixa.PopularCaixa("preta", "123abc");
            repositorioCaixa.PopularCaixa("branca", "ddd007");

            repositorioCategoriaRevista.PopularCategoria("Categoria 1", 2);
            repositorioCategoriaRevista.PopularCategoria("Categoria 2", 3);

            Caixa caixa1 = repositorioCaixa.ObterCaixa(1);
            Caixa caixa2 = repositorioCaixa.ObterCaixa(2);
            CategoriaRevista cat1 = repositorioCategoriaRevista.ObterCategoria(1);
            CategoriaRevista cat2 = repositorioCategoriaRevista.ObterCategoria(2);
            telaRevista.repositorioRevista.PopularRevistas("teste 1", "123abc", "2019", caixa1, cat1);
            telaRevista.repositorioRevista.PopularRevistas("teste 2", "456cba", "2021", caixa2, cat2);
            #endregion


            while (true)
            {                
                string opcaoMenuPrincipal = menuPrincipal.MostrarOpcoes();

                if (opcaoMenuPrincipal == "1")
                {
                    string opcao = telaCaixa.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCaixa.InserirNovaCaixa();
                    }
                    else if (opcao == "2")
                    {
                        telaCaixa.EditarCaixa();
                    }
                    else if (opcao == "3")
                    {
                        telaCaixa.ExcluirCaixa();
                    }
                    else if (opcao == "4")
                    {
                        bool temCaixaCadastrada = telaCaixa.VisualizarCaixas("Tela");
                        if (temCaixaCadastrada == false)
                        {
                            notificador.ApresentarMensagem("Nenhuma caixa cadastrada", StatusValidacao.Atencao);
                        }
                        Console.ReadLine();
                    }
                } // amigos
                else if (opcaoMenuPrincipal == "2") // Revistas
                {
                    string opcao = telaRevista.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaRevista.InserirNovaRevista();
                    }
                    else if (opcao == "2")
                    {
                        telaRevista.EditarRevista();
                    }
                    else if (opcao == "3")
                    {
                        telaRevista.ExcluirRevista();
                    }
                    else if (opcao == "4")
                    {
                        bool temRevistaCadastrada = telaRevista.VisualizarRevistas("Tela");
                        if (temRevistaCadastrada == false)
                        {
                            notificador.ApresentarMensagem("Nenhuma revista cadastrada", StatusValidacao.Atencao);
                        }
                        Console.ReadLine();
                    }
                } // Revistas
                else if (opcaoMenuPrincipal == "3")
                {
                    string opcao = telaAmigo.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaAmigo.InserirNovoAmigo();
                    }
                    else if (opcao == "2")
                    {
                        telaAmigo.EditarAmigo();
                    }
                    else if (opcao == "3")
                    {
                        telaAmigo.ExcluirAmigo();
                    }
                    else if (opcao == "4")
                    {
                        bool temAmigoCadastrado = telaAmigo.VisualizarAmigos("Tela");
                        if (temAmigoCadastrado == false)
                        {
                            notificador.ApresentarMensagem("Nenhum amigo cadastrado", StatusValidacao.Atencao);
                        }
                        Console.ReadLine();
                    }
                    else if (opcao == "5")
                    {
                        telaAmigo.BaixarMulta();
                    }
                } // Amigos
                else if (opcaoMenuPrincipal == "4")
                {
                    string opcao = telaEmprestimo.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaEmprestimo.InserirNovoEmprestimo();
                    }
                    else if (opcao == "2")
                    {
                        telaEmprestimo.EditarEmprestimo();
                    }
                    else if (opcao == "3")
                    {
                        telaEmprestimo.ExcluirEmprestimo();
                    }
                    else if (opcao == "4")
                    {
                        bool temEmprestimoCadastrado = telaEmprestimo.VisualizarEmprestimos("Tela");
                        if (temEmprestimoCadastrado == false)
                        {
                            notificador.ApresentarMensagem("Nenhum emprestimo cadastrado", StatusValidacao.Atencao);
                        }
                        Console.ReadLine();
                    }
                    else if (opcao == "5")
                    {
                        telaEmprestimo.DevolucaoEmprestimo();
                    }
                } // Emprestimos
                else if (opcaoMenuPrincipal == "5") // Categoria revistas
                {
                    string opcao = telaCategoriaRevista.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCategoriaRevista.InserirNovaCategoria();
                    }
                    else if (opcao == "2")
                    {
                        telaCategoriaRevista.EditarCategoria();
                    }
                    else if (opcao == "3")
                    {
                        telaCategoriaRevista.ExcluirCategoria();
                    }
                    else if (opcao == "4")
                    {
                        bool temCategoriaRevistaCadastrada = telaCategoriaRevista.VisualizarCategorias("Tela");
                        if (temCategoriaRevistaCadastrada == false)
                        {
                            notificador.ApresentarMensagem("Nenhuma categoria cadastrada", StatusValidacao.Atencao);
                        }
                        Console.ReadLine();
                    }
                } // Categorias revistas
                else if (opcaoMenuPrincipal == "6") // Reservas
                {
                    string opcao = telaReserva.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaReserva.InserirNovaReserva();
                    }
                    else if (opcao == "2")
                    {
                        telaReserva.EditarReserva();
                    }
                    else if (opcao == "3")
                    {
                        telaReserva.ExcluirReserva();
                    }
                    else if (opcao == "4")
                    {
                        bool temReservaCadastrada = telaReserva.VisualizarReservas("Tela");
                        if (temReservaCadastrada == false)
                        {
                            notificador.ApresentarMensagem("Nenhuma reserva cadastrada", StatusValidacao.Atencao);
                        }
                        Console.ReadLine();
                    }
                    else if (opcao == "5")
                    {
                        telaReserva.EmprestimoApartirReserva();
                    }
                } // Categorias revistas
            }
        }       
    }
}
