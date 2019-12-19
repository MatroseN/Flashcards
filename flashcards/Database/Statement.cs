
namespace Flashcards.Database
{
    public class Statement{
        public Statement(string statement){
            this.statement = statement;
        }
        public string getStatement(){
            return statement;
        }
        private string statement;
    }
}