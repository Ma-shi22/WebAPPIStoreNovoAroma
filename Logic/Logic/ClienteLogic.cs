using Data;
using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class ClienteLogic
    {
        private readonly ServiceContext _serviceContext;
        public ClienteLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertCliente(Cliente clienteItem)
        {
            if (clienteItem.IdRol == 1)
            {
                throw new InvalidOperationException();
            };

            _serviceContext.Clientes.Add(clienteItem);
            _serviceContext.SaveChanges();
            return clienteItem.Id;
        }

        public void UpdateCliente(Cliente clienteItem)
        {
            _serviceContext.Clientes.Update(clienteItem);

            _serviceContext.SaveChanges();
        }
        public void DeleteCliente(int id)
        {
            var clienteToDelete = _serviceContext.Set<Cliente>()
                 .Where(u => u.Id == id).First();

            clienteToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public List<Cliente> GetAllClientes()
        {
            return _serviceContext.Set<Cliente>().ToList();
        }
        public List<Cliente> GetClientesByCriteria(ClienteFilter clienteFilter)
        {
            var resultList = _serviceContext.Set<Cliente>()
                                .Where(u => u.IsActive == true);

            if (clienteFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(u => u.InsertDate > clienteFilter.InsertDateFrom);
            }

            if (clienteFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(u => u.InsertDate < clienteFilter.InsertDateTo);
            }

            return resultList.ToList();
        }
    }
}

