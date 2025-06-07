using _3er_entregable.DAL.Entities;

namespace _3er_entregable.Domain.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStateByCountryAsync(Guid id); // Obtiene todos los estados de un pais, esta es una de las tantas firmas de método

        Task<State> CreateStateAsync(State state); // Crea un nuevo estado

        Task<State> GetStateByIdAsync(Guid id); // Obtiene un estado por su ID

        Task<State> EditStateAsync(State state); // Actualiza un estado existente

        Task<State> DeleteStateAsync(Guid id); // Elimina un estado existente

    }
}

