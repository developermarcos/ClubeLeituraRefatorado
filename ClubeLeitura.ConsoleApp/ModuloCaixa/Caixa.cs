using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa : EntidadeBase
    {
        public string cor;
        public string etiqueta;

        public Caixa()
        {
        }

        public Caixa(string cor, string etiqueta, int numero, bool ativo)
        {
            this.cor = cor;
            this.etiqueta = etiqueta;
            this.numero = numero;
            this.ativo = ativo;
        }

        public Caixa(string cor, string etiqueta)
        {
            this.cor = cor;
            this.etiqueta = etiqueta;
        }

        public override string ToString()
        {
            string mensagem = $"Numero: {this.numero} | Cor: {this.cor} | Etiqueta: {this.etiqueta} | Ativo: {this.ativo}";
            return mensagem;
        }
        public string ToJson()
        {
            string mensagem = $"numero: {this.numero} cor: {this.cor} etiqueta: {this.etiqueta}";
            return mensagem;

        }

        public override void Validar()
        {
            
        }
    }
}
