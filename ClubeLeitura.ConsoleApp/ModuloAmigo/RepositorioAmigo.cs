using ClubeLeitura.ConsoleApp.Compartilhado;
namespace ClubeLeitura.ConsoleApp.ModuloPessoa
{
    public class RepositorioAmigo : IRepositoryBase<Amigo>
    {
        public Amigo[] amigos;
        private static int numero;

        public RepositorioAmigo(Amigo[] amigos)
        {
            this.amigos=amigos;
        }

        public void Inserir(Amigo amigo)
        {
            int posicaoVazia = ObterPosicaoVazia();
            amigo.numero = ObterNumeroRegistro();
            amigos[posicaoVazia] = amigo;
        }

        public void Editar(int numeroSelecioando, Amigo amigo)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].numero == numeroSelecioando)
                {
                    amigo.numero = numeroSelecioando;
                    amigos[i] = amigo;

                    break;
                }
            }
        }

        public Amigo[] ObterTodosRegistros()
        {
            int quantidadeAmigos = ObterQuantidadeRegistros();

            Amigo[] amigosInseridos = new Amigo[quantidadeAmigos];
            int j = 0;
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    amigosInseridos[j] = amigos[i];
                    j++;
                }
            }

            return amigosInseridos;
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].numero == numeroSelecionado)
                {
                    amigos[i] = null;
                    break;
                }
            }
        }

        public Amigo ObterRegistro(int idAmigo)
        {
            Amigo amigo = null;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].numero == idAmigo)
                {
                    amigo = amigos[i];
                    break;
                }
            }

            return amigo;
        }

        public bool ExisteNumeroRegistro(int numeroAmigo)
        {
            bool numeroAmigoEncontrado = false;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].numero == numeroAmigo)
                {
                    numeroAmigoEncontrado = true;
                    break;
                }
            }

            return numeroAmigoEncontrado;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }

        public int ObterQuantidadeRegistros()
        {
            int numeroAmigos = 0;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                    numeroAmigos++;
            }

            return numeroAmigos;
        }

        public int ObterNumeroRegistro()
        {
            return ++numero;
        }

        public void Popular(Amigo amigo)
        {
            Inserir(amigo);
        }

        #region metodos próprios
        public bool nomeJaCadastrado(string nomeInformado)
        {
            bool nomejaUtilizado = false;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].nome == nomeInformado)
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
