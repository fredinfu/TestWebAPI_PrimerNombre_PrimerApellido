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
    public class VacunacionCovid19Controller : ControllerBase
    {
        private readonly IApiRepository _repo;
        private readonly IMapper _mapper;
        public VacunacionCovid19Controller(IApiRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vacunacionCovid19 = await _repo.GetVacunacionCovid19Async();

            var vacunacionCovid19Dto = vacunacionCovid19.Select(s => new VacunacionCovid19Dto
            {
                VacunacionId = s.VacunacionId,
                FkPaciente = new PacienteDto { PacienteId = s.FkPaciente.PacienteId, Expediente = s.FkPaciente.Expediente, Nombres = s.FkPaciente.Nombres, Apellidos=s.FkPaciente.Apellidos,Sexo=s.FkPaciente.Sexo},
                FkDosis = new DosisDto { DosisVacunaId = s.FkDosis.DosisVacunaId, Descripcion = s.FkDosis.Descripcion},
                FkVacuna = new VacunaDto { VacunaId = s.FkVacuna.VacunaId, Descripcion = s.FkVacuna.Descripcion}
            });

            return Ok(vacunacionCovid19Dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vacunacionCovid19 = await _repo.GetVacunacionCovid19ByIdAsync(id);

            if (vacunacionCovid19 == null)
                return NotFound("VacunacionCovid19 no encontrada");

            var vacunacionCovid19Dto = _mapper.Map(vacunacionCovid19, typeof(VacunacionCovid19), typeof(VacunacionCovid19Dto));

            return Ok(vacunacionCovid19Dto);
        }

        [HttpGet("PacienteId/{PacienteId}")]
        public async Task<IActionResult> GetVacunacionByPacienteId(int vacunacionCovid19Id)
        {
            var vacunacionCovid19 = await _repo.GetVacunacionCovid19ByPacienteIdAsync(vacunacionCovid19Id);

            if (vacunacionCovid19 == null)
                return NotFound("Vacunacion no encontrada");

            var vacunacionCovid19Dto = _mapper.Map(vacunacionCovid19, typeof(VacunacionCovid19), typeof(VacunacionCovid19Dto));

            return Ok(vacunacionCovid19Dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, VacunacionCovid19Dto vacunacionCovid19Dto)
        {
            if (id != vacunacionCovid19Dto.VacunacionId)
                return BadRequest("Los Ids no coinciden");
            var vacunacionCovid19ToUpdate = await _repo.GetVacunacionCovid19ByIdAsync(vacunacionCovid19Dto.VacunacionId);

            if (vacunacionCovid19ToUpdate == null)
                return BadRequest("VacunacionCovid19 not found.");

            _mapper.Map(vacunacionCovid19Dto, vacunacionCovid19ToUpdate);

            if (await _repo.SaveAll() == false)
                return NoContent();

            return Ok(vacunacionCovid19ToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VacunacionCovid19Dto vacunacionCovid19)
        {
            var vacunacionCovid19ToCreate = _mapper.Map<VacunacionCovid19>(vacunacionCovid19);

            _repo.Add(vacunacionCovid19ToCreate);
            if (await _repo.SaveAll())
                return Ok(vacunacionCovid19ToCreate);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var vacunacionCovid19 = await _repo.GetVacunacionCovid19ByIdAsync(id);
                if (vacunacionCovid19 == null)
                    return NotFound("vacunacionCovid19 no encontrado");

                _repo.Delete(vacunacionCovid19);
                if (!await _repo.SaveAll())
                    return BadRequest("No se pudo eliminar el vacunacionCovid19.");

                return Ok("vacunacionCovid19 borrado");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
