namespace ClubeLeitura.ConsoleApp.ModuloPessoa
{
    public class Pessoa
    {
        public int numero;
        public string nome;
        public string telefone;
        public string endereco;

        public override string ToString()
        {
            string mensagem = $"Numero: {this.numero} | Nome {this.nome} | Telefone {this.telefone} | Endereco {this.endereco}";
            return mensagem;
        }
    }
}
