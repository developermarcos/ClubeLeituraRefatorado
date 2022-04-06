using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloReserva
{
    public class Reserva : EntidadeBase
    {
        public readonly DateTime dataReserva;
        private DateTime _dataExpira;
        public readonly Amigo amigo;
        public readonly Revista revista;

        public Reserva(Amigo amigo, Revista revista, DateTime dataReserva)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.dataReserva = dataReserva;
            this._dataExpira = CalculaDataExpira(dataReserva);
        }
        
        public DateTime DateExpira { get { return _dataExpira; } }
        
        public override string ToString()
        {
            string mensagem = $"Numero : {this.numero} | Data reserva: {this.dataReserva.ToString("dd/MM/yyyy")} | Data expira: {this.DateExpira.ToString("dd/MM/yyyy")}";
            return mensagem;
        }

        public override void Validar()
        {
            
        }

        #region métodos privados
        private DateTime CalculaDataExpira(DateTime data)
        {
            DateTime dataCalculada = data.AddDays(2);
            return dataCalculada;
        }

        #endregion
    }
}
