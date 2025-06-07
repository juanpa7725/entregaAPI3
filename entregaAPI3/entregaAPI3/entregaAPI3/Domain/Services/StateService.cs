using _3er_entregable.DAL;
using _3er_entregable.DAL.Entities;
using _3er_entregable.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _3er_entregable.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _context;

        public StateService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<State>> GetStateByCountryAsync(Guid id)
        {
            // Otra forma de hacerlo es
            // return await _context.Countries.ToListAsync();

            try
            {
                var states = await _context.States.Where(s => s.CountryId == id).ToListAsync(); // Obtiene todos los estados que pertenecen al país con el ID especificado
                return states;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<State> GetStateByIdAsync(Guid id)
        {
            try
            {
                var states = await _context.States.FirstOrDefaultAsync(s => s.Id == id); // Obtiene un estado por su ID
                return states;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<State> CreateStateAsync(State state)
        {
            try
            {
                state.CreatedDate = DateTime.Now; // Asigna la fecha de creación al estado
                state.Id = Guid.NewGuid(); // Genera un nuevo ID para el estado
                state.Equals(state.CountryId); // Asegura que el estado esté asociado al país correcto
                _context.States.Add(state); // Agrega el estado al contexto de la base de datos
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
                return state; // Devuelve el estado creado

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<State> EditStateAsync(State state)
        {
            try
            {
                state.CreatedDate = state.CreatedDate; // Mantiene la fecha de creación original
                state.ModifiedDate = DateTime.Now; // Actualiza la fecha de modificación al momento actual
                _context.States.Update(state); // Actualiza el estado en el contexto de la base de datos
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
                return state; // Devuelve el estado actualizado

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await GetStateByIdAsync(id);
                if(state == null)
                {
                    return null; // Si el estado no existe, retorna null
                }
                _context.States.Remove(state); // Elimina el estado del contexto de la base de datos
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
                return state; // Devuelve el estado eliminado

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        
    }
}
