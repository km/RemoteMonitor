using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RemoteMonitor
{
    internal class Client
    {
        private Socket socket;
        private IPAddress ip;
        private string connectionWord;
        private string ipAddress;
        private int connectionPort;
        public Client(String address, int port, string keyword)
        {
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            connectionWord = keyword;
            connectionPort = port;
            ipAddress = address;
        }

        public Boolean Connect()
        {
            socket.Connect(ipAddress, connectionPort);
            write(connectionWord);
            if (readAll().Equals("connected"))
            {
                return true;
            }
            else 
            {
                socket.Close();
                return false;
            }

        }
        private void write(string data) 
        {
            byte[] bytesWord = Encoding.ASCII.GetBytes(data + "\n");
            socket.Send(bytesWord);
        }
        private String readAll() 
        {
            String output = "";

            while (socket.Available > 0)
            {
                byte[] received = new byte[1024];
                socket.Receive(received);
                output += Encoding.UTF8.GetString(received);
            }
            return output;
        }
        public String requestData()
        {
            socket.Send(Encoding.ASCII.GetBytes("data request\n"));
            Byte[] data = new Byte[2048];
            socket.Receive(data);
            socket.Send(Encoding.ASCII.GetBytes("received\n"));
            return Encoding.ASCII.GetString(data);
        }
    }
}
