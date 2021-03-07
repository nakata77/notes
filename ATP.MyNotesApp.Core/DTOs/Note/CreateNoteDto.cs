using System;
using ATP.MyNotesApp.Core.Enums;

namespace ATP.MyNotesApp.Core.DTOs.Note
{
    public class ManageNoteDto
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public Color? Color { get; set; }
    }
}
