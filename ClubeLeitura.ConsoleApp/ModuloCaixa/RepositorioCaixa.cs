using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa : RepositorioBase<Caixa>
    {
        #region métodos própios

        public void Popular(Caixa caixa)
        {
            Inserir(caixa);
        }

        public bool EtiquetaJaUtilizada(string etiquetaInformada)
        {
            if (registros == null)
                return false;

            for (int i = 0; i < registros.Count; i++)
            {
                Caixa c = (Caixa)registros[i];

                if (registros[i] != null && c.etiqueta == etiquetaInformada)
                    return true;
            }

            return false;
        }

        #endregion
    }
}
