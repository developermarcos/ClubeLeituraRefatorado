using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloCategoriaRevista;
using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class Revista : EntidadeBase
    {
        public readonly string tipoColecao;
        public readonly string numeroEdicao;
        public readonly string ano;
        public readonly Caixa caixa;
        public readonly CategoriaRevista categoria;

        public Revista(string tipoColecao, string numeroEdicao, string ano, Caixa caixa, CategoriaRevista categoria)
        {
            this.tipoColecao = tipoColecao;
            this.numeroEdicao = numeroEdicao;
            this.ano = ano;
            this.caixa = caixa;
            this.categoria = categoria;
        }

        public override string ToString()
        {
            string mensagem = $"Numero: {this.numero} | Tipo coleção: {this.tipoColecao} | Numero edição: {this.numeroEdicao} | Ano: {this.ano}";
            return mensagem;
        }
        public override void Validar()
        {
            
        }
    }
}