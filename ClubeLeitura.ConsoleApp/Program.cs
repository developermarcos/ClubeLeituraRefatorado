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

            RepositorioRevista repositorioRevista = new RepositorioRevista(new Revista[10]);
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, telaCaixa, notificador);

            RepositorioEmprestimo RepositorioEmprestimo = new RepositorioEmprestimo(new Emprestimo[10]);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(RepositorioEmprestimo, telaAmigo, telaRevista, notificador);
            
            RepositorioCategoriaRevista repositorioCategoriaRevista = new RepositorioCategoriaRevista(new CategoriaRevista[10]);
            TelaCategoriaRevista telaCategoriaRevista = new TelaCategoriaRevista(telaRevista, repositorioCategoriaRevista, notificador);

            RepositorioReserva repositorioReserva = new RepositorioReserva(new Reserva[10]);
            TelaReserva telaReserva = new TelaReserva(repositorioReserva, telaAmigo, telaRevista, telaEmprestimo, notificador);

            #region Popular arrays
            repositorioAmigo.PopularAmigos("homem", "mae", "132456", "rua 1");
            repositorioAmigo.PopularAmigos("mulher", "mae", "007007", "rua 2");

            repositorioCaixa.PopularCaixa("preta", "123abc");
            repositorioCaixa.PopularCaixa("branca", "ddd007");

            Caixa caixa1 = repositorioCaixa.ObterCaixa(1);
            Caixa caixa2 = repositorioCaixa.ObterCaixa(2);
            telaRevista.repositorioRevista.PopularRevistas("teste 1", "123abc", "2019", caixa1);
            telaRevista.repositorioRevista.PopularRevistas("teste 2", "456cba", "2021", caixa2);
            #endregion


            while (true)
            {                
                string opcaoMenuPrincipal = menuPrincipal.MostrarOpcoes();

                if (opcaoMenuPrincipal == "1") // Caixas
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
                    }
                } // Caixas
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
                    }
                } // Categorias revistas
            }
        }       
    }
}
