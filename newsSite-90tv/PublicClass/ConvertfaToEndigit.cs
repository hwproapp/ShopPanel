using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.PublicClass
{
    public class ConvertfaToEndigit
    {
        public static string toEnNumber(string input)
        {
            string[] persian = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

            for (int j = 0; j < persian.Length; j++)
                input = input.Replace(persian[j], j.ToString());

            return input;
        }


        

        public static string farsinumber(string text)
        {

            string[] farsinumber = new string[] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            if (text.Length == 0)
            {
                return "";
            }
            string outres= "";
            int length = text.Length;
            for (int i = 0; i < length; i++)
            {
                char c = text[i];
                if ('0' <= c && c <= '9')
                {
                    int number = Convert.ToInt32(c);
                    outres = outres + farsinumber[number];
                }
               
            }
            return  outres;
        }
    }
}
