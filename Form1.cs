using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using MySql.Data;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            test();
        }
        public void test()
        {
            try
            {
                readFile getConfiguration = new readFile();
                string options = getConfiguration.getInformationFromFile();
                string data = options.ToString();
                String pattern = @"\,";
                String[] Information = System.Text.RegularExpressions.Regex.Split(data, pattern);
                textBox1.Text = Information[0];
                textBox2.Text = Information[2];
                textBox3.Text = Information[1];
            }
            catch (System.IndexOutOfRangeException err)
            {
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                label4.Text = "You don't have file for read value! \n " ;
            }
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {

            fileOptions fileOpen = new fileOptions();
            bool checkFile = fileOpen.tryOpenFile();

            if (checkFile == true)
            {
                readFile getConfiguration = new readFile();
                string options = getConfiguration.getInformationFromFile();
                string data = options.ToString();
                String pattern = @"\,";
                String[] elements = System.Text.RegularExpressions.Regex.Split(data, pattern);
                textBox1.Text = elements[0];
                textBox2.Text = elements[2];
                textBox3.Text = elements[1];
            }

            first_connection create_connect = new first_connection();
            string ip = textBox1.Text;
            string password = textBox2.Text;
            string user = textBox3.Text;

            if (checkFile == false)
            {
                fileCreate newFile = new fileCreate();
                newFile.createNewFile(ip, password, user);
                Console.WriteLine("File created!");
            }
            string informationFromConnector = create_connect.createConnection(ip, password, user);
            label4.Text = informationFromConnector;

            if(informationFromConnector == "you are have a connection")
            {
                Hide();
            }

      
        }

    }

}




