using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace WebAPPIStoreNovoAroma.IServices
{
    public interface IPedidoServices
    {
        int InsertPedido(NewPedidoRequest newPedidoRequest);
        void UpdatePedido(Pedido pedido);
        void DeletePedido(int id);
        List<Pedido> GetAllPedidos();
        List<Pedido> GetPedidosByCriteria(PedidoFilter pedidoFilter);
        //void UpdatePedido(Pedido pedido);
    }
}
