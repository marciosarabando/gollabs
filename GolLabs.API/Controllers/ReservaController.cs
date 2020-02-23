using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GolLabs.Repository;
using Microsoft.AspNetCore.Http;
using GolLabs.Domain;

namespace GolLabs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IGolLabsRepository _repo;

        public ReservaController(IGolLabsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllReservaAsync();
                return Ok(results);    
            }
            catch (System.Exception)
            {;
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou Aqui");
                throw;
            }
        }

        // GET /reserva/{ReservaId}
        [HttpGet("{ReservaId}")]
        public async Task<IActionResult> Get(int EventoId)
        {
            try
            {
                var results = await _repo.GetAllReservaAsyncById(EventoId);
                return Ok(results);    
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Post(Reserva model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/reserva/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
            return BadRequest();
        }

        // PUT
        [HttpPut("{ReservaId}")]
        public async Task<IActionResult> Put(int ReservaId, Reserva model)
        {
            try
            {
                var reserva = await _repo.GetAllReservaAsyncById(ReservaId);
                if(reserva == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/reserva/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
            return BadRequest();
        }

        // DELETE
        [HttpDelete("{ReservaId}")]
        public async Task<IActionResult> Delete(int ReservaId)
        {
            try
            {
                var evento = await _repo.GetAllReservaAsyncById(ReservaId);
                if(evento == null) return NotFound();

                _repo.Delete(evento);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
            return BadRequest();
        }

        
        
    }
}