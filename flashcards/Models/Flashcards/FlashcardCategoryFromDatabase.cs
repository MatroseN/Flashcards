using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Database;

namespace Flashcards.Models.Flashcards
{
    public class FlashcardCategoryFromDatabase
    {
        public FlashcardCategoryFromDatabase(string userAccountId)
        {
            initialize();
            addTableToList(getFlashcardCategories(userAccountId));
        }

        private void initialize()
        {
            flashcardCategories = new List<FlashcardCategory>();
        }

        // Tries to get the FlashcardCategories for the specific user
        private DataTable getFlashcardCategories(string userAccountId)
        {
            dbcon = new DbConnect();
            statement = new Statement("call getAllflashcardCategoriesForUser(@userAccountId);");
            dataAdapter = new DataAdapter(dbcon);

            dbcon.getDbCon().Open();

            dataAdapter.dataAdapter(statement.getStatement());
            dataAdapter.GetDataAdapter().SelectCommand.Parameters.AddWithValue("@userAccountId", userAccountId);
            DataSet ds = new DataSet();
            dataAdapter.GetDataAdapter().Fill(ds, "result");
            flashcardCategoryTable = ds.Tables["result"];

            return flashcardCategoryTable;
        }

        // Adds the information fetched from getFlashcardCategories to a list of FlashcardCategories
        private void addTableToList(DataTable flashCardCategoryTable)
        {
            foreach (DataRow row in flashCardCategoryTable.Rows)
            {
                int categoryCode = row.Field<int>("categoryCode");
                string categoryName = row.Field<string>("categoryName");
                string userAccountId = row.Field<string>("userAccountId");

                flashcardCategories.Add(new FlashcardCategory(categoryCode, categoryName, userAccountId));
            }
        }

        public List<FlashcardCategory> GetFlashcardCategories { get => flashcardCategories; }

        private List<FlashcardCategory> flashcardCategories;

        private DbConnect dbcon;
        private Statement statement;
        private DataAdapter dataAdapter;

        private DataTable flashcardCategoryTable;
    }
}
