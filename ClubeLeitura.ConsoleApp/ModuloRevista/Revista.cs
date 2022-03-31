using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloCategoriaRevista;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class Revista
    {
        private int _numero;
        private string _tipoColecao;
        private string _numeroEdicao;
        private string _ano;
        private Caixa _caixa;
        private CategoriaRevista _categoria;

        public Revista(string tipoColecao, string numeroEdicao, string ano, Caixa caixa, CategoriaRevista categoria)
        {
            this._tipoColecao = tipoColecao;
            this._numeroEdicao = numeroEdicao;
            this._ano = ano;
            this._caixa = caixa;
            this._categoria = categoria;
        }

        public int Numero { get { return this._numero; } set { this._numero = value; } }
        
        public string TipoColecao { get { return this._tipoColecao;} }

        public string NumeroEdicao { get { return this._numeroEdicao;} }

        public string Ano { get { return this._ano; } }

        public Caixa Caixa { get { return this._caixa; } }

        public CategoriaRevista Categoria { get { return this._categoria; } }

        public override string ToString()
        {
            string mensagem = $"Numero: {this.Numero} | Tipo coleção: {this.TipoColecao} | Numero edição: {this.NumeroEdicao} | Ano: {this.Ano}";
            return mensagem;
        }
    }
}