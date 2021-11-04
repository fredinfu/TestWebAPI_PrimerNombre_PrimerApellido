using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI_PrimerNombre_PrimerApellido.Dtos
{
    public class DosisDto
    {
        public DosisDto()
        {
            Estado = true;
        }
        public int DosisVacunaId { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        
    }
}
