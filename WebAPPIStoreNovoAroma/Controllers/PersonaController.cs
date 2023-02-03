using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using WebAPPIStoreNovoAroma.IServices;
using static WebAPPIStoreNovoAroma.IServices.ISecutityServices;

namespace WebAPPIStoreNovoAroma.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonaController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private IPersonaServices _personaServices;
        public PersonaController(ISecurityServices securityServices, IPersonaServices personaServices)
        {
            _securityServices = securityServices;
            _personaServices = personaServices;
        }

        [HttpPost(Name = "InsertarPersona")]
        public int Post([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] Persona personaItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _personaServices.InsertPersona(personaItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerPersonas")]
        public List<Persona> GetAllPersonas([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _personaServices.GetAllPersonas();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarPersona")]
        public void Patch([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] Persona personaItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _personaServices.UpdatePersona(personaItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarPersona")]
        public void Delete([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _personaServices.DeletePersona(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}
