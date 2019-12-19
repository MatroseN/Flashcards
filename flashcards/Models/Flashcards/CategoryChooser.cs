using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Models.Flashcards
{
    public class CategoryChooser
    {
        public CategoryChooser()
        {
            this.category = 1;
        }
        public int Category { get => category; set => category = value; }

        private int category;
    }
}
