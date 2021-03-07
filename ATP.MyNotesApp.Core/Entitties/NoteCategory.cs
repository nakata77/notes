using System;

namespace ATP.MyNotesApp.Core.Entitties
{
    public class NoteCategory
    {
        public Guid NoteId { get; set; }

        public virtual Note Note { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
