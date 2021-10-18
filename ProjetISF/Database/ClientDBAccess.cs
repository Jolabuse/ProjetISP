using ProjetISF.Person;
using System.Data.SQLite;

namespace ProjetISF.Database
{
    public class ClientDBAccess : IClientDataAccess
    {
        public void GetAll()
        {
            //TODO
        }

        public void CreateUser()
        {
            //ToDO
        }

        public Client GetClient(int guid)
        {
            //TODO
            return new Client();
        }

        public void UpdateClient(Client c)
        {
            //TODO
        }

        public void DeleteClient(int guid)
        {
            //TODO
        }

        public void CreateDatabase()
        {
            string cs = @"URI=file:C:\Users\jonat\tp3cs\ProjetISF\ProjetISF\Database\ProjetISF";
            using var con = new SQLiteConnection(cs);
            con.Open();
            using var cmd = new SQLiteCommand(con);
            cmd.CommandText = "DROP TABLE IF EXISTS Client";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "CREATE TABLE Client(id INTEGER PRIMARY KEY,"
             +"firstname VARCHAR(20),name VARCHAR(20))";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Client(firstname,name) VALUES ('WITT','Jonathan')";
        }
    }
}