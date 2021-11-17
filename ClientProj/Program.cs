using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            if (client.Connect("127.0.0.1", 4444))
            {
                client.Run();
            }
            else
            {
                Console.WriteLine("failed to connect to the server");
            }
        }
    }
}
