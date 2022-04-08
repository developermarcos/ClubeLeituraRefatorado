
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class RepositorioBase<T> where T : EntidadeBase
    {
        public static int numero;
        public List<T> registros;

        public RepositorioBase()
        {
            registros = new List<T>();
        }
        public void Inserir(T item) 
        {
            item.numero = ObterNumeroRegistro();
            item.ativo = true;
            registros.Add(item);
        }

        public void Editar(int numeroEdicao, T item) 
        {
            T registro = registros.Find(x => x.numero == numeroEdicao);
            
            registros.Remove(registro);

            item.numero = numeroEdicao;

            registros.Add(item);
        }

        public bool Excluir(int numeroExclusao)
        {
            registros.RemoveAll(x => x.numero == numeroExclusao);
            return true;
        }

        public T[] ObterTodosRegistros()
        {
            return registros.ToArray();
        }

        public T ObterRegistro(int numeroRegistro)
        {
            return registros.Find(x => x.numero == numeroRegistro);
        }

        public bool RegistroExiste(int numeroRegistro)
        {
            return registros.Exists(x => x.numero == numeroRegistro);
        }

        protected int ObterNumeroRegistro()
        {
            return ++numero;
        }
    }
}
