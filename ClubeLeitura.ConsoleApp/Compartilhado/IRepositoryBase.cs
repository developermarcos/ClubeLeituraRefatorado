using System;

namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    internal interface IRepositoryBase<T> where T : EntidadeBase
    {
        static int numero;
        void Inserir(T item);

        void Editar(int numero, T item);

        T[] ObterTodosRegistros();

        void Excluir(int numero);

        T ObterRegistro(int numero);

        bool ExisteNumeroRegistro(int numero);

        int ObterPosicaoVazia();

        int ObterQuantidadeRegistros();

        int ObterNumeroRegistro();

        void Popular(T item);
    }
}
