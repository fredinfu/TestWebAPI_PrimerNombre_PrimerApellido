using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI_PrimerNombre_PrimerApellido.Repositories.Interfaces;

namespace TestWebAPI_PrimerNombre_PrimerApellido.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DosisController : ControllerBase
    {
        private readonly IApiRepository _repository;
        public DosisController(IApiRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dosis = await _repository.GetDosisAsync();

            return Ok(dosis);
        }
    }
}
