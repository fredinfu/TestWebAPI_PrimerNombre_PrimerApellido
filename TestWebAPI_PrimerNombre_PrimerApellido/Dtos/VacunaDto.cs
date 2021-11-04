using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI_PrimerNombre_PrimerApellido.Dtos
{
    public class VacunaDto
    {
        public VacunaDto()
        {
            Estado = true;
        }
        public int VacunaId { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        
    }
}
