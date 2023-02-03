using WebAPPIStoreNovoAroma.IServices;
using WebAPPIStoreNovoAroma.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using IProductoServices = WebAPPIStoreNovoAroma.IServices.IProductoServices;
using static WebAPPIStoreNovoAroma.IServices.ISecutityServices;

namespace APIService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductoController : ControllerBase
    {
        private ISecutityServices.ISecurityServices _securityServices;
        private IProductoServices _productoServices;
        public ProductoController(ISecurityServices securityServices, IProductoServices productoServices)
        {
            _securityServices = securityServices;
            _productoServices = productoServices;
        }

        [HttpPost(Name = "InsertarProducto")]
        public int Post([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] Producto productoItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _productoServices.InsertProducto(productoItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerProductos")]
        public List<Producto> GetAllProductos([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _productoServices.GetAllProductos();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarProductosPorFiltro")]
        public List<Producto> GetProductosByCriteria([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] ProductoFilter productoFilter)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _productoServices.GetProductosByCriteria(productoFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarProducto")]
        public void Patch([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] Producto productoItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _productoServices.UpdateProducto(productoItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarProducto")]
        public void Delete([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _productoServices.DeleteProducto(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}
