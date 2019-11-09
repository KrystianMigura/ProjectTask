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
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            fileOptions fileOpen = new fileOptions();
            bool checkFile = fileOpen.tryOpenFile();

            if (checkFile == true)
            {

            }

            first_connection create_connect = new first_connection();
            string ip = textBox1.Text;
            string password = textBox2.Text;
            string user = textBox3.Text;
            if (checkFile == false)
            {
                fileCreate newFile = new fileCreate();
                newFile.createNewFile(ip, password, user);
            }
            label4.Text = create_connect.createConnection(ip, password, user);
            
         
        }


    }

}




