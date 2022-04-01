
namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class RepositorioBase<T> where T : EntidadeBase
    {
        public static int numero;
        public T[] itens;

        public RepositorioBase(int quantidade)
        {
            this.itens = new T[quantidade];
        }
        public void Inserir(T item) 
        {
            int posicaoVazia = ObterPosicaoVazia();
            item.numero = ObterNumeroRegistro();
            this.itens[posicaoVazia] = item;
        }

        public void Editar(int numero, T item) 
        {
            for (int i = 0; i < this.itens.Length; i++)
            {
                if(this.itens[i] != null && this.itens[i].numero == numero)
                {
                    this.itens[i] = item;
                    break;
                }
            }
        }

        public T[] ObterTodosRegistros()
        {
            T[] item = new T[ObterQuantidadeRegistros()];

            int j = 0;

            for(int i = 0; i < this.itens.Length; i++)
            {
                if(this.itens[i] != null)
                {
                    item[j] = this.itens[i];
                    j++;
                }
            }
            return item;
        }

        public void Excluir(int numero)
        {
            for (int i = 0; i < this.itens.Length; i++)
            {
                if (this.itens[i] != null && this.itens[i].numero == numero)
                {
                    this.itens[i] = null;
                    break;
                }
            }
        }

        public T ObterRegistro(int numero)
        {
            return this.itens[numero];
        }

        protected bool ExisteNumeroRegistro(int numero)
        {
            bool existeRegistro = false;

            for (int i = 0; i < this.itens.Length; i++)
            {
                if (this.itens[i].numero == numero)
                    existeRegistro = true;
            }

            return existeRegistro;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < this.itens.Length; i++)
            {
                if (this.itens[i] == null)
                    return i;
            }
            return -1;
        }

        public int ObterQuantidadeRegistros()
        {
            int quantidadeRegistros = 0;

            for (int i = 0; i < this.itens.Length; i++)
            {
                if (this.itens[i] == null)
                    quantidadeRegistros++;
            }

            return quantidadeRegistros;
        }

        public int ObterNumeroRegistro()
        {
            return ++numero;
        }
    }
}
