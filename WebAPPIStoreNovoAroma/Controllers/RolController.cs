using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using WebAPPIStoreNovoAroma.IServices;
using static WebAPPIStoreNovoAroma.IServices.ISecutityServices;

namespace WebAPPIStoreNovoAroma.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private IRolServices _rolServices;
        public RolController(ISecurityServices securityServices, IRolServices rolServices)
        {
            _securityServices = securityServices;
            _rolServices = rolServices;
        }

        [HttpPost(Name = "InsertarRol")]
        public int Post([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] Rol rolItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _rolServices.InsertRol(rolItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerRoles")]
        public List<Rol> GetAll([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _rolServices.GetAllRoles();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarRol")]
        public void Patch([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] Rol rolItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _rolServices.UpdateRol(rolItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarRol")]
        public void Delete([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _rolServices.DeleteRol(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}