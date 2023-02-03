using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface IUsuarioLogic
{
    int InsertUsuario(Usuario usuarioItem);
    void UpdateUsuario(Usuario usuarioItem);
    void DeleteUsuario(int id);
    List<Usuario> GetAllUsuarios();
    //List<Usuario> GetUsuariosByCriteria(UsuarioFilter usuarioFilter);
   // List<Usuario> GetUsuarioByCriteria(WebAPPIStoreNovoAroma.Services.UsuarioFilter usuarioFilter);
    int InsertUsuario(object newUsuario);
}

