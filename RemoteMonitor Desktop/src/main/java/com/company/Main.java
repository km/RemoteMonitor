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

        while (server.isConnected())
        {
            
        }





    }
}
