package components;
import oshi.SystemInfo.*;
import oshi.hardware.CentralProcessor;
import oshi.hardware.Sensors;

public class CPU extends Component {
    private int cores;
    private long speed;
    private long[] currentSpeed;
    private CentralProcessor processor;
    private Sensors sensors;
    public CPU()
    {
        processor = si.getHardware().getProcessor();
        cores = processor.getPhysicalProcessorCount();
        componentName = processor.getProcessorIdentifier().getName();
        speed = processor.getMaxFreq();
        sensors = si.getHardware().getSensors();
    }
    public void update() {
        usage = processor.getSystemCpuLoad(1000);
        temperature = sensors.getCpuTemperature();
        currentSpeed = processor.getCurrentFreq();
        lastUpdated = System.currentTimeMillis();
    }
    public long getSpeed()
    {
        return speed;
    }
    public long[] getCurrentSpeed()
    {
        return currentSpeed;
    }
    public int getCores() {
        return cores;
    }
}
