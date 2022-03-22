﻿/**
 * O sistema deve permirtir o usuário escolher qual opção ele deseja
 *  -Para acessar o cadastro de caixas, ele deve digitar "1"
 *  -Para acessar o cadastro de revistas, ele deve digitar "2"
 *  -Para acessar o cadastro de amigquinhos, ele deve digitar "3"
 *  
 *  -Para gerenciar emprestimos, ele deve digitar "4"
 *  
 *  -Para sair, usuário deve digitar "s"
 */
using System;

namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal();
            
            TelaCadastroCaixa telaCadastroCaixa = new TelaCadastroCaixa();
            telaCadastroCaixa.caixas = new Caixa[10];
            telaCadastroCaixa.notificador = new Notificador();

            TelaCadastroAmigo telaCadastroPessoa = new TelaCadastroAmigo();
            telaCadastroPessoa.amigos = new Amigo[10];
            telaCadastroPessoa.notificador = new Notificador();

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
                        telaCadastroCaixa.VisualizarCaixas("Tela");
                        Console.ReadLine(); 
                    }
                }
                else if (opcaoMenuPrincipal == "3")
                {
                    string opcao = telaCadastroPessoa.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroPessoa.InserirNovaCaixa();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroPessoa.EditarCaixa();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroPessoa.ExcluirCaixa();
                    }
                    else if (opcao == "4")
                    {
                        telaCadastroPessoa.VisualizarCaixas("Tela");
                        Console.ReadLine();
                    }
                }
            }
        }       
    }
}
