using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{


    public partial class ServerOptions : Form
    {
        public static ListBox hmmm { get; set; }



        public ServerOptions()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            hmmm = listBox1;

        }
        

        private void ServerOptions_Load(object sender, EventArgs e)
        {

            InsertValueDB insert = new InsertValueDB();
            checkTable getInformationFromDB = new checkTable();
            getInformationFromDB.getAllTable(listBox1);
           
   
            //server.createServer.Listener listen = new server.createServer.Listener();
            //listen.go();
            server.createServer.thr test = new server.createServer.thr();
            test.setThread(listBox1);
            
        }
    }   

}
