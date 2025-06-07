using _3er_entregable.DAL.Entities;

namespace _3er_entregable.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync(); // Obtiene todos los pa�ses, esta es una de las tantas firmas de m�todo

        Task<Country> CreateCountryAsync(Country country); // Crea un nuevo pa�s

        Task<Country> GetCountryByIdAsync(Guid id); // Obtiene un pa�s por su ID

        Task<Country> EditCountryAsync(Country country); // Actualiza un pa�s existente

        Task<Country> DeleteCountryAsync(Guid id); // Elimina un pa�s existente

    }
}

