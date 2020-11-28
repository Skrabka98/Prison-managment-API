﻿using PrisonBack.Domain.Models;
using PrisonBack.Resources.DTOs;
using AutoMapper;
using PrisonBack.Resources.ViewModels;
using PrisonBack.Resources;

namespace PrisonBack.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Cell, CellVM>();
            CreateMap<CellDTO, Cell>();
            CreateMap<Punishment, PunishmentVM>();
            CreateMap<PunishmentDTO, Punishment>();
            CreateMap<Prisoner, PrisonerVM>();
            CreateMap<PrisonerDTO, Prisoner>();
            CreateMap<Pass, PassVM>();
            CreateMap<PassDTO, Pass>();


        }
    }
}
