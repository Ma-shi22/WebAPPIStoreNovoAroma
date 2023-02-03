using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Resource.RequestModels;
using System.Security.Authentication;
using Entities.SearchFilters;
using WebAPPIStoreNovoAroma.IServices;
using static WebAPPIStoreNovoAroma.IServices.ISecutityServices;

namespace WebAPPIStoreNovoAroma.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuarioController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private IUsuarioServices _usuarioServices;
        public UsuarioController(ISecurityServices securityServices, IUsuarioServices usuarioServices)
        {
            _securityServices = securityServices;
            _usuarioServices = usuarioServices;
        }

        [HttpPost(Name = "InsertarUsuario")]
        public int Post([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] NewUsuarioRequest newUsuarioRequest)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _usuarioServices.InsertUsuario(newUsuarioRequest);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerUsuarios")]
        public List<Usuario> GetAllUsuarios([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _usuarioServices.GetAllUsuarios();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarUsuario")]
        public void Patch([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] Usuario usuarioItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _usuarioServices.UpdateUsuario(usuarioItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarUsuario")]
        public void Delete([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _usuarioServices.DeleteUsuario(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

       //* [HttpGet(Name = "MostrarUsuarioPorFiltro")]
        //public List<Usuario> GetUsuariosByCriteria([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] Services.UsuarioFilter usuarioFilter)
        //{
           // var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
           // if (validCredentials == true)
           // {
               // return _usuarioServices.GetUsuariosByCriteria(usuarioFilter);
            //}
            //else
            //{
                //throw new InvalidCredentialException();
            } 
        }
    

