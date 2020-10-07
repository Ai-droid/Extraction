using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace Extraction
{
    class DataExtraction
    {
        public string[] CreateArray(string path)
        {
            StreamReader File = new StreamReader(path);
            string myString = File.ReadToEnd();

            string[] array = myString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            return array;
        }

        public string ReturnLast(string str)
        {
            char[] spearator = { ' ' };
            string rstr;
            string[] strlist = str.Split(spearator);
            int len = strlist.Length;

            if (str.StartsWith("Total"))
            {
                rstr = strlist[len -2] + " " + strlist[len -1];
            }
            else
            {
                rstr = strlist[len - 1];
            }

            return rstr;
        }
        //public string arraydata(string str1, string str2)
        //{
        //    string rstr;
        //    return rstr;
        //}
        public static void Main()
        {
            string path = @"F:\dotnet\Extraction\Extraction\16289_REMITTANCE.txt";

            DataExtraction D = new DataExtraction();

            string[] strlist = D.CreateArray(path);

            string idocno = D.ReturnLast(strlist[0]);
            string vidno = D.ReturnLast(strlist[1]);
            string name = strlist[2];
            string addrs = strlist[3] + " " + strlist[4];
            string amt = D.ReturnLast(strlist[5]);
            

            Console.WriteLine(idocno);
            Console.WriteLine(vidno);
            Console.WriteLine(name);
            Console.WriteLine(addrs);
            Console.WriteLine(amt);

        }

    }
}
