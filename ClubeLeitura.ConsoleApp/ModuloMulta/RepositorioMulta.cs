using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloMulta
{
    public class RepositorioMulta : IRepositoryBase<Multa>
    {
        public static int numero;
        Multa[] multas;
        
        public RepositorioMulta(Multa[] multas)
        {
            this.multas = multas;
        }

        public void Inserir(Multa multa)
        {
            multa.numero = ObterNumeroRegistro();
            int posicaoVazia = ObterPosicaoVazia();
            multas[posicaoVazia] = multa;
        }

        public Multa[] ObterTodosRegistros()
        {
            int quantidadeMultas = ObterQuantidadeRegistros();

            Multa[] multasInseridas = new Multa[quantidadeMultas];
            int j = 0;
            for (int i = 0; i < multas.Length; i++)
            {
                if (multas[i] != null)
                {
                    multasInseridas[j] = multas[i];
                    j++;
                }
            }

            return multasInseridas;
        }

        public Multa ObterRegistro(int numero)
        {
            Multa multa = null;

            for (int i = 0; i < multas.Length; i++)
            {
                if (multas[i].numero == numero)
                    return multas[i];
            }

            return multa;
        }

        public bool ExisteNumeroRegistro(int numero)
        {
            for (int i = 0; i < multas.Length; i++)
            {
                if (multas[i] != null && multas[i].numero == numero)
                {
                    return true;
                }
            }
            return false;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < multas.Length; i++)
            {
                if(multas[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }

        public int ObterQuantidadeRegistros()
        {
            int quantidadeMultas = 0;

            for (int i = 0; i < multas.Length; i++)
            {
                if(multas[i] != null)
                    quantidadeMultas++;
            }

            return quantidadeMultas;
        }

        public void Popular(Multa multa) { }

        
        #region métodos próprios
        public void BaixarMulta(int numero)
        {
            for (int i = 0; i < multas.Length; i++)
            {
                if (multas[i].numero == numero)
                {
                    multas[i].fechada = true;
                    break;
                }
            }
        }
        #endregion

        #region métodos não utilizados
        public void Editar(int numero, Multa item){}
        
        public void Excluir(int numero){}

        public int ObterNumeroRegistro()
        {
            return ++numero;
        }
        #endregion
    }
}
