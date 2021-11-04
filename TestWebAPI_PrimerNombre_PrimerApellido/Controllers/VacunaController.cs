using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI_PrimerNombre_PrimerApellido.Dtos;
using TestWebAPI_PrimerNombre_PrimerApellido.Models;
using TestWebAPI_PrimerNombre_PrimerApellido.Repositories.Interfaces;

namespace TestWebAPI_PrimerNombre_PrimerApellido.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacunaController : ControllerBase
    {
        private readonly IApiRepository _repo;
        private readonly IMapper _mapper;
        public VacunaController(IApiRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vacuna = await _repo.GetVacunasAsync();

            var vacunaDto = _mapper.Map(vacuna, typeof(IEnumerable<Vacuna>), typeof(IEnumerable<VacunaDto>));

            return Ok(vacunaDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vacuna = await _repo.GetVacunaByIdAsync(id);

            if (vacuna == null)
                return NotFound("Vacuna no encontrada");

            var vacunaDto = _mapper.Map(vacuna, typeof(Vacuna), typeof(VacunaDto));

            return Ok(vacunaDto);
        }

        [HttpGet("descripcion/{descripcion}")]
        public async Task<IActionResult> Get(string descripcion)
        {
            var vacuna = await _repo.GetVacunaByDescripcion(descripcion);

            if (vacuna == null)
                return NotFound("Vacuna no encontrada");

            var vacunaDto = _mapper.Map(vacuna, typeof(Vacuna), typeof(VacunaDto));

            return Ok(vacunaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, VacunaDto vacunaDto)
        {
            if (id != vacunaDto.VacunaId)
                return BadRequest("Los Ids no coinciden");
            var vacunaToUpdate = await _repo.GetVacunaByIdAsync(vacunaDto.VacunaId);

            if (vacunaToUpdate == null)
                return BadRequest("Vacuna not found.");

            _mapper.Map(vacunaDto, vacunaToUpdate);

            if (await _repo.SaveAll() == false)
                return NoContent();

            return Ok(vacunaToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VacunaDto vacuna)
        {
            var vacunaToCreate = _mapper.Map<Vacuna>(vacuna);

            _repo.Add(vacunaToCreate);
            if (await _repo.SaveAll())
                return Ok(vacunaToCreate);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var vacuna = await _repo.GetVacunaByIdAsync(id);
                if (vacuna == null)
                    return NotFound("vacuna no encontrada");

                vacuna.Estado = false;
                if (!await _repo.SaveAll())
                    return BadRequest("No se pudo eliminar la vacuna.");

                return Ok("vacuna borrada");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
