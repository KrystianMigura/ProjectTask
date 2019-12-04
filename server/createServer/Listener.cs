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
            IPAddress ipA = IPAddress.Parse("127.0.0.1");
            TcpListener myList = new TcpListener(ipA, 10000);
            myList.Start();
            Byte[] bytes = new byte[256];
            String data = null;
            Console.WriteLine("server start o port 10000");
            TcpClient client = myList.AcceptTcpClient();
            Console.WriteLine("Connected!");

            NetworkStream stream = client.GetStream();

            int i;

            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to a ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("Received: {0}", data);

                // Process the data sent by the client.
                data = "to jest odpowiedz z servera do klienta wazne!!";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("Sent: {0}", data);
            }

            // Shutdown and end connection
            client.Close();


        }



        /*
       try
        {
            IPAddress ipA = IPAddress.Parse("127.0.0.1");

            TcpListener myListener = new TcpListener(ipA, 8001);
            myListener.Start();

            Console.WriteLine("The server is running at port 8001...");
            Console.WriteLine("The local End point is  :" +
                               myListener.LocalEndpoint);
            Console.WriteLine("Waiting for a connection.....");

            Socket s = myListener.AcceptSocket();
            Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

            byte[] b = new byte[100];
            int k = s.Receive(b);
            Console.WriteLine("Recieved...");
            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(b[i]));

            ASCIIEncoding asen = new ASCIIEncoding();
            s.Send(asen.GetBytes("The string was recieved by the server."));
            Console.WriteLine("\nSent Acknowledgement");
            /* clean up */
        //s.Close();
        //myListener.Stop();
        /*
            }
            catch (Exception e)
            {
            go();
            Console.WriteLine("Error..... " + e.StackTrace);
            }
        */
    }
    }
            
    

