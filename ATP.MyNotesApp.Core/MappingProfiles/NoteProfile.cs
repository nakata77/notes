using ATP.MyNotesApp.Core.DTOs.Note;
using ATP.MyNotesApp.Core.Entitties;
using AutoMapper;

namespace ATP.MyNotesApp.Core.MappingProfiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteDto>();
        }
    }
}
