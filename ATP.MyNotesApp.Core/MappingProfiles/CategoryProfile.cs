using System.Linq;
using ATP.MyNotesApp.Core.DTOs.Category;
using ATP.MyNotesApp.Core.Entitties;
using AutoMapper;

namespace ATP.MyNotesApp.Core.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dto => dto.Notes, conf => conf.MapFrom(m => m.Notes.Select(s => s.Note)));
        }
    }
}
