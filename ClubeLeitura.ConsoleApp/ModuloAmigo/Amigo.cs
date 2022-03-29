namespace ClubeLeitura.ConsoleApp.ModuloPessoa
{
    internal class Amigo
    {
        private int _numero;
        private string _nome;
        private string _responsavel;
        private string _telefone;
        private string _endereco;

        public Amigo(string nome, string responsavel, string telefone, string endereco)
        {
            this._nome = nome;
            this._responsavel = responsavel;
            this._telefone = telefone;
            this._endereco = endereco;
        }
        public Amigo(int numero, string nome, string responsavel, string telefone, string endereco)
        {
            this._numero = numero;
            this._nome = nome;
            this._responsavel = responsavel;
            this._telefone = telefone;
            this._endereco = endereco;
        }
        public int Numero
        {
            get { return this._numero; }
            set { this._numero = value; }
        }
        public string Nome
        {
            get { return this._nome; }
        }
        public string Responsavel
        {
            get { return this._responsavel; }
        }
        public string Telefone
        {
            get { return this._telefone; }
        }
        public string Endereco
        {
            get { return this._endereco; }
        }
    }
}
