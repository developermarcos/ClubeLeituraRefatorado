using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloCategoriaRevista;

using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista : RepositorioBase<Revista>
    {
        public RepositorioRevista(int tamanhoArray) : base(tamanhoArray)
        {
            
        }

        public void Popular(string tipoColecao, string numeroEdicao, string ano, Caixa caixa, CategoriaRevista categoria)
        {
            Revista revista = new Revista(tipoColecao, numeroEdicao, ano, caixa, categoria);
            Inserir(revista);
        }
    }
}
