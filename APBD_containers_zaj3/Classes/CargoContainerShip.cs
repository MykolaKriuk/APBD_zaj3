namespace APBD_containers_zaj3.Classes;

public class CargoContainerShip(int maxSpeed, int maxContainerValue, double maxWeightToCarry)
{
    private static int _idToAdd;
    public int Id { get; } = _idToAdd++;
    public List<CargoContainer> Containers { get; } = [];
    private int MaxSpeed { get; } = maxSpeed;
    private int MaxContainerValue { get; } = maxContainerValue;
    private double MaxWeightToCarry { get; } = maxWeightToCarry;

    private bool CheckTheAmountOfSpace(int amount)
    {
        return Containers.Count + amount <= MaxContainerValue;
    }

    public void AddContainer(CargoContainer cargoContainer)
    {
        if (CheckTheAmountOfSpace(1) && (Containers.Sum(x => x.ContainerWeight)+cargoContainer.ContainerWeight)/1000 < MaxWeightToCarry)
            Containers.Add(cargoContainer);
        else
            Console.WriteLine("Not enough space on the carrier.");
    }

    public void AddBundleOfContainers(List<CargoContainer> cons)
    {
        if (CheckTheAmountOfSpace(cons.Count) && (Containers.Sum(x => x.ContainerWeight)+cons.Sum(x => x.CargoWeight))/1000 < MaxWeightToCarry)
            foreach (var v in cons)
                Containers.Add(v);
        else
            Console.WriteLine("Not enough space on the carrier.");
    }

    public void DeleteContainer(string id)
    {
        var conToRemove = Containers.FirstOrDefault(x => x.SerialNumber == id);
        if (conToRemove == null) return;
        Containers.Remove(conToRemove);
        Console.WriteLine($"Container {id} is deleted.");

    }

    public override string ToString()
    {
        string containers = "";
        foreach (var c in Containers)
        {
            containers += c + "\n";
        }
        return $"Container Ship: id={Id}, speed={MaxSpeed}, maxConValue={MaxContainerValue}, " +
               $"maxWeight={MaxWeightToCarry}\nIts containers:\n{containers}";
    }
}