using MySql.Data.MySqlClient;

namespace Flashcards.Database{

    public class DbConnect{
        public DbConnect(){
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
        private DbConnectionString connectionString;
    }
}