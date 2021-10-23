using System;
using System.Collections.Generic;
using System.Data;
using ProjetISF.Person;
using System.Data.SQLite;
using System.Windows.Documents;

namespace ProjetISF.Database
{
    public class ClientDBAccess : IClientDataAccess
    {

        private string cs = @"URI=file:C:\Users\jonat\tp3cs\ProjetISF\ProjetISF\Database\ProjetISF";
        public List<Client> GetAll()
        {
            List<Client> lc= new List<Client>();
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = "SELECT * FROM Client";
            using var cmd = new SQLiteCommand(stm,con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            Client c;
            Money m;
            
            while (rdr.Read())
            {
                c = new Client();
                c.guid = rdr.GetString(0);
                c.firstname = rdr.GetString(1);
                c.name = rdr.GetString(2);
                c.pin = rdr.GetInt32(3);
                c.currency = rdr.GetString(4);
                cmd.CommandText = "SELECT currency,value FROM Money WHERE id = @p";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SQLiteParameter("@p",c.guid));
                using SQLiteDataReader rdr2 = cmd.ExecuteReader();
                while (rdr2.Read())
                {
                    m = new Money();
                    m.currency = rdr2.GetString(0);
                    m.value = rdr2.GetInt32(1);
                    c.money.Add(m);
                }
                lc.Add(c);
            }
            

            return lc;
        }

        public void CreateUser(string firstname,string name, int pin, string currency, List<Money> money)
        {
            using var con = new SQLiteConnection(cs);
            con.Open();
            using var cmd = new SQLiteCommand(con);
            
            Guid g = Guid.NewGuid();
            string gs = g.ToString();
            cmd.CommandText = "INSERT INTO Client(id,firstname,name,pin,currency) "
                              +"VALUES(@p1,@p2,@p3,@p4,@p5)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
            cmd.Parameters.Add(new SQLiteParameter("@p2",firstname));
            cmd.Parameters.Add(new SQLiteParameter("@p3",name));
            cmd.Parameters.Add(new SQLiteParameter("@p4",pin));
            cmd.Parameters.Add(new SQLiteParameter("@p5",currency));
            cmd.ExecuteNonQuery();
            foreach (var m in money)
            {
                cmd.CommandText = "INSERT INTO Money(id,currency,value) "
                                  +"VALUES(@p1,@p2,@p3)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SQLiteParameter("@p1",gs));
                cmd.Parameters.Add(new SQLiteParameter("@p2",m.currency));
                cmd.Parameters.Add(new SQLiteParameter("@p3",m.value));
                cmd.ExecuteNonQuery();
            }
        }

        public Client GetClient(string guid)
        {
            Client c = new Client();
            
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = "SELECT * FROM Client WHERE id = @p1";
            using var cmd = new SQLiteCommand(stm,con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",guid));
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            Money m;
            
            if (rdr.Read())
            {
                c.guid = rdr.GetString(0);
                c.firstname = rdr.GetString(1);
                c.name = rdr.GetString(2);
                c.pin = rdr.GetInt32(3);
                c.currency = rdr.GetString(4);
                cmd.CommandText = "SELECT currency,value FROM Money WHERE id = @p";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SQLiteParameter("@p",c.guid));
                using SQLiteDataReader rdr2 = cmd.ExecuteReader();
                while (rdr2.Read())
                {
                    m = new Money();
                    m.currency = rdr2.GetString(0);
                    m.value = rdr2.GetInt32(1);
                    c.money.Add(m);
                }
                
            }
            
            return c;
        }

        public void UpdateClient(Client c)
        {
            using var con = new SQLiteConnection(cs);
            con.Open();
            using var cmd = new SQLiteCommand(con);
            cmd.CommandText = "UPDATE TABLE Client SET  firstname = @p1, name = @p2, currency = @p3, pin = @p4 WHERE id = @p5";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",c.firstname));
            cmd.Parameters.Add(new SQLiteParameter("@p2",c.name));
            cmd.Parameters.Add(new SQLiteParameter("@p3",c.currency));
            cmd.Parameters.Add(new SQLiteParameter("@p4",c.pin));
            cmd.Parameters.Add(new SQLiteParameter("@p5",c.guid));
            cmd.ExecuteNonQuery();
            foreach (var m in c.money)
            {
                cmd.CommandText = "UPDATE TABLE Money SET value = @p1 WHERE id = @p2 AND currency = @p3";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SQLiteParameter("@p1",m.value));
                cmd.Parameters.Add(new SQLiteParameter("@p2",c.guid));
                cmd.Parameters.Add(new SQLiteParameter("@p3",m.currency));
                cmd.ExecuteNonQuery();
            }
            
        }

        public void DeleteClient(string guid)
        {
            using var con = new SQLiteConnection(cs);
            con.Open();
            using var cmd = new SQLiteCommand(con);
            cmd.CommandText = "DELETE FROM Money WHERE id = @p1";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",guid));
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE FROM Client WHERE id = @p1";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SQLiteParameter("@p1",guid));
            cmd.ExecuteNonQuery();
        }

        public void CreateDatabase()
        {
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