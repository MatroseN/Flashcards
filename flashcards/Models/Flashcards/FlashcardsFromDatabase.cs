using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Database;
using Flashcards.Models;
using MySql.Data.MySqlClient;

namespace Flashcards.Models.Flashcards
{
    public class FlashcardsFromDatabase
    {
        public FlashcardsFromDatabase(string userAccountId)
        {
            initialize();
            addTableToList(getFlashcards(userAccountId));
        }

        private void initialize()
        {
            flashcards = new List<Flashcard>();
        }

        private DataTable getFlashcards(string userAccountId)
        {
            dbcon = new DbConnect();
            statement = new Statement("call getAllUserFlashcards(@userAccountId);");
            dataAdapter = new DataAdapter(dbcon);

            dbcon.getDbCon().Open();

            dataAdapter.dataAdapter(statement.getStatement());
            dataAdapter.GetDataAdapter().SelectCommand.Parameters.AddWithValue("@userAccountId", userAccountId);
            DataSet ds = new DataSet();
            dataAdapter.GetDataAdapter().Fill(ds, "result");
            flashcardTable = ds.Tables["result"];

            return flashcardTable;
        }

        private void addTableToList(DataTable flashCardTable)
        {
            foreach (DataRow row in flashCardTable.Rows)
            {
               int iD = row.Field<int>("flashcardId");
               string label = row.Field<string>("flashcardName");
               int category = row.Field<int>("category");
               string question = row.Field<string>("question");
               string answer = row.Field<string>("answer");
               string userAccountId = row.Field<string>("userAccountId");

                flashcards.Add(new Flashcard(iD, label, category, question, answer, userAccountId));
            }
        }

        public string getFlashcardQuestion(int flashcardId)
        {
            foreach (var flashcard in flashcards)
            {
                if (flashcard.ID == flashcardId)
                {
                    return flashcard.Question;
                }
            }
            return null;
        }

        public Flashcard getFlashcardWithId(int id)
        {
            foreach (var flashcard in flashcards)
            {
                if (flashcard.ID == id)
                {
                    return flashcard;
                }
            }

            return null;
        }

        public List<Flashcard> GetFlashcards { get => flashcards; }

        private List<Flashcard> flashcards;

        private DbConnect dbcon;
        private Statement statement;
        private DataAdapter dataAdapter;

        private DataTable flashcardTable;
    }
}
