package com.company;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import networking.KeywordGenerator;

import java.io.*;
import java.net.Inet4Address;
import java.net.UnknownHostException;
import java.util.Scanner;

public class Config
{
    private String localIp;
    private int port;
    private String keyword;
    private File jsonDir;
    public Config() throws Exception
    {
        configuration();
        localIp = Inet4Address.getLocalHost().getHostAddress();

    }
    private void configuration() throws Exception {
        jsonDir = new File("config.json");
        JsonObject jsonObject;
        try
        {
            if (!jsonDir.exists())
            {
                jsonObject = createFile();
            }
            else
            {
                jsonObject = readJson();
            }
            port = jsonObject.get("port").getAsInt();
            keyword = jsonObject.get("keyword").getAsString();
        }
        catch(Exception e)
        {
            throw e;
        }


    }
    private JsonObject createFile() throws IOException {
        jsonDir.createNewFile();
        JsonObject defaultJson = new JsonObject();
        KeywordGenerator kg = new KeywordGenerator();
        FileWriter fw = new FileWriter(jsonDir);

        defaultJson.addProperty("port", 40313);
        defaultJson.addProperty("keyword", kg.genKeyword(8));
        fw.write(defaultJson.getAsString());
        return defaultJson;
    }
    private JsonObject readJson() throws FileNotFoundException {
        Scanner reader = new Scanner(jsonDir);
        String save = "";
        while(reader.hasNextLine())
        {
            save += reader.nextLine() + "\n";
        }

        return new JsonObject().getAsJsonObject(save);
    }
    public int getPort() {
        return port;
    }

    public String getKeyword() {
        return keyword;
    }

    public String getLocalIp() {
        return localIp;
    }
}
