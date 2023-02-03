using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using WebAPPIStoreNovoAroma.IService;
using WebAPPIStoreNovoAroma.IServices;
using static WebAPPIStoreNovoAroma.IServices.ISecutityServices;

namespace WebAPPIStoreNovoAroma.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClienteController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private IClienteServices _clienteServices;
        public ClienteController(ISecurityServices securityServices, IClienteServices clienteServices)
        {
            _securityServices = securityServices;
            _clienteServices = clienteServices;
        }

        [HttpPost(Name = "InsertarCliente")]
        public int Post([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] Cliente clienteItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _clienteServices.InsertCliente(clienteItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerClientes")]
        public List<Cliente> GetAllClientes([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _clienteServices.GetAllClientes();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarCliente")]
        public void Patch([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] Cliente clienteItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _clienteServices.UpdateCliente(clienteItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarCliente")]
        public void Delete([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _clienteServices.DeleteCliente(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarClientePorFiltro")]
        public List<Cliente> GetClientesByCriteria([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] ClienteFilter clienteFilter)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _clienteServices.GetClientesByCriteria(clienteFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}
