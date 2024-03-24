namespace APBD_containers_zaj3.Classes;

public class ContainerShip(int maxSpeed, int maxContainerValue, double maxWeightToCarry)
{
    private static int _idToAdd = 0;
    public int Id { get; } = _idToAdd++;
    public List<Container> Containers { get; set; } = [];
    public int MaxSpeed { get; set; } = maxSpeed;
    public int MaxContainerValue { get; set; } = maxContainerValue;
    public double MaxWeightToCarry { get; set; } = maxWeightToCarry;

    private bool CheckTheAmountOfSpace(int amount)
    {
        return Containers.Count + amount < MaxContainerValue;
    }
    public void AddContainer(Container container)
    {
        if (CheckTheAmountOfSpace(1))
            Containers.Add(container);
        else
            Console.WriteLine("Not enough space on the carrier.");
    }

    public void AddBundleOfContainers(List<Container> cons)
    {
        if (CheckTheAmountOfSpace(cons.Count))
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
}