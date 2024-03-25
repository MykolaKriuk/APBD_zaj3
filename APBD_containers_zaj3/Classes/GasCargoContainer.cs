using APBD_containers_zaj3.Exceptions;
using APBD_containers_zaj3.Interfaces;

namespace APBD_containers_zaj3.Classes;

public class GasCargoContainer(int containerHeight, 
    double containerWeight, int containerDepth, double maxCargoWeight, int pressure)
    : CargoContainer(ContainerType, containerHeight, containerWeight, containerDepth, maxCargoWeight), IHazardNotifier
{
    private const string ContainerType = "G";
    private int Pressure { get; } = pressure;
    
    public void SendWarning()
    {
        Console.WriteLine($"WARNING! Dangerous situation with container {SerialNumber}");
    }

    public override void EmptyContainer()
    {
        CargoWeight -= CargoWeight * 0.95;
        Console.WriteLine("Emptied 95% of container's cargo.");
    }

    public override void AddCargo(double mass)
    {
        if (CargoWeight + mass > MaxCargoWeight)
            throw new OverfillException("Too many gas!");
        CargoWeight += mass;
    }

    public override string ToString()
    {
        return "Gas " + base.ToString() + $", pressure={Pressure}";
    }
}