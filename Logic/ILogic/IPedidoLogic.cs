using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IPedidoLogic
    {
        int InsertPedido(Pedido pedidoItem);
        void UpdatePedido(Pedido pedidoItem);
        void DeletePedido(int id);
        List<Pedido> GetAllPedidos();
        List<Pedido> GetPedidosByCriteria(PedidoFilter pedidoFilter);

        /*List<PedidoItem> GetPedidosByCliente(int idClientes);
        List<PedidoItem> GetPedidosByProducto(int idProductos);
        List<PedidoItem> GetPedidosByProducto(int idCategoria);
        List<PedidoItem> GetPedidosByPagado(PedidoFilter pedidoFilter);
        List<PedidoItem> GetPedidosByEntregado(PedidoFilter pedidoFilter);*/
    }
}
