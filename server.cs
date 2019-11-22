using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class server1
    {

        public server1() { }

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
                readFile value = new readFile();

                string data = value.getInformationFromFile();
                readFile getData = new readFile();
                string Data = getData.getInformationFromFile();

                char[] spearator = { ',' };
                String[] strlist = Data.Split(spearator);

                string ServerIp = strlist[0];
                string uid = strlist[1];
                string password = strlist[2];



                string databaseName = "Users";
                string connstring = string.Format("Server="+ServerIp+"; database={0}; UID="+uid+"; password="+password+"", databaseName);


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
