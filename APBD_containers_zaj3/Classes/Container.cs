using APBD_containers_zaj3.Exceptions;

namespace APBD_containers_zaj3.Classes;

public abstract class Container (string containerType, double cargoWeight, int containerHeight, 
    double containerWeight, int containerDepth, double maxCargoWeight)
{
    private static int _numeralId = 0;

    public string SerialNumber { get; } = $"KON-{containerType}-{_numeralId++}";
    public double CargoWeight { get; protected set; } = cargoWeight;
    public int ContainerHeight { get; protected set; } = containerHeight;
    public double ContainerWeight { get; protected set; } = containerWeight;
    public int ContainerDepth { get; protected set; } = containerDepth;
    public double MaxCargoWeight { get; protected set; } = maxCargoWeight;

    public virtual void EmptyContainer()
    {
        CargoWeight = 0;
        Console.WriteLine($"Emptied the container {SerialNumber}");
    }

    public virtual void AddCargo(double mass)
    {
        if (mass + CargoWeight > MaxCargoWeight)
            throw new OverfillException("WARNING! Overfill is inevitable!");

        CargoWeight += mass;
        Console.WriteLine($"Added {mass} kilos to container {SerialNumber}");
    }
}