using System;
using System.Collections.Generic;
using System.Text;

namespace Mecanica.Repositorios
{
    public interface IPedidoRepository<T>
    {
        public T Get(int id);
        void Adicionar(T entidade);
        void Remover(int id);
        void Atualizar(int id, T entidade);
        List<T> GetTodos();
        List<T> GetPedidosDoCliente(int idCliente);
        List<T> GetPedidosNaoFinalizados();
    }
}
