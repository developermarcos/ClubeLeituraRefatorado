using ClubeLeitura.ConsoleApp.Compartilhado;
namespace ClubeLeitura.ConsoleApp.ModuloPessoa
{
    public class RepositorioAmigo : RepositorioBase<Amigo>
    {
        public RepositorioAmigo(int tamanhoArray) : base(tamanhoArray)
        {
        }

        public void Popular(Amigo amigo)
        {
            Inserir(amigo);
        }

        #region metodos próprios
        public bool nomeJaCadastrado(string nomeInformado)
        {
            bool nomejaUtilizado = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].nome == nomeInformado)
                {
                    nomejaUtilizado = true;
                    break;
                }
            }

            return nomejaUtilizado;
        }

        #endregion
    }
}
