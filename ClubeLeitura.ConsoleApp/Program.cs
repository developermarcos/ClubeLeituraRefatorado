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
using ClubeLeitura.ConsoleApp.Compartilhado.Interfaces;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.ModuloReserva;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static Notificador notificador = new Notificador();
        static TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal(notificador);
        static void Main(string[] args)
        {
            while (true)
            {
                TelaBase telaSelecionada = menuPrincipal.ObterTela();

                string opcaoSelecionada = telaSelecionada.MostrarOpcoes();

                if (telaSelecionada is ICadastroBasico)
                    GerenciarCadastroBasico(telaSelecionada, opcaoSelecionada);

                else if (telaSelecionada is TelaEmprestimo)
                    GerenciarCadastroEmprestimos(telaSelecionada, opcaoSelecionada);

                else if (telaSelecionada is TelaReserva)
                    GerenciarCadastroReservas(telaSelecionada, opcaoSelecionada);
            }
        }

        private static void GerenciarCadastroReservas(TelaBase telaSelecionada, string opcaoSelecionada)
        {
            TelaReserva TelaReserva = (TelaReserva)telaSelecionada;

            //if (opcaoSelecionada == "1")
            //    TelaReserva.RegistrarNovaReserva();

            //else if (opcaoSelecionada == "2")
            //{
            //    bool temRegistros = TelaReserva.VisualizarReservas("Tela");

            //    if (!temRegistros)
            //        notificador.ApresentarMensagem("Não há nenhuma reserva cadastrada!", TipoMensagem.Atencao);
            //}
            //else if (opcaoSelecionada == "3")
            //{
            //    bool temRegistros = TelaReserva.VisualizarReservasEmAberto("Tela");

            //    if (!temRegistros)
            //        notificador.ApresentarMensagem("Não há nenhuma reserva em aberto!", TipoMensagem.Atencao);
            //}
            //else if (opcaoSelecionada == "4")
            //    TelaReserva.RegistrarNovoEmprestimo();
        }

        private static void GerenciarCadastroEmprestimos(TelaBase telaSelecionada, string opcaoSelecionada)
        {
            TelaEmprestimo TelaEmprestimo = (TelaEmprestimo)telaSelecionada;

            //if (opcaoSelecionada == "1")
            //    TelaEmprestimo.RegistrarEmprestimo();
            //else if (opcaoSelecionada == "2")
            //    TelaEmprestimo.EditarEmprestimo();
            //else if (opcaoSelecionada == "3")
            //    TelaEmprestimo.ExcluirEmprestimo();
            //else if (opcaoSelecionada == "4")
            //{
            //    bool temRegistros = TelaEmprestimo.VisualizarEmprestimos("Tela");

            //    if (!temRegistros)
            //        notificador.ApresentarMensagem("Não há nenhum empréstimo cadastrado!", TipoMensagem.Atencao);
            //}
            //else if (opcaoSelecionada == "5")
            //{
            //    bool temRegistros = TelaEmprestimo.VisualizarEmprestimosEmAberto("Tela");

            //    if (!temRegistros)
            //        notificador.ApresentarMensagem("Não há nenhum empréstimo em aberto!", TipoMensagem.Atencao);
            //}
            //else if (opcaoSelecionada == "6")
            //    TelaEmprestimo.RegistrarDevolucao();
        }

        public static void GerenciarCadastroBasico(TelaBase telaSelecionada, string opcaoSelecionada)
        {
            ICadastroBasico TelaBasico = (ICadastroBasico)telaSelecionada;

            if (opcaoSelecionada == "1")
                TelaBasico.InserirRegistro();

            else if (opcaoSelecionada == "2")
                TelaBasico.EditarRegistro();

            else if (opcaoSelecionada == "3")
                TelaBasico.ExcluirRegistro();

            else if (opcaoSelecionada == "4")
            {
                bool temRegistros = TelaBasico.VisualizarRegistros("Tela");

                if (!temRegistros)
                    notificador.ApresentarMensagem("Nenhum registro disponível!", TipoMensagem.Atencao);

                Console.ReadKey();
            }

            if (telaSelecionada is TelaAmigo)
            {
                TelaAmigo TelaAmigo = (TelaAmigo)telaSelecionada;

                if (opcaoSelecionada == "5")
                {
                    bool temRegistros = TelaAmigo.VisualizarAmigosComMulta("Tela");

                    if (!temRegistros)
                        notificador.ApresentarMensagem("Não há nenhum amigo com multa aberta.", TipoMensagem.Atencao);
                }

                else if (opcaoSelecionada == "6")
                    TelaAmigo.PagarMulta();
            }
        }
    }
}
