namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa
    {
        private int _numero;
        private string _cor;
        private string _etiqueta;

        public Caixa(string cor, string etiqueta)
        {
            this._cor = cor;
            this._etiqueta = etiqueta;
        }
        public int Numero { get { return this._numero; } set { this._numero = value; } }

        public string Cor { get { return this._cor; } }

        public string Etiqueta { get { return this._etiqueta; } }
        
    }
}
