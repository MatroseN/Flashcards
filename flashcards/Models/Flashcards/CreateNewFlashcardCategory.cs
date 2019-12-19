using Flashcards.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Models.Flashcards
{
    public class CreateNewFlashcardCategory
    {
        public void createNewFlashcardCategory(string userId, string categoryName)
        {
           
            dbcon = new DbConnect();
            statement = new Statement("CALL createNewFlashcardCategory(@userId, @categoryName)");
            dbcon.getDbCon().Open();

            MySqlCommand sqlCmd = new MySqlCommand(statement.getStatement(), dbcon.getDbCon());
            sqlCmd.Parameters.AddWithValue("@userId", userId);
            sqlCmd.Parameters.AddWithValue("@categoryName", categoryName);

            var result = sqlCmd.ExecuteNonQuery();
          
            dbcon.getDbCon().Close();
        }

        public string SqlState45000 { get => sqlState45000; set => sqlState45000 = value; }

        private string sqlState45000;
        private DbConnect dbcon;
        private Statement statement;
    }
}
