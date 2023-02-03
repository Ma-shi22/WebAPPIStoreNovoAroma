using WebAPPIStoreNovoAroma.IServices;
using WebAPPIStoreNovoAroma.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Resource.RequestModels;

namespace WebAPPIStoreNovoAroma.Services
{
    public class TipoClienteServices : ITipoClienteServices
    {
        private readonly Logic.Logic.ITipoClienteLogic _tipoClienteLogic;
        public TipoClienteServices(Logic.Logic.ITipoClienteLogic tipoClienteLogic)
        {
            _tipoClienteLogic = tipoClienteLogic;
        }

        public void DeleteTipoCliente(int id)
        {
            _tipoClienteLogic.DeleteTipoCliente(id);
        }

        public List<TipoCliente> GetAllTiposClientes()
        {
            return _tipoClienteLogic.GetAllTiposClientes();
        }

        public int InsertTipoCliente(TipoCliente tipoCliente)
        {
            _tipoClienteLogic.InsertTipoCliente(tipoCliente);
            return tipoCliente.Id;
        }

        public void UpdateTipoCliente(TipoCliente tipoCliente)
        {
            _tipoClienteLogic.UpdateTipoCliente(tipoCliente);
        }

    }
}
