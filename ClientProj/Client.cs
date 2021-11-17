using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Collections.Concurrent;
using System.Threading;


namespace ClientProj
{
    class Client
    {
        //private
        private TcpClient m_tcpClient;

        private Stream m_stream;

        private StreamWriter m_writer;

        private StreamReader m_reader;

        
        

        private void ProcessServerResponse()
        {
            Console.WriteLine("Server Says: " + m_reader.ReadLine());
            Console.WriteLine();
        }

        //public

        public Client()
        {
            m_tcpClient = new TcpClient();
        }

        public bool Connect(string ipAdress, int port)
        {
            try
            {
                m_tcpClient.Connect(ipAdress, port);
                m_stream = m_tcpClient.GetStream();
                m_reader = new StreamReader(m_stream, Encoding.UTF8);
                m_writer = new StreamWriter(m_stream, Encoding.UTF8);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;

            }

        }

        public void Run()
        {
            string userInput;

            ProcessServerResponse();

            while ((userInput = Console.ReadLine()) != null)
            {
                m_writer.WriteLine(userInput);
                m_writer.Flush();
                ProcessServerResponse();

                if (userInput == "hi")
                {
                    break;
                }

            }
            m_tcpClient.Close();

        }


    }
}

