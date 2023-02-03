using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IPersonaLogic
    {
        int InsertPersona(Persona personaItem);
        void UpdatePersona(Persona personaItem);
        void DeletePersona(int id);
        List<Persona> GetAllPersonas();
    }
}
