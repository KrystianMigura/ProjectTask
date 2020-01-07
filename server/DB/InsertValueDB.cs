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

        public string selectAllTask()
        {
            readFile getData = new readFile();
            string data = getData.getInformationFromFile();

            char[] spearator = { ',' };
            String[] strlist = data.Split(spearator);

            string ServerIp = strlist[0];
            string uid = strlist[1];
            string password = strlist[2];
            string databaseName = "Users";

            string connstring = string.Format("Server=" + ServerIp + "; database={0}; UID=" + uid + ";convert zero datetime=true; ; password=" + password, databaseName);
            MySqlConnection CL = new MySqlConnection(connstring);
            CL.Open();


            string queryAll = "SELECT * FROM tasklist";
            MySqlCommand cmd = new MySqlCommand(queryAll, CL);

            var version = cmd.ExecuteScalar().ToString();
            MySqlDataReader myDataReader;
            myDataReader = cmd.ExecuteReader();

            string x= "";

            int i = 0;
            while (myDataReader.Read())
            {
                string a = "\"" +myDataReader.GetString(0)+"\"";
                string b = "\"" + myDataReader.GetString(1) + "\"";
                string c = "\"" + myDataReader.GetString(2) + "\"";
                string d = "\"" + myDataReader.GetString(3) + "\"";
                var e = "\"" + myDataReader.GetValue(4) + "\"";
                var f = "\"" + myDataReader.GetValue(5) + "\"";
                var g = "\"" + myDataReader.GetValue(6) + "\"";
                string h = "\"" + myDataReader.GetValue(7) + "\"";

                x += " { id  : " + ""+ a +""+ ",  resolver  :" +""+ b +""+ ", titleTask : " +""+ c +""+ " , created : " +""+ d +""+ ", information : " +""+ e +""+ ", dateCreated: " +""+ f +""+ ", dateResolved : " +""+ g + ""+ ", status : " + "" + h + " },";
   
                
                i++;
            
                
            }
            return x;

        }

        public Boolean loginToApp (string email, string passwd)
        {
            readFile getData = new readFile();
            string data = getData.getInformationFromFile();

            char[] spearator = { ',' };
            String[] strlist = data.Split(spearator);

            string ServerIp = strlist[0];
            string uid = strlist[1];
            string password = strlist[2];
            string databaseName = "Users";

            string connstring = string.Format("Server=" + ServerIp + "; database={0}; UID=" + uid + "; password=" + password, databaseName);
            MySqlConnection CL = new MySqlConnection(connstring);
            CL.Open();
            Console.WriteLine(email+ " " + passwd);
            string insert = "SELECT nick,firstName,lastName,email,access FROM users WHERE email = '" + email + "' AND password = '"+passwd+"'";
            Boolean flag = true;

            MySqlCommand cmd = new MySqlCommand(insert, CL);
            try
            {
                var version = cmd.ExecuteScalar().ToString();
                MySqlDataReader myDataReader;
                myDataReader = cmd.ExecuteReader();
                while (myDataReader.Read())
                {
                    string nick = myDataReader.GetString(0);
                    string firstName = myDataReader.GetString(1);
                    string lastName = myDataReader.GetString(2);
                    string ema = myDataReader.GetString(3);
                    string access = myDataReader.GetString(4);
                    Console.WriteLine(myDataReader.GetString(0) + " " + myDataReader.GetString(1) + " " + myDataReader.GetString(2) + " " + myDataReader.GetString(3) + " " + myDataReader.GetString(4));
                }

                
                flag = true;
            }
            catch (Exception err)
            {
                flag = false;
                Console.WriteLine("error + " + err);
            }

            CL.Close();
            return flag;
        }

        public Boolean findEmail(string email)
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

            string insert = "SELECT email FROM users WHERE email = '"+email+"'";
            Boolean flag = true;

            MySqlCommand cmd = new MySqlCommand(insert, CL);
            try
            {
                var version = cmd.ExecuteScalar().ToString();
                Console.WriteLine(version);
                flag = false;
            }catch(Exception err)
            {
                flag = true;
            }
            CL.Close();
            return flag;
        }


    }
}
