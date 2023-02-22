package networking;
import java.io.*;
import java.net.*;
public class Server {
    private int listeningPort;
    private String keyword;
    private boolean isAuthenticated;
    private boolean isConnected;
    private ServerSocket connectionSocket;
    private Socket listener;
    private PrintWriter writer;
    private BufferedReader reader;
    private String connectedIp;
    public Server(int port, String connectionKeyword) throws IOException
    {
        listeningPort = port;
        keyword = connectionKeyword;
        isAuthenticated = false;
        isConnected = false;
        connectionSocket = new ServerSocket(listeningPort);
    }

    public boolean start() throws IOException
    {
        listener = connectionSocket.accept();
        connectedIp = listener.getRemoteSocketAddress().toString();
        writer = new PrintWriter(listener.getOutputStream(), true);
        reader = new BufferedReader(new InputStreamReader(listener.getInputStream()));
        //Will keep looping the function till a client connects with a correct keyword
        if (!checkAuthed())
        {
            writeUnauth("failed");
            listener.close();
            return start();
        }
        else
        {
            isConnected = true;
            write("connected");
            return true;
        }
    }

    public Boolean write(String data) throws IOException {
        if (isAuthenticated)
        {
            try
            {
                writer.println(data);
                String response = reader.readLine();
                if (response.equals("received"))
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                isConnected = false;
            }

        }
        return false;
    }
    private void writeUnauth(String data) throws IOException
    {

            try
            {
                writer.println(data);
                String response = reader.readLine();
            }
            catch(Exception e)
            {
            }
    }
    public String read() {
        try {
            String data = reader.readLine();
            if (data == null)
            {
                isConnected = false;
                return "disconnected";
            }
            return data;
        }
        catch(Exception e){
            isConnected = false;
            return "disconnected";
        }
    }
    public Boolean checkAuthed() throws IOException
    {
        try
        {
            String input = read();
            System.out.println("Checking");
            if (input != null)
            {
                if (input.equals(keyword))
                {
                    isAuthenticated = true;
                }
                else
                {
                    System.out.println(connectedIp + " tried connecting with a wrong keyword " + "\"" + input + "\"");
                }
            }
        }
        catch(Exception e)
        {
            isConnected = false;
        }
        return isAuthenticated;
    }
    public void closeServer() throws IOException {
        listener.close();
        connectionSocket.close();
    }
    public String getConnectedIp() {
        return connectedIp;
    }

    public Boolean isConnected()
    {
        return isConnected;
    }
}
