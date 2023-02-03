using WebAPPIStoreNovoAroma.IServices;
using WebAPPIStoreNovoAroma.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Resource.RequestModels;

namespace WebAPPIStoreNovoAroma.Service
{
    public class PedidoServices : IPedidoServices
    {
        private readonly IPedidoLogic _pedidoLogic;
        public PedidoServices(IPedidoLogic pedidoLogic)
        {
            _pedidoLogic = pedidoLogic;
        }

        public void DeletePedido(int id)
        {
            _pedidoLogic.DeletePedido(id);
        }

        public List<Pedido> GetAllPedidos()
        {
            return _pedidoLogic.GetAllPedidos();
        }

        public List<Pedido> GetPedidosByCriteria(PedidoFilter pedidoFilter)
        {
            return _pedidoLogic.GetPedidosByCriteria(pedidoFilter);
        }


        //public int InsertPedido(NewPedidoRequest newPedidoRequest)
        //{

            //var newPedidoItem = newPedidoRequest.ToPedido();
            //return _pedidoLogic.InsertPedido(newPedido);
        //}

        public void UpdatePedido(Pedido pedidoItem)
        {
            _pedidoLogic.UpdatePedido(pedidoItem);
        }
    }
}
