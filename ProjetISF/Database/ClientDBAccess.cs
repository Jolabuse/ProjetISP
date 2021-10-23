using System;
using System.Data;
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
            cmd.CommandText = "CREATE TABLE Client(id VARCHAR(40) PRIMARY KEY,"
                              + "firstname VARCHAR(20),name VARCHAR(20),"
                              +"pin INTEGER,currency VARCHAR(20))";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "DROP TABLE IF EXISTS Money";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "CREATE TABLE Money(id VARCHAR(40),"
                              + "currency VARCHAR(20),value INTEGER,"+
                              "FOREIGN KEY (id) REFERENCES Client(id))";
            cmd.ExecuteNonQuery();
        }

        public void FillTables()
        {
            string cs = @"URI=file:C:\Users\jonat\tp3cs\ProjetISF\ProjetISF\Database\ProjetISF";
            using var con = new SQLiteConnection(cs);
            con.Open();
            using var cmd = new SQLiteCommand(con);
            
            Guid g = Guid.NewGuid();
            string gs = g.ToString();
            cmd.CommandText = "INSERT INTO Client(id,firstname,name,pin,currency) "
                              +"VALUES(@p1,'Jonathan','WITT',1111,'Euro')";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "INSERT INTO Money(id,currency,value) "
                              +"VALUES(@p1,'Euro',1100)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "INSERT INTO Money(id,currency,value) "
                              +"VALUES(@p1,'Dollar',50)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "INSERT INTO Money(id,currency,value) "
                              +"VALUES(@p1,'Yen',25000)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.ExecuteNonQuery();
            
            
            
            g = Guid.NewGuid();
            gs = g.ToString();
            cmd.CommandText = "INSERT INTO Client(id,firstname,name,pin,currency) "
                              +"VALUES(@p1,'Adrien','GIRARD',1234,'Euro')";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "INSERT INTO Money(id,currency,value) "
                              +"VALUES(@p1,'Euro',2100)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "INSERT INTO Money(id,currency,value) "
                              +"VALUES(@p1,'Dollar',500)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "INSERT INTO Money(id,currency,value) "
                              +"VALUES(@p1,'Yen',25)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.ExecuteNonQuery();
            
            g = Guid.NewGuid();
            gs = g.ToString();
            cmd.CommandText = "INSERT INTO Client(id,firstname,name,pin,currency) "
                              +"VALUES(@p1,'Yann','COURTEMANCHE',9999,'Dollar')";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "INSERT INTO Money(id,currency,value) "
                              +"VALUES(@p1,'Euro',300)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "INSERT INTO Money(id,currency,value) "
                              +"VALUES(@p1,'Dollar',3500)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "INSERT INTO Money(id,currency,value) "
                              +"VALUES(@p1,'Yen',200)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.ExecuteNonQuery();
        }
        
        
    }
}