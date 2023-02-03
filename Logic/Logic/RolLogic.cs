using Data;
using WebAPPIStoreNovoAroma;
using Entities.Entities;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class RolLogic : IRolLogic
    {
        private readonly ServiceContext _serviceContext;
        public RolLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertRol(Rol rolItem)
        {
            _serviceContext.Roles.Add(rolItem);
            _serviceContext.SaveChanges();
            return rolItem.Id;
        }

        public void UpdateRol(Rol rolItem)
        {
            _serviceContext.Roles.Update(rolItem);

            _serviceContext.SaveChanges();
        }

        public void DeleteRol(int id)
        {
            var rolToDelete = _serviceContext.Set<Rol>()
                .Where(u => u.Id == id).First();

            rolToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }


        public List<Rol> GetAllRoles()
        {
            return _serviceContext.Set<Rol>().ToList();
        }
    }
}
