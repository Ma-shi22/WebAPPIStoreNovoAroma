using Entities.Entities;
using Logic.ILogic;
using Logic.Logic;
using Entities.SearchFilters;
using Resource.RequestModels;
using WebAPPIStoreNovoAroma.IService;

namespace WebAPPIStoreNovoAroma.Service
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteLogic _clienteLogic;
        public ClienteServices(IClienteLogic clienteLogic)
        {
            _clienteLogic = clienteLogic;
        }
        public int InsertCliente(Cliente cliente)
        {
            _clienteLogic.InsertCliente(cliente);
            return cliente.Id;
        }
        public List<Cliente> GetAllClientes()
        {
            return _clienteLogic.GetAllClientes();
        }
        public List<Cliente> GetClientesByCriteria(ClienteFilter clienteFilter)
        {
            return _clienteLogic.GetClientesByCriteria(clienteFilter);
        }

        public void UpdateCliente(Cliente cliente)
        {
            _clienteLogic.UpdateCliente(cliente);
        }

        public void DeleteCliente(int id)
        {
            _clienteLogic.DeleteCliente(id);
        }
    }
}
