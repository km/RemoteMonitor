package components;

import oshi.hardware.GlobalMemory;

public class Ram extends Component{
    private long memoryTotal;
    private long memoryAvailable;
    private transient GlobalMemory gm;
    public Ram()
    {
        gm = si.getHardware().getMemory();
        memoryTotal = gm.getTotal();
        componentType = "Ram";
    }

    public void update()
    {
        memoryAvailable = gm.getAvailable();
        usage = (memoryAvailable/memoryTotal);
        lastUpdated = System.currentTimeMillis();
    }

    public long getMemoryAvailable() {
        return memoryAvailable;
    }

    public long getMemoryTotal() {
        return memoryTotal;
    }
}
