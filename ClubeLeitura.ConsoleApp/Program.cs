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
using System;

namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal();

            TelaCaixa telaCaixa = new TelaCaixa();
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            repositorioCaixa.caixas = new Caixa[10];
            telaCaixa.repositorioCaixa = repositorioCaixa;

            TelaAmigo telaAmigo = new TelaAmigo();
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            repositorioAmigo.amigos = new Amigo[10];
            telaAmigo.repositorioAmigo = repositorioAmigo;

            TelaRevista telaRevista = new TelaRevista();
            RepositorioRevista repositorioRevista = new RepositorioRevista();
            repositorioRevista.revistas = new Revista[10];
            telaRevista.repositorioRevista = repositorioRevista;
            telaRevista.telaCaixa = telaCaixa;
            telaRevista.repositorioCaixa = repositorioCaixa;

            #region Popular arrays
            telaCaixa.repositorioCaixa.PopularCaixa("preta", "123abc");
            telaCaixa.repositorioCaixa.PopularCaixa("branca", "ddd007");

            Caixa caixa1 = telaRevista.repositorioCaixa.ObterCaixa(1);
            Caixa caixa2 = telaRevista.repositorioCaixa.ObterCaixa(2);
            telaRevista.repositorioRevista.PopularRevistas("teste 1", "123abc", "2019", caixa1);
            telaRevista.repositorioRevista.PopularRevistas("teste 2", "456cba", "2021", caixa2);
            #endregion

            Notificador notificador = new Notificador();
            telaCaixa.notificador = notificador;
            telaAmigo.notificador = notificador;
            telaRevista.notificador = notificador;


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
                            notificador.ApresentarMensagem("Nenhuma caixa cadastrada", "Atencao");
                        }
                        Console.ReadLine(); 
                    }
                }
                else if (opcaoMenuPrincipal == "2")
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
                            notificador.ApresentarMensagem("Nenhuma revista cadastrada", "Atencao");
                        }
                        Console.ReadLine();
                    }
                }
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
                            notificador.ApresentarMensagem("Nenhum amigo cadastrado", "Atencao");
                        }
                        Console.ReadLine();
                    }
                }
            }
        }       
    }
}
