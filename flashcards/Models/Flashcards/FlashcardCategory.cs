using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Models.Flashcards
{
    public class FlashcardCategory
    {
        public FlashcardCategory(int category, string categoryName, string userAccountId)
        {
            this.category = category;
            this.categoryName = categoryName;
            this.userAccountId = userAccountId;
        }

        public int Category { get => category; }   
        public string CategoryName { get => categoryName; }
        public string UserAccountId { get => userAccountId; }
  
        private int category;
        private string categoryName;
        private string userAccountId;
    }
}
