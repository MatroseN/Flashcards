using MySql.Data.MySqlClient;

namespace Flashcards.Database{

    public class DbConnect{
        public DbConnect(){
            initialize();
            dbConnect();
        }

        private void initialize() {
            connectionString = new DbConnectionString();
        }

        private void dbConnect(){

           dbcon = new MySqlConnection(connectionString.ConnectionString);
        } 

        public MySqlConnection getDbCon(){

            return dbcon;
        }

        private MySqlConnection dbcon;

        // If this class doesnt exist create it for storing and getting a connectionstring to the database
        private DbConnectionString connectionString;
    }
}