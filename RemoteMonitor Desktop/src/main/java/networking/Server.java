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
            listener.close();
            return start();
        }
        else
        {
            isConnected = true;
            return true;
        }
    }

    public Boolean write(String json) throws IOException {
        if (isAuthenticated)
        {
            try
            {
                writer.println(json);
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

    public String read() {
        try {
            return reader.readLine();
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
