using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimos
{
    internal class TelaEmprestimo
    {
        
        public int numeroEmprestimo; //controlar o número da caixas cadastradas
        public Notificador notificador; //reponsável pelas mensagens pro usuário
        public RepositorioEmprestimo repositorioEmprestimos;

        public TelaAmigo telaAmigo;
        public RepositorioAmigo repositorioAmigo;

        public TelaRevista telaRevista;
        public RepositorioRevista repositorioRevista;
    }
}
