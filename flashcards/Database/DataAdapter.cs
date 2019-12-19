
using MySql.Data.MySqlClient;

namespace Flashcards.Database{

    public class DataAdapter{
        public DataAdapter(DbConnect dbConnect){
            this.dbConnect = dbConnect;
        }
        public void dataAdapter(string statement){
          adapter = new MySqlDataAdapter(statement, dbConnect.getDbCon());
        }

        public MySqlDataAdapter GetDataAdapter(){
            return adapter;
        }

         private DbConnect dbConnect;
         private MySqlDataAdapter adapter;
    }
}