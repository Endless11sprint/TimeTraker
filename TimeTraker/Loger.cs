using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimeTraker
{
    static class Loger
    {
        public static void AddLine(string log)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\karkr\\Desktop\\TimeTraker-master\\TimeTraker\\Logs.txt");

                sw.WriteLine($"{log}");
                sw.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
}
