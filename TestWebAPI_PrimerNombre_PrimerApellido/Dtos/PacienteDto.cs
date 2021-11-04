using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI_PrimerNombre_PrimerApellido.Dtos
{
    public class PacienteDto
    {
        public int PacienteId { get; set; }
        public string Expediente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        public string TipoEdad { get; set; }
    }
}
