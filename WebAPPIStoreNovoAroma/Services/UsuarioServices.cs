using WebAPPIStoreNovoAroma.IServices;
using WebAPPIStoreNovoAroma.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Resource.RequestModels;


namespace WebAPPIStoreNovoAroma.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioLogic _usuarioLogic;
        public UsuarioServices(IUsuarioLogic usuarioLogic)
        {
            _usuarioLogic = usuarioLogic;
        }
        public int InsertUsuario(NewUsuarioRequest newUsuarioRequest)
        {
            var newUsuario = newUsuarioRequest.ToUsuario();
            return _usuarioLogic.InsertUsuario(newUsuario);
        }
        public List<Usuario> GetAllUsuarios()
        {
            return _usuarioLogic.GetAllUsuarios();
        }

        public IUsuarioLogic Get_usuarioLogic()
        {
            return _usuarioLogic;
        }

       // public List<Usuario> GetUsuariosByCriteria(UsuarioFilter usuarioFilter, IUsuarioLogic _usuarioLogic)
        //{
           //return _usuarioLogic.GetUsuariosByCriteria(usuarioFilter);
        //}

        public void UpdateUsuario(Usuario usuario)
        {
            _usuarioLogic.UpdateUsuario(usuario);
        }

        public void DeleteUsuario(int id)
        {
            _usuarioLogic.DeleteUsuario(id);
        }

        int IUsuarioServices.InsertUsuario(NewUsuarioRequest newUsuarioRequest)
        {
            throw new NotImplementedException();
        }

        void IUsuarioServices.UpdateUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        void IUsuarioServices.DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }

        List<Usuario> IUsuarioServices.GetAllUsuarios()
        {
            throw new NotImplementedException();
        }

       // public List<Usuario> GetUsuariosByCriteria(Services.Usuarios usuarioFilter) => throw new NotImplementedException();

        //List<Usuario> IUsuarioServices.GetUsuariosByCriteria(UsuarioFilter usuarioFilter)
        //{
        // throw new NotImplementedException();
    }
    }
//}
