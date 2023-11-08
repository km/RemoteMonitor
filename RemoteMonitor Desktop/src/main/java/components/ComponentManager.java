package components;

import java.util.ArrayList;
import java.util.List;
import com.google.gson.Gson;
import com.profesorfalken.jsensors.JSensors;
import com.profesorfalken.jsensors.model.components.Cpu;
import com.profesorfalken.jsensors.model.components.Disk;
import com.profesorfalken.jsensors.model.components.Gpu;
import com.profesorfalken.jsensors.model.sensors.Fan;
import com.profesorfalken.jsensors.model.sensors.Load;
import com.profesorfalken.jsensors.model.sensors.Temperature;
import oshi.SystemInfo;
import oshi.hardware.GraphicsCard;
import oshi.hardware.HWDiskStore;

public class ComponentManager
{
    private List<GPU> gpus;
    private List<PhysicalDisk> disks;
    private CPU cpu;
    private Ram ram;
    public ComponentManager()
    {
        cpu = new CPU();
        ram = new Ram();
        gpus = new ArrayList<GPU>();
        disks = new ArrayList<PhysicalDisk>();
        List<Gpu> gpuJ = JSensors.get.components().gpus;
        List<GraphicsCard> graphicsCards = new SystemInfo().getHardware().getGraphicsCards();
        List<HWDiskStore> hwDiskStoreList = new SystemInfo().getHardware().getDiskStores();
        List<Disk> diskJ = JSensors.get.components().disks;
        for (int i = 0; i < gpuJ.size(); i++)
        {
            gpus.add(new GPU(graphicsCards.get(i), gpuJ.get(i)));
        }
        for (int i = 0; i < hwDiskStoreList.size(); i++)
        {
            disks.add(new PhysicalDisk(hwDiskStoreList.get(i), diskJ.get(i)));
        }

    }

    public void updateAll()
    {
        for (GPU g : gpus) {
            g.update();
        }
        for (PhysicalDisk d : disks) {
            d.update();
        }
        cpu.update();
        ram.update();
    }

    public String toJson()
    {
        Gson g = new Gson();
        return "[" + g.toJson(cpu) + ", " + g.toJson(gpus) + ", " + g.toJson(ram) + ", " + g.toJson(disks) + "]";
    }
}
