using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.MyNotesApp.Core.Entitties
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<NoteCategory> Notes { get; set; }
    }
}
