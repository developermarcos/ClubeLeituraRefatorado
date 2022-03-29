﻿using System;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa
    {
        public Caixa[] caixas;
        public static int numeroCaixa;

        public void Inserir(Caixa caixa)
        {
            caixa.Numero = ObterNumeroCaixa();

            int posicaoVazia = ObterPosicaoVazia();
            caixas[posicaoVazia] = caixa;
        }

        public void Editar(int numeroSelecioando, Caixa caixa)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].Numero == numeroSelecioando)
                {
                    caixa.Numero = numeroSelecioando;
                    caixas[i] = caixa;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].Numero == numeroSelecionado)
                {
                    caixas[i] = null;
                    break;
                }
            }
        }

        public bool EtiquetaJaUtilizada(string etiquetaInformada)
        {
            bool etiquetaJaUtilizada = false;
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].Etiqueta == etiquetaInformada)
                {
                    etiquetaJaUtilizada = true;
                    break;
                }
            }

            return etiquetaJaUtilizada;
        }

        public bool VerificarNumeroCaixaExiste(int numeroCaixa)
        {
            bool numeroCaixaEncontrado = false;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].Numero == numeroCaixa)
                {
                    numeroCaixaEncontrado = true;
                    break;
                }
            }

            return numeroCaixaEncontrado;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null)
                    return i;
            }

            return -1;
        }

        public Caixa[] SelecionarTodos()
        {
            int quantidadeCaixas = ObterQtdCaixas();

            Caixa[] caixasInseridas = new Caixa[quantidadeCaixas];
            int j = 0;
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                {
                    caixasInseridas[j] = caixas[i];
                    j++;
                }            
            }

            return caixasInseridas;
        }

        public int ObterQtdCaixas()
        {
            int numeroCaixas = 0;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                    numeroCaixas++;
            }

            return numeroCaixas;
        }

        public Caixa ObterCaixa(int numeroCaixa)
        {
            Caixa caixa = null;

            for (int i = 0; i < caixas.Length; i++)
            {
                if(caixas[i] != null && caixas[i].Numero == numeroCaixa)
                {
                    caixa = caixas[i];
                    break;
                }
            }

            return caixa;
        }

        public void PopularCaixa(string cor, string etiqueta)
        {
            Caixa caixaPopularArray = new Caixa(cor, etiqueta);
            Inserir(caixaPopularArray);
        }

        public int ObterNumeroCaixa()
        {
            return ++numeroCaixa;
        }
    }
}
