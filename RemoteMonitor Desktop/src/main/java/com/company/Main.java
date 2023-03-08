package com.company;

import components.ComponentManager;
import networking.Server;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;

public class Main {
    public static void main(String[] args) throws Exception {
        clearTerminal();

        ConfigurationManager configurationManager = new ConfigurationManager();
        ComponentManager componentManager = new ComponentManager();
        while(true)
        {
            Server server = new Server(configurationManager.getPort(), configurationManager.getKeyword());
            componentManager.updateAll();
            System.out.println(componentManager.toJson());
            System.out.println("Connection Information");
            System.out.println("Local connection IP: " + configurationManager.getLocalIp() + " Port: " + configurationManager.getPort());
            System.out.println("Keyword: " + configurationManager.getKeyword());
            server.start();
            System.out.println(server.getConnectedIp() + " successfully connected\n");

            while (server.isConnected()) {
                String read = server.read();

                if (read != null && read.equals("data request")) {
                    System.out.println("Client requested data");
                    componentManager.updateAll();
                    if (server.write(componentManager.toJson())) {
                        System.out.println("Successfully sent data to the client");
                    } else {
                        System.out.println("Failed to send data to the client");

                    }
                }

            }
            System.out.println("Connection disconnected");
            System.out.println("Restarting server..."+"\n");
            server.closeServer();


        }


    }
    public static void clearTerminal() throws IOException {
        if (System.getProperty("os.name").contains("Windows"))
        {
            new ProcessBuilder("cmd", "/c", "cls").inheritIO().start();
        }
        else
        {
            Runtime.getRuntime().exec("clear");
        }
    }

}
