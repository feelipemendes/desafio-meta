using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioMeta.Presentation.ViewModels;
using DesafioMeta.Entities;

namespace DesafioMeta.Presentation.Mappings
{
    public class ViewModelToEntityMap : Profile
    {
        public ViewModelToEntityMap()
        {
            CreateMap<ContatoCreateViewModel, Contato>();
            CreateMap<ContatoUpdateViewModel, Contato>();            
        }
    }
}
