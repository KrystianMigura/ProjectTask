using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class InsertValueDB
    {
        
        public InsertValueDB() { }

        private string Message ;


        public string Pobierz()
        {
            return Message;
        }

        public void Ustaw(string _message)
        {
            Message = _message;
        }

        public void insertToTable(string typeLog, string message)
        {
            readFile getData = new readFile();
            string data = getData.getInformationFromFile();

            char[] spearator = { ',' };
            String[] strlist = data.Split(spearator);

            string ServerIp = strlist[0];
            string uid = strlist[1];
            string password = strlist[2];

            string databaseName = "Users";
            string connstring = string.Format("Server="+ServerIp+"; database={0}; UID="+uid+ "; password="+password, databaseName);
            MySqlConnection CL = new MySqlConnection(connstring);
            CL.Open();
 
            string insert = "INSERT INTO logs(typeLog,message) VALUES('"+typeLog+"','"+message+"')";

            MySqlCommand cmd = new MySqlCommand(insert,CL);
            cmd.ExecuteNonQuery();
            CL.Close();
      
        }

        public void registerUser(string nick, string firstName, string lastName, string password, string email)
        {
            readFile getData = new readFile();
            string data = getData.getInformationFromFile();

            char[] spearator = { ',' };
            String[] strlist = data.Split(spearator);

            string ServerIp = strlist[0];
            string uid = strlist[1];
            string passwd = strlist[2];
            string databaseName = "Users";

            string connstring = string.Format("Server=" + ServerIp + "; database={0}; UID=" + uid + "; password=" + passwd, databaseName);
            MySqlConnection CL = new MySqlConnection(connstring);
            CL.Open();

            string insert = "INSERT INTO users( nick, firstName, lastName, password, email) VALUES('"+nick+"','"+firstName+"','"+lastName+"','"+password+"','"+email+"')";

            MySqlCommand cmd = new MySqlCommand(insert, CL);
            cmd.ExecuteNonQuery();
            CL.Close();
        }


    }
}
