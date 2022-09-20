using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Extensions
{
    public class MappingProfileExtensions : Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<CiudadesViewModel, tbCiudades>().ReverseMap();
        }
    }
}
