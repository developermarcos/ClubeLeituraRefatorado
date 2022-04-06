namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int numero;
        public bool ativo;

        public abstract void Validar();
    }
}