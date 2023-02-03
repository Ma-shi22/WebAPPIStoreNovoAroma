using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.RequestModels
{
    public class NewUsuarioRequest
    {
        public int IdPersona { get; set; }
        public int IdRol { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public Usuario ToUsuario(Usuario usuario)
        {
            var Usuario = new Usuario();

            usuario.IdPersona = IdPersona;
            usuario.IdRol = IdRol;
            usuario.Usuario = Usuario;
            usuario.Password = Password;

            usuario.InsertDate = DateTime.Now;
            usuario.UpdateDate = DateTime.Now;
            usuario.IsActive = true;

            return usuario;
        }

        public object ToUsuario() => throw new NotImplementedException();
    }
}
