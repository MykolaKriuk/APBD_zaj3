using APBD_containers_zaj3.Exceptions;

namespace APBD_containers_zaj3.Classes;

public abstract class CargoContainer (string containerType, int containerHeight, 
    double containerWeight, int containerDepth, double maxCargoWeight)
{
    private static int _numeralId = 1;

    public string SerialNumber { get; } = $"KON-{containerType}-{_numeralId++}";
    public double CargoWeight { get; protected set; }
    private int ContainerHeight { get; } = containerHeight;
    public double ContainerWeight { get; } = containerWeight;
    private int ContainerDepth { get; } = containerDepth;
    protected double MaxCargoWeight { get; } = maxCargoWeight;

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

    public override string ToString()
    {
        return $"container: serialNum={SerialNumber}, cargoWeight={CargoWeight}, conHeight={ContainerHeight}, " +
               $"conWeight={ContainerWeight}, conDepth={ContainerDepth}, " +
               $"maxCargoWeight={MaxCargoWeight}";
    }
}