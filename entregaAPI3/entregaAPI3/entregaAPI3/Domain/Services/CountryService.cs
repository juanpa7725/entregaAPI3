using _3er_entregable.DAL;
using _3er_entregable.DAL.Entities;
using _3er_entregable.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _3er_entregable.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            // Otra forma de hacerlo es
            // return await _context.Countries.ToListAsync();

            try
            {
                var contries = await _context.Countries.ToListAsync();
                return contries;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
                return country;
                // Otra forma de hacerlo es var country = await _context.Countries.FindAsync(id);
                // otra mas es var country = await _context.Countries.FirstAsync(c => c.Id == id);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid(); // Genera un nuevo ID para el país
                country.CreatedDate = DateTime.Now;
                _context.Countries.Add(country); // El metodo Add() me permite crear el objeto en el contexto de la BD
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
                return country; // Devuelve el país creado
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }
        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.CreatedDate = country.CreatedDate; // Mantiene la fecha de creación
                country.ModifiedDate = DateTime.Now; // Actualiza la fecha de modificación
                _context.Countries.Update(country); // Virtualizo mi objeto
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
                return country; // Devuelve el país actualizado
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);
                if (country == null)
                {
                    return  null; // Si el país no existe, devuelve null
                }
                _context.Countries.Remove(country); // Elimina el país de la base de datos
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
                return country; // Devuelve el país eliminado
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
