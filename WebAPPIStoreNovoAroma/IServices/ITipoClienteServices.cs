using Entities.Entities;

namespace WebAPPIStoreNovoAroma.IServices
{
    public interface ITipoClienteServices
    {
        int InsertTipoCliente(TipoCliente tipoClienteItem);
        void UpdateTipoCliente(TipoCliente tipoClienteItem);
        void DeleteTipoCliente(int id);
        List<TipoCliente> GetAllTiposClientes();
    }
}
