package components;

import oshi.hardware.GraphicsCard;

public class GPU extends Component{
    private long vramTotal;
    private int vramAvailable;
    private GraphicsCard graphicsCard;
    public GPU(GraphicsCard gpu)
    {
        graphicsCard = gpu;
        vramTotal = graphicsCard.getVRam();
    }
}
