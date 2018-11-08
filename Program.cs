using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Helloworld
{
    class Program
    {
        static void Main(string[] args)
        {

            if(args.Length<2){
                Console.WriteLine("Ussage IP/DNS PORTS to knock");
                return;
            }

            IPAddress serverAddr = Dns.GetHostAddresses(args[0])[0];

            Console.WriteLine("Address: " + serverAddr.ToString());

            for(int i = 1; i<args.Length;i++){
                Socket sock = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
                string port = args[i];
                Console.WriteLine("Knocking port: " + port);
                IPEndPoint endPoint = new IPEndPoint(serverAddr, Convert.ToInt16(port));
                string text = "knock";
                byte[] send_buffer = Encoding.ASCII.GetBytes(text );
                sock.SendTo(send_buffer,endPoint);
                sock.Close();
                Thread.Sleep(1000);
            }
        }
    }
}
