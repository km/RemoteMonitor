package components;

import java.util.ArrayList;
import java.util.List;
import com.profesorfalken.jsensors.JSensors;
import com.profesorfalken.jsensors.model.components.Gpu;
import oshi.SystemInfo;
import oshi.hardware.GraphicsCard;
import oshi.hardware.HWDiskStore;

public class ComponentManager
{
    private List<GPU> gpus;
    private List<Disk> disks;
    private CPU cpu;
    private Ram ram;
    public ComponentManager()
    {
        cpu = new CPU();
        ram = new Ram();
        gpus = new ArrayList<GPU>();
        disks = new ArrayList<Disk>();
        List<Gpu> gpuJ = JSensors.get.components().gpus;
        List<GraphicsCard> graphicsCards = new SystemInfo().getHardware().getGraphicsCards();
        List<HWDiskStore> hwds = new SystemInfo().getHardware().getDiskStores();

        for (int i = 0; i < gpuJ.size(); i++)
        {
            gpus.add(new GPU(graphicsCards.get(i), gpuJ.get(i)));
        }
        for (HWDiskStore hwd : hwds)
        {
            disks.add(new Disk(hwd));
        }
    }

    public void updateAll()
    {
        for (GPU g : gpus) {
            g.update();
        }
        for (Disk d : disks) {
            d.update();
        }
        cpu.update();
        ram.update();
    }

    
}
