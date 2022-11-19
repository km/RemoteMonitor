package components;

import com.profesorfalken.jsensors.JSensors;
import com.profesorfalken.jsensors.model.components.Components;
import com.profesorfalken.jsensors.model.components.Gpu;
import com.profesorfalken.jsensors.model.sensors.Load;
import oshi.hardware.GraphicsCard;

import java.util.List;

public class GPU extends Component{
    private long vramTotal;
    private transient GraphicsCard graphicsCard;
    private transient Gpu jgpu;
    public GPU(GraphicsCard gpu, Gpu gpu2)
    {
        graphicsCard = gpu;
        vramTotal = graphicsCard.getVRam();
        componentName = graphicsCard.getName();
        componentType = "GPU";
        jgpu = gpu2;

    }
    public void update()
    {
        try {
            temperature = jgpu.sensors.temperatures.get(0).value;
        }
        catch (Exception e){}
        usage = jgpu.sensors.loads.get(0).value;
        lastUpdated = System.currentTimeMillis();
    }

    public long getVramTotal() {
        return vramTotal;
    }
}
