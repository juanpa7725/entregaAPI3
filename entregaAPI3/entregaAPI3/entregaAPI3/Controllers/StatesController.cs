using _3er_entregable.DAL.Entities;
using _3er_entregable.Domain.Interfaces;
using _3er_entregable.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace _3er_entregable.Controllers
{
    [Route("api/[controller]")] // define el nombre inicial de mi RUTA o uURL
    [ApiController]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAllById/{CountryId}")] // URL: api/states/GetAllById/get
        public async Task<ActionResult<IEnumerable<State>>> GetStateByCountryAsync(Guid CountryId)
        {
            var states = await _stateService.GetStateByCountryAsync(CountryId);

            if (states == null || !states.Any()) return NotFound(); // Not found = Status code 404

            return Ok(states); // Ok = Status code 200
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] // URL: api/states/GetById/get
        public async Task<ActionResult<State>> GetStateByIdAsync(Guid id)
        {
            var state = await _stateService.GetStateByIdAsync(id);

            if (state == null) return NotFound(); // Not found = Status code 404

            return Ok(state); // Ok = Status code 200
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<State>> CreateStateAsync(State state)
        {
            try
            {
                var newState = await _stateService.CreateStateAsync(state);
                if (newState == null) return NotFound(); // Notfound = Status code 404
                return Ok(newState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", state.Name));

                return Conflict(ex.Message);

            }

        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> EditStateAsync(State state)
        {
            try
            {
                var editedState = await _stateService.EditStateAsync(state);
                if (editedState == null) return NotFound(); // Notfound = Status code 404
                return Ok(editedState); // Ok = Status code 200
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", state.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<State>> DeleteStateAsync(Guid id)
        {
            if (id == null) return BadRequest(); // BadRequest = Status code 400

            var deletedCountry = await _stateService.DeleteStateAsync(id);
            if (deletedCountry == null) return NotFound(); // Not found = Status code 404
            return Ok(deletedCountry); // Ok = Status code 200
        }


    }
}
