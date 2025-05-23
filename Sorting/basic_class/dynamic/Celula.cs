
namespace Sorting.basic_class.dynamic
{
    public class Celula
    {
        public int valor;
        public Celula? prox;

        public Celula()
        {
            this.valor = -1;
            this.prox = null;
        }

        public Celula(int valor)
        {
            this.valor = valor;
            this.prox = null;
        }
    }
}