package com.company;

import com.google.gson.*;
import com.google.gson.reflect.TypeToken;
import networking.KeywordGenerator;

import java.io.*;
import java.lang.reflect.Type;
import java.net.Inet4Address;
import java.util.Scanner;

public class ConfigurationManager
{
    Config config;
    private File jsonDir;
    public ConfigurationManager() throws Exception
    {
        jsonDir = new File("config.json");
        configuration();
        config.localIp = Inet4Address.getLocalHost().getHostAddress();

    }
    private void configuration() throws Exception {

        try
        {
            if (!jsonDir.exists())
            {
                System.out.println("Config file not found! Creating new config...");

                KeywordGenerator kg = new KeywordGenerator();
                config = new Config();
                config.keyword = kg.genKeyword(8);
                config.port = 48203;
                createFile();
            }
            else
            {
                config = readJson();
                if(config == null)
                {
                    System.exit(0);
                }
            }

        }
        catch(Exception e)
        {
            throw e;
        }


    }
    //Creates the config file and writes a new config Json to it
    private void createFile() throws IOException {
        FileWriter f = new FileWriter(jsonDir);
        jsonDir.createNewFile();
        Gson g = new Gson();
        String jsonWrite = g.toJson(config);
        f.write(jsonWrite);
        f.flush();
    }

    private Config readJson() throws FileNotFoundException {
        Scanner reader = new Scanner(jsonDir);
        String jsonString = "";
        while(reader.hasNextLine())
        {
            jsonString += reader.nextLine() + "\n";
        }

        //converts Json string into a Config object
        try {
            Config configReturn = new Gson().fromJson(jsonString, new TypeToken<Config>() {
            }.getType());
            return configReturn;
        }
        catch (Exception e)
        {
            System.out.println("Error parsing config JSON! Please fix the JSON or delete the file and restart the application.");
            return null;
        }
    }
    public int getPort() {
        return config.port;
    }

    public String getKeyword() {
        return config.keyword;
    }

    public String getLocalIp() {
        return config.localIp;
    }
}
