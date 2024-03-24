using APBD_containers_zaj3.Interfaces;

namespace APBD_containers_zaj3.Classes;

public class LiquidContainer(string containerType, int cargoWeight, int containerHeight, 
    int containerWeight, int containerDepth, int maxCargoWeight, bool isDangerous) 
    : Container(containerType, cargoWeight, containerHeight, containerWeight, containerDepth, maxCargoWeight), IHazardNotifier
{
    public bool IsDangerous { get; } = isDangerous;
    
    public void SendWarning()
    {
        Console.WriteLine($"WARNING! Dangerous situation with container {SerialNumber}");
    }

    public override void AddCargo(int mass)
    {
        var weightLimit = isDangerous ? MaxCargoWeight * 0.5 : MaxCargoWeight * 0.9;

        if (CargoWeight + mass > weightLimit)
        {
            SendWarning();
            return;
        }

        CargoWeight += mass;
    }
}