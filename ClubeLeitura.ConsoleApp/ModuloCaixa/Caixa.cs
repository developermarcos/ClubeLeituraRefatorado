namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa
    {
        public int numero;
        public readonly string cor;
        public readonly string etiqueta;

        public Caixa(string cor, string etiqueta)
        {
            this.cor = cor;
            this.etiqueta = etiqueta;
        }
        
        public override string ToString()
        {
            string mensagem = $"Numero: {this.numero} | Cor: {this.cor} | Etiqueta: {this.etiqueta}";
            return mensagem;
        }

    }
}
