﻿
using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCaixa
    {
        public int numeroCaixa; //controlar o número da caixas cadastradas
        public Notificador notificador; //reponsável pelas mensagens pro usuário
        public RepositorioCaixa repositorioCaixa;
        private Caixa[] caixas;

        public TelaCaixa(RepositorioCaixa repositorioCaixa, Notificador notificador)
        {
            this.repositorioCaixa=repositorioCaixa;
            this.notificador=notificador;
        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Caixas");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovaCaixa()
        {
            MostrarTitulo("Inserindo nova Caixa");

            Caixa novaCaixa = ObterCaixa();
           
            repositorioCaixa.Inserir(novaCaixa);

            notificador.ApresentarMensagem("Caixa inserida com sucesso!", StatusValidacao.Sucesso);
        }

        public void EditarCaixa()
        {
            MostrarTitulo("Editando Caixa");

            bool temCaixasCadastradas = VisualizarCaixas("Pesquisando");

            if (temCaixasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma caixa cadastrada para poder editar", StatusValidacao.Atencao);
                return;
            }

            int numeroCaixa = ObterNumeroCaixa();

            Caixa caixaAtualizada = ObterCaixa();

            repositorioCaixa.Editar(numeroCaixa, caixaAtualizada);

            notificador.ApresentarMensagem("Caixa editada com sucesso", StatusValidacao.Sucesso);
        }

        public int ObterNumeroCaixa()
        {
            int numeroCaixa;
            bool numeroCaixaEncontrado;

            do
            {
                Console.Write("Digite o número da caixa que deseja editar: ");
                numeroCaixa = Convert.ToInt32(Console.ReadLine());

                numeroCaixaEncontrado = repositorioCaixa.VerificarNumeroCaixaExiste(numeroCaixa);

                if (numeroCaixaEncontrado == false)
                    notificador.ApresentarMensagem("Número de caixa não encontrado, digite novamente", StatusValidacao.Atencao);

            } while (numeroCaixaEncontrado == false);
            return numeroCaixa;
        }

        public void ExcluirCaixa()
        {
            MostrarTitulo("Excluindo Caixa");

            bool temCaixasCadastradas = VisualizarCaixas("Pesquisando");

            if (temCaixasCadastradas == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhuma caixa cadastrada para poder excluir", StatusValidacao.Atencao);
                return;
            }

            int numeroCaixa = ObterNumeroCaixa();

            repositorioCaixa.Excluir(numeroCaixa);

            notificador.ApresentarMensagem("Caixa excluída com sucesso", StatusValidacao.Sucesso);
        }

        public bool VisualizarCaixas(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Caixas");

            Caixa[] caixas = repositorioCaixa.SelecionarTodos();

            if (caixas.Length == 0)
                return false;

            for (int i = 0; i < caixas.Length; i++)
            {              
                Caixa c = caixas[i];

                Console.WriteLine(c.ToString());
                
                Console.WriteLine();
            }

            return true;
        }

        #region métodos privados
        private Caixa ObterCaixa()
        {
            Console.Write("Digite a cor: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a etiqueta: ");
            string etiqueta = Console.ReadLine();

            bool etiquetaJaUtilizada;

            do
            {
                etiquetaJaUtilizada = repositorioCaixa.EtiquetaJaUtilizada(etiqueta);

                if (etiquetaJaUtilizada)
                {
                    notificador.ApresentarMensagem("Etiqueta já utilizada, por gentileza informe outra", StatusValidacao.Erro);

                    Console.Write("Digite a etiqueta: ");
                    etiqueta = Console.ReadLine();
                }

            } while (etiquetaJaUtilizada);

            Caixa caixa = new Caixa(cor, etiqueta);

            return caixa;
        }

        private void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }
        #endregion
    }
}