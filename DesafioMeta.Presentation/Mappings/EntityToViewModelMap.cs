using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioMeta.Presentation.ViewModels;
using DesafioMeta.Entities;
using AutoMapper;

namespace DesafioMeta.Presentation.Mappings
{
    public class EntityToViewModelMap : Profile
    {
        public EntityToViewModelMap()
        {   
            CreateMap<Contato, ContatoViewModel>();
        }
    }
}
