namespace APBD_containers_zaj3.Classes;

public class FridgeCargoContainer : CargoContainer
{
    private const string ContainerType = "F";

    private static readonly Dictionary<string, double> ProdTempDictionary = new()
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };

    private string ProductType { get; }
    private double Temperature { get; }

    public FridgeCargoContainer(int containerHeight,
        double containerWeight, int containerDepth, double maxCargoWeight, string productType, double temperature)
        : base(ContainerType, containerHeight, containerWeight, containerDepth, maxCargoWeight)
    {
        var tmp = productType;
        do
        {
            if (ProdTempDictionary.ContainsKey(tmp)) break;
            Console.Write("Invalid product type. Enter new one: ");
            tmp = Console.ReadLine();
        } while (true);

        ProductType = tmp;
        if (temperature < ProdTempDictionary[ProductType])
        {
            Console.WriteLine($"Temperature {temperature}C is too low. Changed to minimal permissible - {ProdTempDictionary[ProductType]}");
            Temperature = ProdTempDictionary[ProductType];
        }
        else
        {
            Temperature = temperature;
        }
    }

    public override string ToString()
    {
        return "Fridge " + base.ToString() + $", prodType={ProductType}, temp={Temperature}";
    }
}