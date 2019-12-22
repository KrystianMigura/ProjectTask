using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    class ConverterBase64
    {
        public ConverterBase64() { }

        public string encodeBase64string(String value)
        {
            var bytesString = System.Text.Encoding.UTF8.GetBytes(value);
            string str = System.Convert.ToBase64String(bytesString);
            return str;
        }

        public string decodeBase64string(String value)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(value);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

        }
    }
}
