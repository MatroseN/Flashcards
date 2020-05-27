using Flashcards.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Models.Flashcards
{
    public class CreateNewFlashcard
    {
        // Tries to connect to Database and add the following information using a stored procedure from the database
        public void createNewFlashcard(string userId, int category, string flashcardLabel, string question, string answer)
        {        
            dbcon = new DbConnect();
            statement = new Statement("CALL createNewFlashcard(@userId, @category, @flashcardLabel, @question, @answer)");
            dbcon.getDbCon().Open();

            MySqlCommand sqlCmd = new MySqlCommand(statement.getStatement(), dbcon.getDbCon());
            sqlCmd.Parameters.AddWithValue("@userId", userId);
            sqlCmd.Parameters.AddWithValue("@category", category);
            sqlCmd.Parameters.AddWithValue("@flashcardLabel", flashcardLabel);
            sqlCmd.Parameters.AddWithValue("@question", question);
            sqlCmd.Parameters.AddWithValue("@answer", answer);
            
            var result = sqlCmd.ExecuteNonQuery();
            
            dbcon.getDbCon().Close();
        }

        private DbConnect dbcon;
        private Statement statement;

        
    }
}
