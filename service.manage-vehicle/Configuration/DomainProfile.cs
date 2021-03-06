﻿using AutoMapper;
using domain.manage_vehicle.Entity;
using domain.manage_vehicle.Entity.Venda;
using service.manage_vehicle.DTO;

namespace service.manage_vehicle.Configuration
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<VendaEntity, VendaDTO>().ReverseMap();
            CreateMap<VendedorEntity, VendedorDTO>().ReverseMap();
            CreateMap<VeiculoEntity, VeiculoDTO>().ReverseMap();
        }
    }
}
