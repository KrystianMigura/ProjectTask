using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void code100(String data)
        {
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
            add.registerUser(nick, firstName, lastName, password, email);
        }
        public void code101()
        {
            //login
        }
        public void code102()
        {
            //add task
        }
        public void code103()
        {
            //update task
        }
        public void code104()
        {
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
