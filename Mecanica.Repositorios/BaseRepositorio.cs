using Mecanica.Modelos;

namespace Mecanica.Repositorios
{
    public class BaseRepositorio
    {
        protected Contexto db;

        public BaseRepositorio()
        {
            db = new Contexto();
        }
    }
}
