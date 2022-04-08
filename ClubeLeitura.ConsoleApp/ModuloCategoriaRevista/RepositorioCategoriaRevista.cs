using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloCategoriaRevista
{
    public class RepositorioCategoriaRevista : RepositorioBase<CategoriaRevista>
    {
        
        public void Popular(string nome, int quantidade)
        {
            CategoriaRevista categoria = new CategoriaRevista(nome, quantidade);
            Inserir(categoria);
        }
    }
}
