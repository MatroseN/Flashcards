using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Database;
using MySql.Data.MySqlClient;

namespace Flashcards.Models.Flashcards {
    public class DeleteFlashcard {
        // Tries to connect to Database and add the following information using a stored procedure from the database
        public void deleteFlashcard(int flashcardId, string userId) {
            dbcon = new DbConnect();
            statement = new Statement("CALL deleteSpecificFlashcard(@flashcardId, @userId )");
            dbcon.getDbCon().Open();

            MySqlCommand sqlCmd = new MySqlCommand(statement.getStatement(), dbcon.getDbCon());
            sqlCmd.Parameters.AddWithValue("@userId", userId);
            sqlCmd.Parameters.AddWithValue("@flashcardId", flashcardId);

            var result = sqlCmd.ExecuteNonQuery();

            dbcon.getDbCon().Close();
        }

        private DbConnect dbcon;
        private Statement statement;


    }
}
