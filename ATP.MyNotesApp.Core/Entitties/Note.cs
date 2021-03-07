using System;
using System.Collections.Generic;
using ATP.MyNotesApp.Core.Enums;

namespace ATP.MyNotesApp.Core.Entitties
{
    public class Note
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public Color? Color { get; set; }

        public virtual ICollection<NoteCategory> Categories { get; set; }
    }
}
