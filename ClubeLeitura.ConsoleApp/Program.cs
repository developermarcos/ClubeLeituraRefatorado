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
using System;

namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal();

            TelaCadastroCaixa telaCadastroCaixa = new TelaCadastroCaixa();
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            repositorioCaixa.caixas = new Caixa[10];
            telaCadastroCaixa.repositorioCaixa = repositorioCaixa;

            ViewAmigo viewAmigo = new ViewAmigo();
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            repositorioAmigo.amigos = new Amigo[10];
            viewAmigo.repositorioAmigo = repositorioAmigo;

            

            Notificador notificador = new Notificador();
            telaCadastroCaixa.notificador = notificador;
            viewAmigo.notificador = notificador;


            while (true)
            {                
                string opcaoMenuPrincipal = menuPrincipal.MostrarOpcoes();

                if (opcaoMenuPrincipal == "1")
                {
                    string opcao = telaCadastroCaixa.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroCaixa.InserirNovaCaixa();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroCaixa.EditarCaixa();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroCaixa.ExcluirCaixa();
                    }
                    else if (opcao == "4")
                    {
                        bool temCaixaCadastrada = telaCadastroCaixa.VisualizarCaixas("Tela");
                        if (temCaixaCadastrada == false)
                        {
                            notificador.ApresentarMensagem("Nenhuma caixa cadastrada", "Atencao");
                        }
                        Console.ReadLine(); 
                    }
                }
                else if (opcaoMenuPrincipal == "3")
                {
                    string opcao = viewAmigo.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        viewAmigo.InserirNovoAmigo();
                    }
                    else if (opcao == "2")
                    {
                        viewAmigo.EditarAmigo();
                    }
                    else if (opcao == "3")
                    {
                        viewAmigo.ExcluirAmigo();
                    }
                    else if (opcao == "4")
                    {
                        bool temAmigoCadastrado = viewAmigo.VisualizarAmigos("Tela");
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
