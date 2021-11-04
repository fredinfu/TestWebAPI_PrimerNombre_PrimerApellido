using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebAPI_PrimerNombre_PrimerApellido.Models
{
    public partial class Vacuna
    {
        public Vacuna()
        {
            VacunacionCovid19s = new HashSet<VacunacionCovid19>();
        }

        public int VacunaId { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<VacunacionCovid19> VacunacionCovid19s { get; set; }
    }
}
