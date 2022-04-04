using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa : RepositorioBase<Caixa>
    {
        public RepositorioCaixa(int tamanhoArray) : base(tamanhoArray)
        {
            
        }

        #region métodos própios

        public void Popular(Caixa caixa)
        {
            Inserir(caixa);
        }

        public bool EtiquetaJaUtilizada(string etiquetaInformada)
        {
            bool etiquetaJaUtilizada = false;
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].etiqueta == etiquetaInformada)
                {
                    etiquetaJaUtilizada = true;
                    break;
                }
            }

            return etiquetaJaUtilizada;
        }

        #endregion
    }
}
