using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace WindowsFormsApp1.server.createServer
{
    public class thr
    {
        public thr() { }

        public void setThread()
        {
            Listener works = new Listener();
            
            Thread createSecondThread = new Thread(works.go);
            createSecondThread.Start();
        }
    }
    
    public class Listener 
    {
       public Listener() { }


        public void go()
        {

            

           try
            {
                IPAddress ipA = IPAddress.Parse("127.0.0.1");

                TcpListener myListener = new TcpListener(ipA, 8001);
                myListener.Start();
                Console.WriteLine("server runing in port 8001");
                Console.WriteLine("endpoint" + myListener.LocalEndpoint);

                Socket s = myListener.AcceptSocket();

                     byte[] b = new byte[100];
                     int k = s.Receive(b);
                     for(int i=0; i<k; i++)
                         Console.Write(Convert.ToChar(b[i]));

                     ASCIIEncoding asen = new ASCIIEncoding();
                     s.Send(asen.GetBytes("The string was recived by the server."));
                     Console.WriteLine("Sent Acknowledgment");

                    s.Close();
                    myListener.Stop();
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            }
            
    }
}
