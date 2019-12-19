using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Flashcards.Models;
using Flashcards.Models.Flashcards;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Flashcards.Controllers
{
    public class FlashcardController : Controller
    {
        public IActionResult Flashcard()
        {
            return View();
        }

        public IActionResult CreateNewFlashcard(string userId, int category, string flashcardLabel, string question, string answer)
        {
            createFlashcard = new CreateNewFlashcard();

            createFlashcard.createNewFlashcard(userId, category, flashcardLabel, question, answer);
            return RedirectToAction("Flashcard");
        }
        
        public IActionResult CreateNewFlashcardCategory(string userId, string categoryName)
        {
            createCategory = new CreateNewFlashcardCategory();

            createCategory.createNewFlashcardCategory(userId, categoryName);
            return RedirectToAction("Flashcard");
        }

        public IActionResult FlashcardByCategory(int category)
        {          
            ViewBag.ChosenCategory = category;

            return View();
        }

        CreateNewFlashcard createFlashcard;
        CreateNewFlashcardCategory createCategory;
    }
}