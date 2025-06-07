using _3er_entregable.DAL.Entities;
using _3er_entregable.Domain.Interfaces;
using _3er_entregable.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace _3er_entregable.Controllers
{
    [Route("api/[controller]")] // define el nombre inicial de mi RUTA o uURL
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync();

            if (countries == null || !countries.Any()) return NotFound(); // Not found = Status code 404

            return Ok(countries); // Ok = Status code 200
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] // URL: api/countries/GetById/get
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            var country = await _countryService.GetCountryByIdAsync(id);

            if (country == null) return NotFound(); // Not found = Status code 404

            return Ok(country); // Ok = Status code 200
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            try
            {
                var newCountry = await _countryService.CreateCountryAsync(country);
                if (newCountry == null) return NotFound(); // Notfound = Status code 404
                return Ok(newCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));

                return Conflict(ex.Message);
                
            }

        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editedCountry = await _countryService.EditCountryAsync(country);
                if (editedCountry == null) return NotFound(); // Notfound = Status code 404
                return Ok(editedCountry); // Ok = Status code 200
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        {
            if (id == null) return BadRequest(); // BadRequest = Status code 400

            var deletedCountry = await _countryService.DeleteCountryAsync(id);
            if (deletedCountry == null) return NotFound(); // Not found = Status code 404
            return Ok(deletedCountry); // Ok = Status code 200
        }


    }
}
