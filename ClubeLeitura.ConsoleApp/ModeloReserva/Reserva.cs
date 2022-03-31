using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModeloReserva
{
    public class Reserva
    {
        int _numero;
        DateTime _dataReserva;
        DateTime _dataExpira;
        Amigo _amigo;
        Revista _revista;

        public Reserva(Amigo amigo, Revista revista, DateTime dataReserva)
        {
            this._amigo = amigo;
            this._revista = revista;
            this._dataReserva = dataReserva;
            this._dataExpira = CalculaDataExpira(dataReserva);
        }
        public int Numero { get { return _numero; } set { _numero = value; } }

        public Amigo Amigo { get { return _amigo; } }

        public Revista Revista { get { return _revista; } }

        public DateTime DataReserva { get { return _dataReserva; } }

        public DateTime DateExpira { get { return _dataExpira; } }
        
        private DateTime CalculaDataExpira(DateTime data)
        {
            DateTime dataCalculada = data.AddDays(2);
            return dataCalculada;
        }

        public override string ToString()
        {
            string mensagem = $"Numero : {this.Numero} | Data reserva: {this.DataReserva.ToString("dd/MM/yyyy")} | Data expira: {this.DateExpira.ToString("dd/MM/yyyy")}";
            return mensagem;
        }
    }
}
