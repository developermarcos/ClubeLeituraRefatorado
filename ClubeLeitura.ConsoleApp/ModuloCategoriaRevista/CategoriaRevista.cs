using ClubeLeitura.ConsoleApp.Compartilhado;
namespace ClubeLeitura.ConsoleApp.ModuloCategoriaRevista
{
    public class CategoriaRevista : EntidadeBase
    {
        public readonly string nome;
        public readonly int quantidadeDiasParaEmprestimo;

        public CategoriaRevista(string nome, int quantidade)
        {
            this.nome = nome;
            this.quantidadeDiasParaEmprestimo = quantidade;
        }

        public override string ToString()
        {
            string mensagem = $"Numero: {this.numero} | Nome: {this.nome} | Dias para empréstimo: {this.quantidadeDiasParaEmprestimo}";
            return mensagem;
        }
        public override void Validar()
        {
            
        }
    }
}
