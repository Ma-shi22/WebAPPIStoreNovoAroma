using Entities.Entities;

namespace WebAPPIStoreNovoAroma.Services
{
    public interface IRolServices
    {
        int InsertRol(Rol rol);
        void UpdateRol(Rol rol);
        void DeleteRol(int id);
        List<Rol> GetAllRoles();
    }
}