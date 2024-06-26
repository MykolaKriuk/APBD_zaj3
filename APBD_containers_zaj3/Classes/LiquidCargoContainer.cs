using APBD_containers_zaj3.Exceptions;
using APBD_containers_zaj3.Interfaces;

namespace APBD_containers_zaj3.Classes;

public class LiquidCargoContainer(int containerHeight, 
    double containerWeight, int containerDepth, double maxCargoWeight, bool isDangerous) 
    : CargoContainer(ContainerType, containerHeight, containerWeight, containerDepth, maxCargoWeight), IHazardNotifier
{
    private const string ContainerType = "L";
    private bool IsDangerous { get; } = isDangerous;
    
    public void SendWarning()
    {
        Console.WriteLine($"WARNING! Dangerous situation with container {SerialNumber}");
    }

    public override void AddCargo(double mass)
    {
        var weightLimit = IsDangerous ? MaxCargoWeight * 0.5 : MaxCargoWeight * 0.9;

        if (CargoWeight + mass > weightLimit)
        {
            SendWarning();
            throw new OverfillException("WARNING! Overfill is inevitable!");
        }

        CargoWeight += mass;
        Console.WriteLine($"Added {mass} kilos to container {SerialNumber}");
    }

    public override string ToString()
    {
        return "Liquid " + base.ToString() + $", isDangerous={IsDangerous}";
    }
}