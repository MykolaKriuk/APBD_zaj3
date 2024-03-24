using APBD_containers_zaj3.Exceptions;

namespace APBD_containers_zaj3.Classes;

public abstract class Container (string containerType, int cargoWeight, int containerHeight, 
    int containerWeight, int containerDepth, int maxCargoWeight)
{
    private static int _numeralId = 0;

    public string SerialNumber { get; } = $"KON-{containerType}-{_numeralId++}";
    public int CargoWeight { get; protected set; } = cargoWeight;
    public int ContainerHeight { get; protected set; } = containerHeight;
    public int ContainerWeight { get; protected set; } = containerWeight;
    public int ContainerDepth { get; protected set; } = containerDepth;
    public int MaxCargoWeight { get; protected set; } = maxCargoWeight;

    public virtual void EmptyContainer()
    {
        CargoWeight = 0;
        Console.WriteLine($"Emptied the container {SerialNumber}");
    }

    public virtual void AddCargo(int mass)
    {
        if (mass + CargoWeight > MaxCargoWeight)
            throw new OverfillException();

        CargoWeight += mass;
        Console.WriteLine($"Added {mass} kilos to container {SerialNumber}");
    }
}