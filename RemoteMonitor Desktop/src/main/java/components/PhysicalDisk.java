package components;

import com.profesorfalken.jsensors.model.sensors.Load;
import oshi.hardware.HWDiskStore;
import oshi.hardware.HWPartition;
import com.profesorfalken.jsensors.model.components.Disk;
import java.io.File;
import java.util.List;

public class PhysicalDisk extends Component {
    private long capacity;
    private long availableCapacity;
    private transient List<HWPartition> partitions;
    private transient HWDiskStore diskStore;
    private transient Disk jdisk;
    public PhysicalDisk(HWDiskStore hwDiskStore, Disk Jdisk)
    {
        diskStore = hwDiskStore;
        capacity = diskStore.getSize();
        componentName = diskStore.getModel();
        componentType = "Disk";
        partitions = diskStore.getPartitions();
        jdisk = Jdisk;
    }

    public void update()
    {
        partitions = diskStore.getPartitions();
        setAvailableCapacity();
        temperature = checkTemp(jdisk.sensors.loads);
        lastUpdated = System.currentTimeMillis();
    }
    public long getAvailableCapacity() {
        return availableCapacity;
    }

    public long getCapacity() {
        return capacity;
    }

    private void setAvailableCapacity()
    {
        availableCapacity = 0;
        for(HWPartition p : partitions)
        {
            File diskPartition = new File(p.getMountPoint());
            availableCapacity += diskPartition.getFreeSpace();
        }
    }

    //checks if disk temperature can be accessed and returns its value
    private double checkTemp(List<Load> loads)
    {
        for (Load l : loads)
        {
            if (l.name.contains("Temperature")){
                return l.value;
            }
        }
        return 0;
    }
}
