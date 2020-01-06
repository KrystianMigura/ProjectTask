﻿using System;
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
                  //  Console.WriteLine(strList[0] + "<ID> " + strList[1]);

                    int param = Int32.Parse(strList[0]); // value from incoming information from client
                    Model.ServiceCodeNumber codeService = new Model.ServiceCodeNumber();
                    switch (param)
                    {
                        case 20:
                            data = "to jest odpowiedz z servera do klienta wazne!! @@@@@@@@@@@@@@@";

                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                            // Send back a response.
                            stream.Write(msg, 0, msg.Length);
                            Console.WriteLine("Sent: {0}", data);
                            break;
                        case 100: 
                            
                            Boolean flag100 = codeService.code100(strList[1]);
                            if(flag100 == true)
                            {
                                var data100 = "120"; // corrected created user

                                byte[] msg100 = System.Text.Encoding.ASCII.GetBytes(data100);

                                // Send back a response.
                                stream.Write(msg100, 0, msg100.Length);
                                Console.WriteLine("Sent: {0}", data100);
                            }
                            else
                            {
                                var data100not = "404";

                                byte[] msg100 = System.Text.Encoding.ASCII.GetBytes(data100not);

                                // Send back a response.
                                stream.Write(msg100, 0, msg100.Length);
                                Console.WriteLine("Sent: {0}", data100not);
                            }

                            
                            break;
                        case 101: 
                            
                            Boolean flag101 = codeService.code101(strList[1]);
                                if(flag101 == true)
                            {
                                var data101 = "200~" + strList[1];

                                byte[] msg101 = System.Text.Encoding.ASCII.GetBytes(data101);

                                // Send back a response.
                                stream.Write(msg101, 0, msg101.Length);
                                Console.WriteLine("Sent: {0}", data101);
                            }
                            else
                            {
                               var data101not = "404";

                                byte[] msg101 = System.Text.Encoding.ASCII.GetBytes(data101not);

                                // Send back a response.
                                stream.Write(msg101, 0, msg101.Length);
                                Console.WriteLine("Sent: {0}", data101not);
                            }

                            break;
                        case 102: codeService.code102();
                            break;
                        case 103: codeService.code103();
                            break;
                        case 104: 
                            String paramForSend = codeService.code104();
                            Model.ConverterBase64 con = new Model.ConverterBase64();
                            
                            string coder = con.encodeBase64string(paramForSend);

                            // var data104not = "114";

                            byte[] msg104 = System.Text.Encoding.ASCII.GetBytes("114~"+ coder);

                            // Send back a response.
                            stream.Write(msg104, 0, msg104.Length);
                        //    Console.WriteLine("Sent: {0}", data104not);

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

                /*

                // Process the data sent by the client.
 //this send message for client

                data = "to jest odpowiedz z servera do klienta wazne!! @@@@@@@@@@@@@@@";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("Sent: {0}", data);
*/
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
            
    

