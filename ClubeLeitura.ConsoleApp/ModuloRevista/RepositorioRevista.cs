﻿using ClubeLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista
    {
        public Revista[] revistas;
        public int numeroRevista;
        public void Inserir(Revista revista)
        {
            revista.numero = ++numeroRevista;

            int posicaoVazia = ObterPosicaoVazia();
            revistas[posicaoVazia] = revista;
        }

        public void Editar(int numeroSelecioando, Revista revista)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null && revistas[i].numero == numeroSelecioando)
                {
                    revista.numero = numeroSelecioando;
                    revistas[i] = revista;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null && revistas[i].numero == numeroSelecionado)
                {
                    revistas[i] = null;
                    break;
                }
            }
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null)
                    return i;
            }

            return -1;
        }

        public Revista[] SelecionarTodos()
        {
            int quantidadeRevistas = ObterQtdRevistas();

            Revista[] revistasInseridas = new Revista[quantidadeRevistas];
            int j = 0;
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null)
                {
                    revistasInseridas[j] = revistas[i];
                    j++;
                }
            }

            return revistasInseridas;
        }

        public int ObterQtdRevistas()
        {
            int numeroRevistas = 0;

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null)
                    numeroRevistas++;
            }

            return numeroRevistas;
        }

        public bool VerificarNumeroRevistaExiste(int numeroRevista)
        {
            bool numeroRevistaEncontrado = false;

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null && revistas[i].numero == numeroRevista)
                {
                    numeroRevistaEncontrado = true;
                    break;
                }
            }

            return numeroRevistaEncontrado;
        }

        public void PopularRevistas(string tipoColecao, string numeroEdicao, string ano, Caixa caixa)
        {
            Revista revista = new Revista();
            revista.tipoColecao = tipoColecao;
            revista.numeroEdicao = numeroEdicao;
            revista.ano = ano;
            revista.caixa = caixa;
            Inserir(revista);
        }
    }
}