using Data;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class TipoClienteLogic : ITipoClienteLogic
    {
        private readonly ServiceContext _serviceContext;
        public TipoClienteLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertTipoCliente(TipoCliente tipoClienteItem)
        {
            _serviceContext.TiposClientes.Add(tipoClienteItem);
            _serviceContext.SaveChanges();
            return tipoClienteItem.Id;
        }

        public void UpdateTipoCliente(TipoCliente tipoClienteItem)
        {
            _serviceContext.TiposClientes.Update(tipoClienteItem);

            _serviceContext.SaveChanges();
        }

        public void DeleteTipoCliente(int id)
        {
            var tipoClienteToDelete = _serviceContext.Set<TipoCliente>()
                .Where(u => u.Id == id).First();

            tipoClienteToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }


        public List<TipoCliente> GetAllTiposClientes()
        {
            return _serviceContext.Set<TipoCliente>().ToList();
        }

        void ITipoClienteLogic.InsertTipoCliente(TipoCliente tipoClienteItem)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITipoClienteLogic
    {
        void DeleteTipoCliente(int id);
        List<TipoCliente> GetAllTiposClientes();
        void InsertTipoCliente(TipoCliente tipoClienteItem);
        void UpdateTipoCliente(TipoCliente tipoClienteItem);
    }
}
