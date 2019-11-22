using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class first_connection
    {
        public first_connection() { }

        

        public string createConnection(string ip, string password, string user)
        {
             

            try
            {
                
                string databaseName = "";
                string connstring = string.Format("Server=" + ip + "; database={0}; UID=" + user + "; password=" + password + "", databaseName);

                MySqlConnection CL = new MySqlConnection(connstring);
                CL.Open();
               
                ServerOptions newWindow = new ServerOptions();
                newWindow.Show();

                return "you are have a connection";
 
            }catch(MySqlException err)
            {
                return "you don't have connection!.";
            }
        }
    }
}
