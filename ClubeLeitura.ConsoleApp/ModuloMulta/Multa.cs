﻿using ClubeLeitura.ConsoleApp.ModuloEmprestimos;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloMulta
{
    public class Multa
    {
        public int numero;
        public readonly decimal valor;
        public readonly Emprestimo emprestimo;
        private readonly decimal valorBaseMulta = 1.50m;
        public bool fechada;

        public Multa(Emprestimo emprestimoDevolucao)
        {
            this.emprestimo=emprestimoDevolucao;
            this.valor = CalculaValorMulta();
        }
        public override string ToString()
        {
            string status = this.fechada == true ? "Fechada" : "Aberta";
            string mensagem = $"Numero: {this.numero} | Valor: {this.valor} | Numero emprestimo: {this.emprestimo.numero} | Amigo: {this.emprestimo.amigo.nome} | Status: {status}";
            return mensagem;
        }

        #region métodos privados
        private decimal CalculaValorMulta()
        {
            int diferencaDias = (int)DateTime.Now.Subtract(this.emprestimo.DataDevolucao).TotalDays;
            
            return (Convert.ToDecimal(diferencaDias) * this.valorBaseMulta);
        }

        #endregion
    }
}
