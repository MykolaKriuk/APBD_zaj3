namespace APBD_containers_zaj3.Classes;

public class ContainerShip(List<Container> containers, int maxSpeed, int MaxContainerValue, double MaxWeightToCarry)
{
    public List<Container> Containers { get; set; } = containers;
    public int MaxSpeed { get; set; } = maxSpeed;
    public int MaxContainerValue { get; set; } = MaxContainerValue;
    public double MaxWeightToCarry { get; set; } = MaxWeightToCarry;
    
    
}