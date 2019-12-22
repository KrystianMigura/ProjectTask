using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;


namespace WindowsFormsApp1.server.createServer
{
    public class obj : ServerOptions {
        public obj() { }
        public ListBox a { get; set; }

        public void addToListBox(ListBox list, string text)
        {
            try
            {
                list.Items.Add(text);
            } catch (Exception problemInAddValue)
            {
                Console.WriteLine(problemInAddValue);
            }
        }
    }

    public class thr : obj
    {
        public thr() { }

        public void setThread(ListBox listBox)
        {
            Listener works = new Listener();
            Thread createSecondThread = new Thread(works.go);
            createSecondThread.Start(listBox);
        }

    }

    public class HandleClient{
        
        public HandleClient() { }
        TcpClient clientsocket;

        public void StartClient(TcpClient inClientSocket, Object listbox)
        {
            this.clientsocket = inClientSocket;
            Thread ctThread = new Thread(DoChat);
            ctThread.Start(listbox);
        }

        public void DoChat(Object listbox)
        {
            obj list = new obj();
            InsertValueDB log = new InsertValueDB();
            Byte[] bytes = new byte[256];
            String data = null;

            NetworkStream stream = clientsocket.GetStream();

            int i;

            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to a ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("Received: {0}", data);

                //data value from clien`t
                server.allOptions.CmpMessageFromClient cmp = new server.allOptions.CmpMessageFromClient();
                cmp.splitMessage(data);

                //t.test add information do listbox and next should add info to DB;
                list.addToListBox((ListBox)listbox, data);

                char[] separator = { '~', '/' };
                String[] strList = data.Split(separator);
                if (strList.Length > 1) {
                    Console.WriteLine(strList[0] + "<ID> " + strList[1]);

                    int param = Int32.Parse(strList[0]); // value from incoming information from client
                    Model.ServiceCodeNumber codeService = new Model.ServiceCodeNumber();
                    switch (param)
                    {
                        case 100: codeService.code100(strList[1]);
                            break;
                        case 101: codeService.code101();
                            break;
                        case 102: codeService.code102();
                            break;
                        case 103: codeService.code103();
                            break;
                        case 104: codeService.code104();
                            break;
                        case 105: codeService.code105();
                            break;
                        case 106: codeService.code106();
                            break;
                        case 500: codeService.code500();
                            break;
                    }
                }


                DateTime localDate = DateTime.Now;
                log.insertToTable("info", data);



                // Process the data sent by the client.


                data = "to jest odpowiedz z servera do klienta wazne!!";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("Sent: {0}", data);

                if (data == "500")
                {
                    clientsocket.Close();
                }

            }
        }

    }

    public class Listener : ServerOptions
    {
        public Listener() { }
        public delegate void delegateset(string a);
       

        public void go(Object listbox)
        {
            string text = "";
            obj t = new obj();
            InsertValueDB log = new InsertValueDB();

            IPAddress ipA = IPAddress.Parse("127.0.0.1");
            TcpListener myList = new TcpListener(ipA, 10000);

            TcpClient Client = default(TcpClient);
            int count = 0;
            myList.Start();

            while (true)
            {
                count += 1;
                Client = myList.AcceptTcpClient();
                HandleClient handle = new HandleClient();
                handle.StartClient(Client, listbox);
            }
        }
    }
}
            
    

