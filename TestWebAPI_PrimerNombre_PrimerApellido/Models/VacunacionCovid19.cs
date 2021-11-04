using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebAPI_PrimerNombre_PrimerApellido.Models
{
    public partial class VacunacionCovid19
    {
        public int VacunacionId { get; set; }
        public int? FkPacienteId { get; set; }
        public int? FkVacunaId { get; set; }
        public int? FkDosisId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }

        public virtual Dosi FkDosis { get; set; }
        public virtual Vacuna FkVacuna { get; set; }
    }
}
