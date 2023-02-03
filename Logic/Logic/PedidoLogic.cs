using Data;
using WebAPPIStoreNovoAroma;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class PedidoLogic
    {
        public class PedidoLogic : IPedidoLogic
        {
            private readonly ServiceContext _serviceContext;
            public PedidoLogic(ServiceContext serviceContext)
            {
                _serviceContext = serviceContext;
            }
            public int InsertPedido(Pedido pedidoItem)
            {
                _serviceContext.Pedidos.Add(pedidoItem);
                _serviceContext.SaveChanges();
                return pedidoItem.Id;
            }

            public void UpdatePedido(Pedido pedidoItem)
            {
                _serviceContext.Pedidos.Update(pedidoItem);

                _serviceContext.SaveChanges();
            }

            public void DeletePedido(int id)
            {
                var pedidoToDelete = _serviceContext.Set<Pedido>()
                    .Where(p => p.Id == id).First();

                pedidoToDelete.IsActive = false;

                _serviceContext.SaveChanges();

            }

            public List<Pedido> GetAllPedidos()
            {
                return _serviceContext.Set<Pedido>().ToList();
            }

            public List<Pedido> GetPedidosByCriteria(PedidoFilter pedidoFilter)
            {
                var resultList = _serviceContext.Set<Pedido>()
                                            .Where(p => p.IsActive == true);

                //.Where(u => u.Marca = productoFilter.Marca);

                if (pedidoFilter.InsertDateFrom != null)
                {
                    resultList = resultList.Where(p => p.FechaPedido > pedidoFilter.InsertDateFrom);
                }

                if (pedidoFilter.InsertDateTo != null)
                {
                    resultList = resultList.Where(p => p.FechaPedido < pedidoFilter.InsertDateTo);
                }
                if (pedidoFilter.ImporteTotalDesde != null)
                {
                    resultList = resultList.Where(p => p.ImporteTotal > pedidoFilter.ImporteTotalDesde);
                }

                if (pedidoFilter.ImporteTotalHasta != null)
                {
                    resultList = resultList.Where(p => p.ImporteTotal < pedidoFilter.ImporteTotalHasta);
                }

                return resultList.ToList();
            }
            public List<Pedido> GetPedidosByCliente(int idCliente)
            {
                var resultList = _serviceContext.Set<Pedido>()
                            .Where(p => p.IdCliente == idCliente);
                return resultList.ToList();
            }

            public List<Pedido> GetPedidosByCriteria(PedidoFilter pedidoFilter)
            {
                throw new NotImplementedException();
            }
        }
    }
}