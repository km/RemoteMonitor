package components;

import oshi.hardware.GlobalMemory;

public class Ram extends Component{
    private long memoryTotal;
    private long memoryAvailable;
    private GlobalMemory gm;
    public Ram()
    {
        gm = si.getHardware().getMemory();
        memoryTotal = gm.getTotal();
    }

    public void update()
    {
        memoryAvailable = gm.getAvailable();
        usage = (memoryAvailable/memoryTotal);
    }

    public long getMemoryAvailable() {
        return memoryAvailable;
    }

    public long getMemoryTotal() {
        return memoryTotal;
    }
}
