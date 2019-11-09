using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class checkTable : ServerOptions
    {
        public checkTable() { }

        public void getAllTable( object x)
        {
            string databaseName = "Users";
            string connstring = string.Format("Server=127.0.0.1; database={0}; UID=root; password=TajneHaslo!", databaseName);

            string quetyTable = string.Format(@"CREATE TABLE `{0}` (
                                `sid` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
                                `nick` varchar(120) NOT NULL DEFAULT '',
                                `firstName` varchar(120) NOT NULL DEFAULT '',
                                `lastName` text NOT NULL,
                                `password` text NOT NULL,
                                `email` text NOT NULL,
                                PRIMARY KEY (`sid`))
                                ENGINE = MyISAM AUTO_INCREMENT = 1 ;", "Users");


            MySqlConnection CL = new MySqlConnection(connstring);
            CL.Open();

            MySqlCommand createTable = new MySqlCommand(quetyTable, CL);
            try
            {
                createTable.ExecuteNonQuery();
            }catch(MySql.Data.MySqlClient.MySqlException error)
            {

               
                Console.WriteLine("Table User Exist");
                  // added information to listbox  
            }
        }
    }
}

