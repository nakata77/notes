using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATP.MyNotesApp.Core.DTOs.Note;

namespace ATP.MyNotesApp.Core.Interfaces.Services
{
    public interface INoteService
    {
        Task<IEnumerable<NoteDto>> GetAsync();

        Task<NoteDto> GetAsync(Guid id);

        Task<NoteDto> CreateAsync(ManageNoteDto request);

        Task<NoteDto> UpdateAsync(Guid id, ManageNoteDto request);

        Task<bool> DeleteAsync(Guid id);
    }
}
