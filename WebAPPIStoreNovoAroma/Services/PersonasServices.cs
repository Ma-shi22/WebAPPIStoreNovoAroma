using Entities.Entities;
using Logic.ILogic;
using WebAPPIStoreNovoAroma.IServices;
using Logic.Logic;

namespace WebAPPIStoreNovoAroma.Services
{
    public class PersonaServices : IPersonaServices
    {
        private readonly IPersonaLogic _personaLogic;
        public PersonaServices(IPersonaLogic personaLogic)
        {
            _personaLogic = personaLogic;
        }


        public int InsertPersona(Persona personaItem)
        {
            _personaLogic.InsertPersona(personaItem);
            return personaItem.Id;
        }


        public void UpdatePersona(Persona personaItem)
        {
            _personaLogic.UpdatePersona(personaItem);
        }

        public void DeletePersona(int id)
        {
            _personaLogic.DeletePersona(id);
        }

        public List<Persona> GetAllPersonas()
        {
            return _personaLogic.GetAllPersonas();
        }



    }
}

