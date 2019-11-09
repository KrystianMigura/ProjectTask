using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class fileOptions
    {
        public fileOptions() { }

        public bool tryOpenFile()
        {
               
            string sourceDirectory = @"C:\Users\"+Environment.UserName+@"\Documents\DBconfiguration.txt";
            bool checkFile = File.Exists(sourceDirectory);

            return (checkFile == true) ? true : false;

        }
    }

    class fileCreate
    {
        public fileCreate() { }

        public void createNewFile(string ip, string password, string user)
        {
            StreamWriter sw = File.CreateText(@"C:\Users\" + Environment.UserName + @"\Documents\DBconfiguration.txt");
            sw.Close();

            string base64EncodedData = " ip" + ip + "," + " user " + user + "," + " password " + password ;


  


            try
            {


                File.AppendAllText(@"C:\Users\" + Environment.UserName + @"\Documents\DBconfiguration.txt", tt);

            }catch(IOException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
