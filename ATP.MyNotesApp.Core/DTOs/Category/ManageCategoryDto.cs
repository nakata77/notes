using System;
using System.Collections.Generic;

namespace ATP.MyNotesApp.Core.DTOs.Category
{
    public class ManageCategoryDto
    {
        public string Title { get; set; }

        public IEnumerable<Guid> Notes { get; set; }
    }
}
