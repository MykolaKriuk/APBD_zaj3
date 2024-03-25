using APBD_containers_zaj3.Classes;
using Container = System.ComponentModel.Container;

namespace APBD_containers_zaj3;

class Program
{
    public static void Main(string[] args)
    {
        
    }

    public static CargoContainer? CreateContainer(string type)
    {
        if (type != "G" || type != "L" || type != "F")
        {
            Console.WriteLine("Invalid container.");
            return null;
        }
        Console.WriteLine("Enter height of the container: ");
        var containerHeight = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter weight of the container: ");
        var containerWeight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter depth of the container: ");
        var containerDepth = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter max cargoweight: ");
        var maxCargoWeight = Convert.ToDouble(Console.ReadLine());

        CargoContainer? resCon = null;
        switch (type)
        {
            case "L":
            {
                Console.WriteLine("Is cargo dangerous? Print 1/0: ");
                var isDangerous = Console.ReadLine() == "1";
                resCon = new LiquidCargoContainer(
                    containerHeight,
                    containerWeight,
                    containerDepth,
                    maxCargoWeight,
                    isDangerous);
                break;
            }
            case "G":
            {
                Console.WriteLine("Enter a pressure level: ");
                var pressure = Convert.ToInt32(Console.ReadLine());
                resCon = new GasCargoContainer(
                    containerHeight,
                    containerWeight,
                    containerDepth,
                    maxCargoWeight,
                    pressure);
                break;
            }
            case "F":
            {
                Console.WriteLine("Enter a product type: ");
                var productType = Console.ReadLine();
                Console.WriteLine("Enter a needed temperature: ");
                var temperature = Convert.ToDouble(Console.ReadLine());
                resCon = new FridgeCargoContainer(
                    containerHeight,
                    containerWeight,
                    containerDepth,
                    maxCargoWeight,
                    productType,
                    temperature);
                break;
                
            }
        }
        Console.WriteLine($"New Container - {resCon}");
        return resCon;
    }
}