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
        string fileName = "configurationDB.dat";

        public fileOptions() { }

        public bool tryOpenFile()
        {
            
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        using (BinaryReader r = new BinaryReader(fs))
                        {
                            Console.WriteLine("File Open");
                            return true;
                        }
                    }
                    catch (FileNotFoundException err)
                    {
                        Console.WriteLine("Can Not readed file");
                        return false;
                    }
                }
            }
            catch (FileNotFoundException err)
            {
                Console.WriteLine("File Not Exist");
                return false;
            }
        }
    }

    class fileCreate
    {
        public fileCreate() { }

        public void createNewFile(string ip, string password, string user)
        {         
            try
            {

                string configurationDB = ip + ", " + user + ", " + password ;
                string fileName = "configurationDB.dat";
                
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                       using(BinaryWriter w  = new BinaryWriter(fs))
                        {
                            w.Write(configurationDB);
                        }
                };
            }
            catch(IOException e)
            {
                Console.WriteLine(e);
            }
        }
    }

    class readFile 
    {
        string fileName = "configurationDB.dat";
        public readFile() { }

        public string getInformationFromFile()
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader r = new BinaryReader(fs))
                    {

                        string data = r.ReadString();

                        return data;
                    }
                }
            }
            catch (FileNotFoundException err)
            {
                return "ERR";
            }
        }
    }
}
