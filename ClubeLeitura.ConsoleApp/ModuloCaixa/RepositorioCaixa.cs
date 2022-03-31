using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa : IRepositoryBase<Caixa>
    {
        public Caixa[] caixas;
        public static int numero;
        public RepositorioCaixa(Caixa[] caixas)
        {
            this.caixas=caixas;
        }

        public void Inserir(Caixa caixa)
        {
            
            caixa.numero = ObterNumeroRegistro();

            int posicaoVazia = ObterPosicaoVazia();
            
            caixas[posicaoVazia] = caixa;
        }

        public void Editar(int numeroSelecioando, Caixa caixa)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].numero == numeroSelecioando)
                {
                    caixa.numero = numeroSelecioando;
                    caixas[i] = caixa;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].numero == numeroSelecionado)
                {
                    caixas[i] = null;
                    break;
                }
            }
        }

        public bool ExisteNumeroRegistro(int numeroCaixa)
        {
            bool numeroCaixaEncontrado = false;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].numero == numeroCaixa)
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

        public int ObterQuantidadeRegistros()
        {
            int numeroCaixas = 0;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                    numeroCaixas++;
            }

            return numeroCaixas;
        }

        public Caixa[] ObterTodosRegistros()
        {
            int quantidadeCaixas = ObterQuantidadeRegistros();

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

        public Caixa ObterRegistro(int numeroCaixa)
        {
            Caixa caixa = null;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].numero == numeroCaixa)
                {
                    caixa = caixas[i];
                    break;
                }
            }

            return caixa;
        }

        #region métodos própios

        public void Popular(Caixa caixa)
        {
            Inserir(caixa);
        }

        public bool EtiquetaJaUtilizada(string etiquetaInformada)
        {
            bool etiquetaJaUtilizada = false;
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].etiqueta == etiquetaInformada)
                {
                    etiquetaJaUtilizada = true;
                    break;
                }
            }

            return etiquetaJaUtilizada;
        }

        #endregion

        #region métodos privados

        public int ObterNumeroRegistro() => ++numero;

        #endregion
    }
}
