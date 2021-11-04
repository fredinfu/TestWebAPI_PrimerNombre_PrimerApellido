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
    public class PacienteController : ControllerBase
    {
        private readonly IApiRepository _repo;
        private readonly IMapper _mapper;
        public PacienteController(IApiRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var paciente = await _repo.GetPacientesAsync();

            var pacienteDto = _mapper.Map(paciente, typeof(IEnumerable<Paciente>), typeof(IEnumerable<PacienteDto>));

            return Ok(pacienteDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var paciente = await _repo.GetPacienteByIdAsync(id);

            if (paciente == null)
                return NotFound("Paciente no encontrada");

            var pacienteDto = _mapper.Map(paciente, typeof(Paciente), typeof(PacienteDto));

            return Ok(pacienteDto);
        }

        [HttpGet("expediente/{expediente}")]
        public async Task<IActionResult> Get(string expediente)
        {
            var paciente = await _repo.GetPacientesByExpediente(expediente);

            if (paciente == null)
                return NotFound("Paciente no encontrado");

            var pacienteDto = _mapper.Map(paciente, typeof(Paciente), typeof(PacienteDto));

            return Ok(pacienteDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PacienteDto pacienteDto)
        {
            if (id != pacienteDto.PacienteId)
                return BadRequest("Los Ids no coinciden");
            var pacienteToUpdate = await _repo.GetPacienteByIdAsync(pacienteDto.PacienteId);

            if (pacienteToUpdate == null)
                return BadRequest("Paciente not found.");

            _mapper.Map(pacienteDto, pacienteToUpdate);

            if (await _repo.SaveAll() == false)
                return NoContent();

            return Ok(pacienteToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PacienteDto paciente)
        {
            var pacienteToCreate = _mapper.Map<Paciente>(paciente);

            _repo.Add(pacienteToCreate);
            if (await _repo.SaveAll())
                return Ok(pacienteToCreate);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var paciente = await _repo.GetPacienteByIdAsync(id);
                if (paciente == null)
                    return NotFound("paciente no encontrado");

                _repo.Delete(paciente);
                if (!await _repo.SaveAll())
                    return BadRequest("No se pudo eliminar el paciente.");

                return Ok("paciente borrado");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
