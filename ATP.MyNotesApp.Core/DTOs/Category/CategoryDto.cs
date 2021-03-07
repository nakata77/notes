using System;
using System.Collections.Generic;
using ATP.MyNotesApp.Core.DTOs.Note;

namespace ATP.MyNotesApp.Core.DTOs.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<NoteDto> Notes { get; set; }
    }
}
