using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RemoteMonitor
{
    public class Client
    {
        private Socket socket;
        private string connectionWord;
        private string ipAddress;
        private int connectionPort;
        public Client(String address, int port, string keyword)
        {
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.SendTimeout = 5000;
            socket.ReceiveTimeout = 5000;

            connectionWord = keyword;
            connectionPort = port;
            ipAddress = address;
        }

        public Boolean Connect()
        {

            socket.Connect(ipAddress, connectionPort);
            write(connectionWord);
            string s = readAll();
            if (s.Equals("connected"))
            {
                write("received");
                return true;
            }
           
            socket.Close();
            return false;
           
        }
        private void write(string data) 
        {
            byte[] bytesWord = Encoding.ASCII.GetBytes(data + "\n");
            socket.Send(bytesWord);
        }
        private String readAll() 
        {
            String output = "";
            try
            {
                do
                {
                    byte[] received = new byte[1024];
                    socket.Receive(received);
                    output += Encoding.UTF8.GetString(received);
                }
                while (socket.Available > 0);

            }
            catch (Exception)
            {

            }
            
        
          
            return output.Substring(0,output.IndexOf('\r'));
        }
        public String requestData()
        {
            write("data request");
            String data = readAll();
            write("received");
            return data;
        }

        //disconnect
        public void disconnect()
        { 
            socket.Close();
            socket.Dispose();
        }
    }
}
