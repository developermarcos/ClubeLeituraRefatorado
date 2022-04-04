
namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class RepositorioBase<T> where T : EntidadeBase
    {
        public static int numero;
        public T[] registros;

        public RepositorioBase(int quantidade)
        {
            this.registros = new T[quantidade];
        }
        public void Inserir(T item) 
        {
            int posicaoVazia = ObterPosicaoVazia();
            item.numero = ObterNumeroRegistro();
            this.registros[posicaoVazia] = item;
        }

        public void Editar(int numero, T item) 
        {
            item.numero = numero;

            for (int i = 0; i < this.registros.Length; i++)
            {
                if(this.registros[i] != null && this.registros[i].numero == numero)
                {
                    this.registros[i] = item;
                    break;
                }
            }
        }

        public T[] ObterTodosRegistros()
        {
            T[] item = new T[ObterQuantidadeRegistros()];

            int j = 0;

            for(int i = 0; i < this.registros.Length; i++)
            {
                if(this.registros[i] != null)
                {
                    item[j] = this.registros[i];
                    j++;
                }
            }

            return item;
        }

        public void Excluir(int numero)
        {
            for (int i = 0; i < this.registros.Length; i++)
            {
                if (this.registros[i] != null && this.registros[i].numero == numero)
                {
                    this.registros[i] = null;
                    break;
                }
            }
        }

        public T ObterRegistro(int numero)
        {
            T item = null;

            for (int i = 0; i < this.registros.Length; i++)
            {
                if (this.registros[i] != null && this.registros[i].numero == numero)
                {
                    return this.registros[i];
                }
            }

            return item;
        }

        public bool ExisteNumeroRegistro(int numero)
        {
            bool existeRegistro = false;

            for (int i = 0; i < this.registros.Length; i++)
            {
                if (this.registros[i] != null && this.registros[i].numero == numero)
                    existeRegistro = true;
            }

            return existeRegistro;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < this.registros.Length; i++)
            {
                if (this.registros[i] == null)
                    return i;
            }
            return -1;
        }

        public int ObterQuantidadeRegistros()
        {
            int quantidadeRegistros = 0;

            for (int i = 0; i < this.registros.Length; i++)
            {
                if (this.registros[i] != null)
                    quantidadeRegistros++;
            }

            return quantidadeRegistros;
        }

        protected int ObterNumeroRegistro()
        {
            return ++numero;
        }
    }
}
