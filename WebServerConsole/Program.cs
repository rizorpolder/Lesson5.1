using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new WebServer(8080);
            server.Start();
            Console.ReadLine();



            server.Stop();
            Console.ReadLine();
           
        }
    }
}
