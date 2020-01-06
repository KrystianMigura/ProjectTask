using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Model
{
    class ServiceCodeNumber
    {
        public ServiceCodeNumber() { }

        public String[] spliter(string data)
        {
            char[] separator = { '~', '/' };

            String[] strList = data.Split(separator);
            return strList;
        }

        public Boolean code100(String data)
        {
            Console.WriteLine("TO JKEST TEST + " + data);
            //register
            //data is base64 need convert
            Model.ConverterBase64 convert = new Model.ConverterBase64();
            data = convert.decodeBase64string(data);
            String[] list = spliter(data);

            string nick = list[0];
            string firstName = list[1];
            string lastName = list[2];
            string password = list[3];
            string email = list[4];
                       
            InsertValueDB add = new InsertValueDB();
            Boolean status;
            //check exist email in DB;
            status = add.findEmail(email);
            
            if(status == true)
            {
                add.registerUser(nick, firstName, lastName, password, email);
                return true;
            }
            else
            {
                return false;
            }
            
            
        }
        public Boolean code101(String data)
        {
            Boolean flag = false;
            //login
            Model.ConverterBase64 convert = new Model.ConverterBase64();
            data = convert.decodeBase64string(data);
            String[] list = spliter(data);

            InsertValueDB askDB = new InsertValueDB();

            flag = askDB.loginToApp(list[0], list[1]);
            Console.WriteLine(flag + " info dot logowania");

            if(flag == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void code102()
        {
            //add task
        }
        public void code103()
        {
            //update task
        }
        public String code104()
        {
            InsertValueDB selectQuery = new InsertValueDB();

            String paramToSend = selectQuery.selectAllTask();
            return paramToSend;
            //get all task
        }
        public void code105()
        {
            //update user
        }
        public void code106()
        {
            //get my task
        }
        public void code500()
        {
            //close connection
        }
    }
}
