package com.company;

import components.ComponentManager;
import networking.Server;

public class Main {
    public static void main(String[] args) throws Exception {
        ConfigurationManager configurationManager = new ConfigurationManager();
        ComponentManager componentManager = new ComponentManager();
        Server server = new Server(configurationManager.getPort(), configurationManager.getKeyword());

        System.out.println("Connection Information");
        System.out.println("Local connection IP: " + configurationManager.getLocalIp() + " Port: " + configurationManager.getPort());
        System.out.println("Keyword: " + configurationManager.getKeyword());
        server.start();
        System.out.println(server.getConnectedIp() + " successfully connected");

        System.out.println();
        while (server.isConnected())
        {
            String read = server.read();

            if (read.equals("data request"))
            {
                System.out.println("Client requested data");
                componentManager.updateAll();

                if (server.write(componentManager.toJson()))
                {
                    System.out.println("Successfully sent data to the client");
                }else
                {
                    System.out.println("Failed to send data to the client");
                }
            }
        }
        System.out.println("Connection disconnected");




    }
}
