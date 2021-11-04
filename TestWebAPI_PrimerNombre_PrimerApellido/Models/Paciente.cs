using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebAPI_PrimerNombre_PrimerApellido.Models
{
    public partial class Paciente
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
