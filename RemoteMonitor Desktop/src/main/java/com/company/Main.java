package com.company;
import com.profesorfalken.jsensors.JSensors;
import components.CPU;
import components.Component;
import components.GPU;
import org.w3c.dom.ls.LSOutput;
import oshi.*;

public class Main {

    public static void main(String[] args) {

        CPU cpu = new CPU();
        cpu.update();
        System.out.println(cpu.getComponentName());
        System.out.println(cpu.getCores());
        System.out.println(cpu.getUsage());
        System.out.println(cpu.getTemperature());
        System.out.println(cpu.getCurrentSpeed()[1]);
        System.out.println(cpu.getSpeed());
    }
}
