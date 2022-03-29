using ClubeLeitura.ConsoleApp.ModuloCaixa;
namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class Revista
    {
        private int _numero;
        private string _tipoColecao;
        private string _numeroEdicao;
        private string _ano;
        private Caixa _caixa;

        public Revista(string tipoColecao, string numeroEdicao, string ano, Caixa caixa)
        {
            this._tipoColecao = tipoColecao;
            this._numeroEdicao = numeroEdicao;
            this._ano = ano;
            this._caixa = caixa;
        }

        public int Numero { get { return this._numero; } set { this._numero = value; } }
        
        public string TipoColecao { get { return this._tipoColecao;} }

        public string NumeroEdicao { get { return this._numeroEdicao;} }

        public string Ano { get { return this._ano; } }

        public Caixa Caixa { get { return this._caixa; } }
    }
}