using Entities.Entities;

namespace WebAPPIStoreNovoAroma.IServices
{
    public interface IRolServices
    {
        int InsertRol(Rol rol);
        void UpdateRol(Rol rol);
        void DeleteRol(int id);
        List<Rol> GetAllRoles();
        void UpdateRol(object rol);
    }
}
