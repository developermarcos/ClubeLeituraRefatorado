
namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class RepositorioBase<T> where T : EntidadeBase
    {
        public static int numero;
        public T[] item;

        public RepositorioBase(int quantidade)
        {
            this.item = new T[quantidade];
        }
        public void Inserir(T item) 
        {
            int posicaoVazia = ObterPosicaoVazia();
            item.numero = ObterNumeroRegistro();
            this.item[posicaoVazia] = item;
        }

        //public abstract void Editar() { }

        public T[] ObterTodosRegistros()
        {
            T[] item = new T[ObterQuantidadeRegistros()];

            int j = 0;

            for(int i = 0; i < this.item.Length; i++)
            {
                if(this.item[i] != null)
                {
                    item[j] = this.item[i];
                    j++;
                }
            }
            return item;
        }

        //public void Excluir();

        public T ObterRegistro(int numero)
        {
            return this.item[numero];
        }

        protected bool ExisteNumeroRegistro(int numero)
        {
            bool existeRegistro = false;

            for (int i = 0; i < this.item.Length; i++)
            {
                if (this.item[i].numero == numero)
                    existeRegistro = true;
            }

            return existeRegistro;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < this.item.Length; i++)
            {
                if (this.item[i] == null)
                    return i;
            }
            return -1;
        }

        public int ObterQuantidadeRegistros()
        {
            int quantidadeRegistros = 0;

            for (int i = 0; i < this.item.Length; i++)
            {
                if (this.item[i] == null)
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
