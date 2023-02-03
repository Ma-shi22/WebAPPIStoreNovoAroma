using Entities.Entities;
using Entities.SearchFilters;

namespace WebAPPIStoreNovoAroma.IServices
{
    public interface IPersonaServices
    {
        int InsertPersona(Persona persona);
        void UpdatePersona(Persona persona);
        void DeletePersona(int id);
        List<Persona> GetAllPersonas();

    }   
}
