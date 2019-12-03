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
        
        public ServerOptions()
        {
            InitializeComponent();
        }

        private void ServerOptions_Load(object sender, EventArgs e)
        {
            InsertValueDB insert = new InsertValueDB();
            checkTable getInformationFromDB = new checkTable();
            getInformationFromDB.getAllTable(listBox1, insert);
            //server.createServer.Listener listen = new server.createServer.Listener();
            //listen.go();
            server.createServer.thr test = new server.createServer.thr();
            test.setThread();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
 
        }
    }   

}
