using Entities.Entities;
using Entities.SearchFilters;

namespace WebAPPIStoreNovoAroma.IService
{
    public interface IClienteServices
    {
        int InsertCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int id);
        List<Cliente> GetAllClientes();
        List<Cliente> GetClientesByCriteria(ClienteFilter clienteFilter);
        
    }
}

