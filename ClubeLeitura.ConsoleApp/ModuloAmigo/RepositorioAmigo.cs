using ClubeLeitura.ConsoleApp.Compartilhado;
namespace ClubeLeitura.ConsoleApp.ModuloPessoa
{
    public class RepositorioAmigo : RepositorioBase<Amigo>
    {
        public RepositorioAmigo()
        {
        }

        
        #region metodos próprios
        public bool nomeJaCadastrado(string nomeInformado)
        {
            foreach(Amigo registro in registros)
            {
                if (registro.nome == nomeInformado)
                    return true;
            }

            return false;
        }

        public Amigo[] SelecionarAmigosComMulta()
        {
            Amigo[] amigosComMulta = new Amigo[ObterQtdAmigosComMulta()];

            int j = 0;

            for (int i = 0; i < registros.Count; i++)
            {
                Amigo a = (Amigo)registros[i];
                if (registros[i] != null && a.TemMultaEmAberto())
                {
                    amigosComMulta[j] = a;
                    j++;
                }
            }

            return amigosComMulta;
        }

        
        #endregion

        #region métodos privados
        private int ObterQtdAmigosComMulta()
        {
            int numeroAmigos = 0;

            for (int i = 0; i < registros.Count; i++)
            {
                Amigo a = (Amigo)registros[i];

                if (registros[i] != null && a.TemMultaEmAberto())
                    numeroAmigos++;
            }

            return numeroAmigos;
        }
        #endregion
    }
}
