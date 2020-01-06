using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApp1
{
    class opt
    {
        opt() { }

        private ListBox list { get; set; }

        public void ad(string test)
        {
            this.list.Items.Add(test);
        }
    }

    class checkTable : ServerOptions
    {
        //public ListBox listbox111;

  

        public checkTable() { }

        public void getAllTable(ListBox listbox, InsertValueDB insert)
        {
            readFile getData = new readFile();
            string data = getData.getInformationFromFile();

            char[] spearator = { ',' };
            String[] strlist = data.Split(spearator);

            string ServerIp = strlist[0];
            string uid = strlist[1];
            string password = strlist[2];



            string databaseName = "Users";
            string connstring = string.Format("Server="+ServerIp+"; database={0}; UID="+uid+"; password="+password+"", databaseName);

            string quetyTable = string.Format(@"CREATE TABLE `{0}` (
                                `sid` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
                                `nick` varchar(120) NOT NULL DEFAULT '',
                                `firstName` varchar(120) NOT NULL DEFAULT '',
                                `lastName` text NOT NULL,
                                `password` text NOT NULL,
                                `email` text NOT NULL,
                                `access` text NOT NULL,
                                PRIMARY KEY (`sid`))
                                ENGINE = MyISAM AUTO_INCREMENT = 1 ;", "Users");

            string queryTableLogs = string.Format(@"CREATE TABLE `{0}` (
                                `id` smallint(10) unsigned NOT NULL AUTO_INCREMENT,
                                `typeLog` text NOT NULL,
                                `message` text NOT NULL,
                                PRIMARY KEY (`id`)) ENGINE = MyISAM AUTO_INCREMENT = 1 ", "Logs");

            string queryTableTask = string.Format(@"CREATE TABLE `{0}` (
                                `id` smallint(10) unsigned NOT NULL AUTO_INCREMENT,
                                `resolver` text NOT NULL,
                                `titleTask` text NOT NULL,
                                `created` text NOT NULL,
                                `information` text NOT NULL,
                                `dateCreated` date NOT NULL,
                                `dateResolved` date NOT NULL,
                                PRIMARy KEY (`id`)) ENGINE = MyISAM AUTO_INCREMENT = 1", "TaskList");

            MySqlConnection CL = new MySqlConnection(connstring);
            CL.Open();
            DateTime localDate = DateTime.Now;
            MySqlCommand createTableTaskList = new MySqlCommand(queryTableTask, CL);
            InsertValueDB DbInsert = new InsertValueDB();
            try
            {
                createTableTaskList.ExecuteNonQuery();
               
                listbox.Items.Add( localDate + " Create Table : Table TaskList is Created Correct");
                DbInsert.insertToTable("info", localDate + "Create Table : Table TaskList is Created Correct");
            }
            catch (MySqlException e)
            {
                listbox.Items.Add( localDate + " Create Table : Table Logs Exist");
                DbInsert.insertToTable("info", localDate + "Create Table : Table Logs Exist");
            }

            MySqlCommand createTableForLog = new MySqlCommand(queryTableLogs, CL);
            try
            {
                createTableForLog.ExecuteNonQuery();
                listbox.Items.Add(localDate + " Create Table : Table Logs is Created Correct");
                DbInsert.insertToTable("info", localDate + "Create Table : Table Logs is Created Correct");
            }
            catch (MySqlException e)
            {
                listbox.Items.Add(localDate + " Create Table : Table Logs Exist");
                DbInsert.insertToTable("info", localDate + "Create Table : Table Logs Exist");
            }

           
            MySqlCommand createTable = new MySqlCommand(quetyTable, CL);
            try
            {
                createTable.ExecuteNonQuery();
                listbox.Items.Add(localDate + " Create Table : Table user is Created Correct");               
                DbInsert.insertToTable("info", localDate+"Create Table : Table user is Created Correct");

            }
            catch(MySql.Data.MySqlClient.MySqlException error)
            {
                Console.WriteLine(error);
                listbox.Items.Add(localDate + " Create Table : Table user exist");
                DbInsert.insertToTable("info", localDate +"Create Table : Table user exist");


            }

        }
    }
}

