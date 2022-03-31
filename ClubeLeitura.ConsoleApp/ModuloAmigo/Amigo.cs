using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.Compartilhado;
namespace ClubeLeitura.ConsoleApp.ModuloPessoa
{
    public class Amigo : Pessoa
    {
        public readonly string responsavel;

        public Amigo(string nome, string responsavel, string telefone, string endereco)
        {
            this.nome = nome;
            this.responsavel = responsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }
        public Amigo(int numero, string nome, string responsavel, string telefone, string endereco)
        {
            this.numero = numero;
            this.nome = nome;
            this.responsavel = responsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }
        
        public override string ToString()
        {
            string mensagem = base.ToString();
            mensagem += $" | Responsavel {this.responsavel}";
            return mensagem;
        }
    }
}
