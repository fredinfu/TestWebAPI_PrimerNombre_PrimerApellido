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
    public class DosisController : ControllerBase
    {
        private readonly IApiRepository _repo;
        private readonly IMapper _mapper;
        public DosisController(IApiRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dosis = await _repo.GetDosisAsync();

            var dosisDto = _mapper.Map(dosis, typeof(IEnumerable<Dosi>), typeof(IEnumerable<DosisDto>));

            return Ok(dosisDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dosis = await _repo.GetDosisByIdAsync(id);

            if (dosis == null)
                return NotFound("Dosis no encontrada");

            var dosisDto = _mapper.Map(dosis, typeof(Dosi), typeof(DosisDto));

            return Ok(dosisDto);
        }

        [HttpGet("descripcion/{descripcion}")]
        public async Task<IActionResult> Get(string descripcion)
        {
            var dosis = await _repo.GetDosisByDescripcion(descripcion);

            if (dosis == null)
                return NotFound("Dosis no encontrada");

            var dosisDto = _mapper.Map(dosis, typeof(Dosi), typeof(DosisDto));

            return Ok(dosisDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DosisDto dosisDto)
        {
            if (id != dosisDto.DosisVacunaId)
                return BadRequest("Los Ids no coinciden");
            var dosisToUpdate = await _repo.GetDosisByIdAsync(dosisDto.DosisVacunaId);

            if (dosisToUpdate == null)
                return BadRequest("Dosis not found.");

            _mapper.Map(dosisDto, dosisToUpdate);

            if (await _repo.SaveAll() == false)
                return NoContent();

            return Ok(dosisToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DosisDto dosis)
        {
            var dosisToCreate = _mapper.Map<Dosi>(dosis);

            _repo.Add(dosisToCreate);
            if (await _repo.SaveAll())
                return Ok(dosisToCreate);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var dosis = await _repo.GetDosisByIdAsync(id);
                if (dosis == null)
                    return NotFound("dosis no encontrada");

                dosis.Estado = false;
                if (!await _repo.SaveAll())
                    return BadRequest("No se pudo eliminar la dosis.");

                return Ok("dosis borrada");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
