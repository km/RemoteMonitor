package components;
import oshi.SystemInfo.*;
import oshi.hardware.CentralProcessor;
import oshi.hardware.Sensors;

public class CPU extends Component {
    private int cores;
    private long speed;
    private long[] currentSpeed;
    private int[] fanSpeeds;
    private transient CentralProcessor processor;
    private transient Sensors sensors;
    public CPU()
    {
        processor = si.getHardware().getProcessor();
        cores = processor.getPhysicalProcessorCount();
        componentName = processor.getProcessorIdentifier().getName();
        componentType = "CPU";
        speed = processor.getMaxFreq();
        sensors = si.getHardware().getSensors();
    }
    public void update() {
        usage = processor.getSystemCpuLoad(1000);
        temperature = sensors.getCpuTemperature();
        currentSpeed = processor.getCurrentFreq();
        fanSpeeds = sensors.getFanSpeeds();
        speed = processor.getMaxFreq();
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
