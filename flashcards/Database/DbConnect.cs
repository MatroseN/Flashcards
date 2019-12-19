using MySql.Data.MySqlClient;

namespace Flashcards.Database{

    public class DbConnect{
        public DbConnect(){
            dbConnect();
        }

        private void dbConnect(){

           dbcon = new MySqlConnection(connectionString);
        } 

        public MySqlConnection getDbCon(){

            return dbcon;
        }

        private MySqlConnection dbcon;
        private string connectionString = "Server=localhost;Database=flashcards;User ID=root;Password=***;Pooling=false;SslMode=none;convert zero datetime=True;";
    }
}