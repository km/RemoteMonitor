package networking;
import java.io.*;
import java.net.*;
public class Server {
    private int listeningPort;
    private String keyword;
    private boolean isAuthenticated;
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
            System.out.println(connectedIp + " tried connecting with a wrong keyword");
            listener.close();
            return start();
        }
        else
        {
            return true;
        }
    }

    public Boolean write(String json) throws IOException {
        if (isAuthenticated)
        {
            writer.println(json);
            String response = reader.readLine();
            if (response == "received")
            {
                return true;
            }

        }
        return false;
    }

    public String read() throws IOException {
        return reader.readLine();
    }
    public Boolean checkAuthed() throws IOException
    {
        String input = read();
        if (input != null){
            if (input.equals(keyword))
            {
              isAuthenticated = true;
            }
        }
        return isAuthenticated;
    }

    public String getConnectedIp() {
        return connectedIp;
    }

    public Boolean isConnected()
    {
        return listener.isConnected();
    }
}
