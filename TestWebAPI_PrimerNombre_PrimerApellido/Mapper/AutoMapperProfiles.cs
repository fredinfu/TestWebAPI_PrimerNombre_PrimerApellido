﻿using System;
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
            //PUT / POST
            CreateMap<DosisDto, Dosi>();
            //GET 
            CreateMap<Dosi, DosisDto>();

        }
    }
}
