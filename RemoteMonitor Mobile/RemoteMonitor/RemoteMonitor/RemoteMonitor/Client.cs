using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            connectionWord = keyword;
            connectionPort = port;
            ipAddress = address;
        }

        public async Task<bool> ConnectAsync()
        {
         
            await socket.ConnectAsync(ipAddress, connectionPort);
            await WriteAsync(connectionWord);
            string s = await ReadAllAsync();
            if (s.Equals("connected"))
            {
                await WriteAsync("received");
                return true;
            }

            socket.Close();
            return false;
        }

        private async Task WriteAsync(string data)
        {
            byte[] bytesWord = Encoding.ASCII.GetBytes(data + "\n");
            await socket.SendAsync(new ArraySegment<byte>(bytesWord), SocketFlags.None);
        }

        private async Task<string> ReadAllAsync()
        {
            String output = "";
            byte[] received = new byte[1024];
            int bytesRead;

            while (true)
            {
                bytesRead = await socket.ReceiveAsync(new ArraySegment<byte>(received), SocketFlags.None);
                if (bytesRead == 0)
                    break; 
                output += Encoding.UTF8.GetString(received, 0, bytesRead);
                if (!(socket.Available > 0))
                    break;
            }
            Debug.WriteLine(output);
            try
            {
                return output.Substring(0, output.IndexOf('\r'));
            }
            catch (Exception)
            {

                return output.Trim();
            }
            
        }

        public async Task<string> RequestDataAsync()
        {
            await WriteAsync("data request");
            String data = await ReadAllAsync();
            await WriteAsync("received");
            return data;
        }

        // Disconnect
        public void Disconnect()
        {
            socket.Close();
            socket.Dispose();
        }
    }
}
