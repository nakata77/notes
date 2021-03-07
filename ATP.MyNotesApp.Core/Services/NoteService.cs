using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATP.MyNotesApp.Core.DTOs.Note;
using ATP.MyNotesApp.Core.Entitties;
using ATP.MyNotesApp.Core.Interfaces.Repositories;
using ATP.MyNotesApp.Core.Interfaces.Services;
using AutoMapper;

namespace ATP.MyNotesApp.Core.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;
        private readonly IMapper _mapper;

        public NoteService(
            IRepository<Note> noteRepository,
            IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NoteDto>> GetAsync()
        {
            var notes = await _noteRepository.GetAllAsync();

            return notes.Select(n => _mapper.Map<NoteDto>(n));
        }

        public async Task<NoteDto> GetAsync(Guid id)
        {
            var note = await _noteRepository.GetAsync(id);

            return  _mapper.Map<NoteDto>(note);
        }

        public async Task<NoteDto> CreateAsync(ManageNoteDto request)
        {
            if (request is null)
                throw new ArgumentException("Request cannot be null!");

            var noteToAdd = new Note
            {
                Title = request.Title,
                Text = request.Text,
                Color = request.Color,
                Date = DateTime.UtcNow
            };

            _noteRepository.Add(noteToAdd);
            await _noteRepository.SaveChangesAsync();

            return _mapper.Map<NoteDto>(noteToAdd);
        }

        public async Task<NoteDto> UpdateAsync(Guid id, ManageNoteDto request)
        {
            if (request is null)
                throw new ArgumentException("Request cannot be null!");

            var note = await _noteRepository.GetAsync(id);

            if (note is null)
                return null;

            note.Title = request.Title;
            note.Text = request.Text;
            note.Color = request.Color;

            _noteRepository.Update(note);
            await _noteRepository.SaveChangesAsync();

            return _mapper.Map<NoteDto>(note);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var note = await _noteRepository.GetAsync(id);

            if (note is null)
                return false;

            _noteRepository.Remove(note);
            await _noteRepository.SaveChangesAsync();

            return true;
        }
    }
}
