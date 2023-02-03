using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace WebAPPIStoreNovoAroma.IServices
{
    public interface IUsuarioServices
    {
        int InsertUsuario(NewUsuarioRequest newUsuarioRequest);
        void UpdateUsuario(Usuario usuarioItem);
        void DeleteUsuario(int id);
        List<Usuario> GetAllUsuarios();
        //List<Usuario> GetUsuariosByCriteria(Services.UsuarioFilter usuarioFilter);
        //List<Usuario> GetUsuariosByCriteria(Services.Usuarios usuarioFilter);
    }
}
