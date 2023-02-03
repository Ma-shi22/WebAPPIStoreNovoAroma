using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IClienteLogic
    {
        int InsertCliente(Cliente clienteItem);
        void UpdateCliente(Cliente clienteItem);
        void DeleteCliente(int id);
        List<Cliente> GetAllClientes();
        List<Cliente> GetClientesByCriteria(ClienteFilter clienteFilter);
    }
}

