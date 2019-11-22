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

        public void insertToTable()
        {
            
            string databaseName = "Users";
            string connstring = string.Format("Server=127.0.0.1; database={0}; UID=root; password=TajneHaslo!", databaseName);
            MySqlConnection CL = new MySqlConnection(connstring);
            CL.Open();
        }


    }
}
