using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI_PrimerNombre_PrimerApellido.Dtos
{
    public class VacunacionCovid19Dto
    {
        public int VacunacionId { get; set; }
        public int? FkPacienteId { get; set; }
        public int? FkVacunaId { get; set; }
        public int? FkDosisId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }

        public virtual DosisDto FkDosis { get; set; }
        public virtual PacienteDto FkPaciente { get; set; }
        public virtual VacunaDto FkVacuna { get; set; }
    }
}
