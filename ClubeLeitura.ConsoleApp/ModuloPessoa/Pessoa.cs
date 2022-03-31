using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloPessoa
{
    public class Pessoa : EntidadeBase
    {
        public string nome;
        public string telefone;
        public string endereco;

        public override string ToString()
        {
            string mensagem = $"Numero: {this.numero} | Nome {this.nome} | Telefone {this.telefone} | Endereco {this.endereco}";
            return mensagem;
        }
        public override void Validar()
        {

        }
    }
}
