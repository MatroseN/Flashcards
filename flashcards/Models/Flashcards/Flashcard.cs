using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Models.Flashcards
{
    public class Flashcard
    {
        public Flashcard(int iD, string label, int category, string question, string answer, string userAccountId)
        {
            this.iD = iD;
            this.label = label;
            this.category = category;
            this.question = question;
            this.answer = answer;
            this.userAccountId = userAccountId;

            initialize();
        }

        private void initialize()
        {
            visibleQuestionOrAnswer = question;
            showQuestion = true;
            showAnswer = false;
        }

        public int ID { get => iD;}
        public string Label { get => label;}
        public int Category { get => category;}
        public string Question { get => question;}
        public string Answer { get => answer;}
        public string VisibleQuestionOrAnswer { get => visibleQuestionOrAnswer; }
        public string UserAccountId { get => userAccountId;}

        private int iD;
        private string label;
        private int category;
        private string question;
        private string answer;
        private string userAccountId;

        private string visibleQuestionOrAnswer;
        private bool showQuestion;
        private bool showAnswer;
    }
}
