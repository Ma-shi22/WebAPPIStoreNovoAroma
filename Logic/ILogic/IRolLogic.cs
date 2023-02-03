using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IRolLogic
    {
        int InsertRol(Rol rolItem);
        void UpdateRol(Rol rolItem);
        void DeleteRol(int id);
        List<Rol> GetAllRoles();
    }
}

