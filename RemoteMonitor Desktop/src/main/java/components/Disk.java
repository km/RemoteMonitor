package components;

import oshi.hardware.HWDiskStore;
import oshi.hardware.HWPartition;

import java.io.File;
import java.util.List;

public class Disk extends Component {
    private long capacity;
    private long availableCapacity;
    private List<HWPartition> partitions;
    private HWDiskStore diskStore;
    public Disk(HWDiskStore hwDiskStore)
    {
        diskStore = hwDiskStore;
        capacity = diskStore.getSize();
        componentName = diskStore.getName();
        partitions = diskStore.getPartitions();
    }

    public void update()
    {
        partitions = diskStore.getPartitions();
        setAvailableCapacity();
        lastUpdated = System.currentTimeMillis();
    }
    public long getAvailableCapacity() {
        return availableCapacity;
    }

    public long getCapacity() {
        return capacity;
    }

    public void setAvailableCapacity()
    {
        System.out.println();
        availableCapacity = 0;
        for(HWPartition p : partitions)
        {
            File diskPartition = new File(p.getMountPoint());
            availableCapacity += diskPartition.getFreeSpace();
        }
    }
}
