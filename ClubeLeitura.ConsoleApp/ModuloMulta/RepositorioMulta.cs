using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloMulta
{
    public class RepositorioMulta : RepositorioBase<Multa>
    {
                
        public RepositorioMulta(int tamanhoArray) : base(tamanhoArray)
        {
        }

        
        #region métodos próprios
        public void BaixarMulta(int numero)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i].numero == numero)
                {
                    registros[i].fechada = true;
                    break;
                }
            }
        }
        #endregion

        #region métodos não utilizados

        public void Popular(Multa multa) { }

        #endregion
    }
}
