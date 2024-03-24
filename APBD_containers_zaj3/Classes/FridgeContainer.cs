namespace APBD_containers_zaj3.Classes;

public class FridgeContainer : Container
{
    private const string ContainerType = "F";

    private static Dictionary<string, double> _prodTempDictionary = new Dictionary<string, double>
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
    
    public string ProductType { get; }
    public double Temperature { get; protected set; }

    public FridgeContainer(double cargoWeight, int containerHeight,
        double containerWeight, int containerDepth, double maxCargoWeight, string productType, double temperature)
        : base(ContainerType, cargoWeight, containerHeight, containerWeight, containerDepth, maxCargoWeight)
    {
        ProductType = productType;
        if (temperature < _prodTempDictionary[ProductType])
        {
            Console.WriteLine($"Temperature {temperature}C is too low. Changed to minimal permissible - {_prodTempDictionary[ProductType]}");
            Temperature = _prodTempDictionary[ProductType];
        }
        else
        {
            Temperature = temperature;
        }
    }
}