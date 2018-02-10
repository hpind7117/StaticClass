using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StaticClass
{
    public static class Logger
    {
        public static readonly object lockobject=new object();
        public static string filepath { get; set; }
        public static DateTime dt = DateTime.Now;

        public static  void log(string msg)
        {
            lock (lockobject)
            {
                if (!string.IsNullOrEmpty(filepath))
                {
                    using (StreamWriter sw = new StreamWriter(filepath, true))
                    {
                        sw.WriteLine(msg);
                        sw.Close();
                    }
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Logger.filepath = "D:\\a.txt";
            Logger.log ( "Om Sai Ram" + Logger.dt);
            Console.Read();
        }
    }
}
