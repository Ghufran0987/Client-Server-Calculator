using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2016);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(iep);
            server.Listen(10);
            Console.WriteLine("waiting...");
            Socket client = server.Accept();
            Console.WriteLine("Accept {0}", client.RemoteEndPoint.ToString());

            string s = "Welcome";
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(s);
            client.Send(data, data.Length, SocketFlags.None);




            byte[] gdata = new byte[1024];
            byte[] total = new byte[1024];
            byte[] total2 = new byte[1024];
            byte[] total3 = new byte[1024];

            string array;
            string array2;
            string array3;
            
            while (true)
            {
                int recv = client.Receive(gdata);
                array = Encoding.ASCII.GetString(gdata,0,recv);

                Console.WriteLine("Client: {0}", array);

                //SUM
                int sum = 0;
                int mul = 1;
                int sub = 0;
                string[] arrListStr = array.Split(',');
                for (int i = 0; i < arrListStr.Length; i++)
                {
                    sum += Int32.Parse(arrListStr[i]);

                    mul=mul*Int32.Parse(arrListStr[i]);

                    sub -= Int32.Parse(arrListStr[i]);

                    



                }
                
                Console.WriteLine(sum);
                Console.WriteLine( mul);
                Console.WriteLine(sub);
                array = sum.ToString();
                array2 = mul.ToString();
                array3 = sub.ToString();

                
                


                total = Encoding.ASCII.GetBytes(array);
                total2 = Encoding.ASCII.GetBytes(array2);
                total3 = Encoding.ASCII.GetBytes(array3);
                client.Send(total, total.Length, SocketFlags.None);
                client.Send(total2, total2.Length, SocketFlags.None);
                client.Send(total3, total3.Length, SocketFlags.None);
               

            }

        }
    }

    }

