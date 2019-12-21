using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.server.allOptions
{
    class CmpMessageFromClient
    {
        public CmpMessageFromClient() { }
        
        private string dataInfo { get; set; }

        public void splitMessage(String message)
        {
            dataInfo = message;

            char[] separator = {'~','/'};

            String[] strList = dataInfo.Split(separator);
            Console.WriteLine(strList.Length);
            for(int x = 0; x<strList.Length; x++)
            {
                Console.WriteLine(strList[x]);
            }

            InsertValueDB add = new InsertValueDB();
            add.registerUser("adam","burel");
            Console.WriteLine(dataInfo);
        }

    }
}
