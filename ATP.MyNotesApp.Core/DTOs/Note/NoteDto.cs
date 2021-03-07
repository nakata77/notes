using System;
using ATP.MyNotesApp.Core.Enums;

namespace ATP.MyNotesApp.Core.DTOs.Note
{
    public class NoteDto
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public Color? Color { get; set; }
    }
}
