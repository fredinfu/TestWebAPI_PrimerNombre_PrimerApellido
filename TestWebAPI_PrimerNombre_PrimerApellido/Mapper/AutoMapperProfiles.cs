using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestWebAPI_PrimerNombre_PrimerApellido.Dtos;
using TestWebAPI_PrimerNombre_PrimerApellido.Models;

namespace TestWebAPI_PrimerNombre_PrimerApellido.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // -- -- Dosis Mapper Profiles -- --
            //PUT / POST
            CreateMap<DosisDto, Dosi>();
            //GET 
            CreateMap<Dosi, DosisDto>();

            // -- -- Vacuna Mapper Profiles -- --
            //PUT / POST
            CreateMap<VacunaDto, Vacuna>();
            //GET 
            CreateMap<Vacuna, VacunaDto>();

            // -- -- Paciente Mapper Profiles -- --
            //PUT / POST
            CreateMap<PacienteDto, Paciente>();
            //GET 
            CreateMap<Paciente, PacienteDto>();

            // -- -- VacunacionCovid19 Mapper Profiles -- --
            //PUT / POST
            CreateMap<VacunacionCovid19Dto, VacunacionCovid19>();
            //GET 
            CreateMap<VacunacionCovid19, VacunacionCovid19Dto>();

        }
    }
}
