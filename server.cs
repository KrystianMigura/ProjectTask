using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class server
    {

        public server() { }

        public string serv;

        public string Serv
        {
            get { return serv;  }
            set { serv = Serv; }
        }

        public void test()
        {
            try
            {
                string databaseName = "Users";
                string connstring = string.Format("Server=localhost; database={0}; UID=root; password=TajneHaslo2019!", databaseName);


                MySqlConnection CL = new MySqlConnection(connstring);
                CL.Open();
                CL.Close();
                Serv = connstring;
                Console.WriteLine("connectioin is: " + CL.State.ToString() + " " + Environment.NewLine);

            }   
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                Console.WriteLine(err);
            }
                MySqlConnection client = new MySqlConnection();
            Console.WriteLine("test");
        }

    }
}
