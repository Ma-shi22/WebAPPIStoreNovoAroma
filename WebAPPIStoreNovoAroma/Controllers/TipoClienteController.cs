using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using WebAPPIStoreNovoAroma.IServices;
using static WebAPPIStoreNovoAroma.IServices.ISecutityServices;

namespace WebAPPIStoreNovoAroma.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoClienteController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private ITipoClienteServices _tipoClienteServices;
        public TipoClienteController(ISecurityServices securityServices, ITipoClienteServices tipoClienteServices)
        {
            _securityServices = securityServices;
            _tipoClienteServices = tipoClienteServices;
        }

        [HttpPost(Name = "InsertarTipoCliente")]
        public int Post([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] TipoCliente tipoClienteItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _tipoClienteServices.InsertTipoCliente(tipoClienteItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerTipoCliente")]
        public List<TipoCliente> GetAll([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _tipoClienteServices.GetAllTiposClientes();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarTipoCliente")]
        public void Patch([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] TipoCliente tipoClienteItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _tipoClienteServices.UpdateTipoCliente(tipoClienteItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarTipoCliente")]
        public void Delete([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _tipoClienteServices.DeleteTipoCliente(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}
