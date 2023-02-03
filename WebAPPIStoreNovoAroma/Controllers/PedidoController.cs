using WebAPPIStoreNovoAroma.Controllers;
using WebAPPIStoreNovoAroma.IServices;
using APIService.Controllers;
using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using Resource.RequestModels;
using System.Security.Authentication;
using static WebAPPIStoreNovoAroma.IServices.ISecutityServices;

namespace WebAPPIStoreNovoAroma.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PedidoController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private IPedidoServices _pedidoServices;
        public PedidoController(ISecurityServices securityServices, IPedidoServices pedidoServices)
        {
            _securityServices = securityServices;
            _pedidoServices = pedidoServices;
        }

        [HttpPost(Name = "InsertarPedido")]
        public int Post([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] NewPedidoRequest newPedidoRequest)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _pedidoServices.InsertPedido(newPedidoRequest);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerPedidos")]
        public List<Pedido> GetAllPedidos([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _pedidoServices.GetAllPedidos();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarPedidosPorFiltro")]
        public List<Pedido> GetPedidosByCriteria([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] PedidoFilter pedidoFilter)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _pedidoServices.GetPedidosByCriteria(pedidoFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarPedido")]
        public void Patch([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] Pedido pedido)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _pedidoServices.UpdatePedido(pedido);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarPedido")]
        public void Delete([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _pedidoServices.DeletePedido(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }


    }
}
