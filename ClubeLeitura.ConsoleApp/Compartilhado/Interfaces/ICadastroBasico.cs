namespace ClubeLeitura.ConsoleApp.Compartilhado.Interfaces
{
    public interface ICadastroBasico
    {
        void InserirRegistro();
        void EditarRegistro();
        void ExcluirRegistro();
        bool VisualizarRegistros(string tipoVisualizado);
    }
}