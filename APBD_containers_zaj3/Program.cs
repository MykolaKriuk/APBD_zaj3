using APBD_containers_zaj3.Classes;

namespace APBD_containers_zaj3;

class Program
{
    public static void Main()
    {
        CargoContainer liqCon = new LiquidCargoContainer(
            50, 5, 40, 20, false
        );
        Console.WriteLine("Adding cargo to container.\n");
        liqCon.AddCargo(15);
        Console.WriteLine(liqCon);
        
        
        CargoContainer gasCon = new GasCargoContainer(
            50, 5, 40, 20, 100
        );
        Console.WriteLine("\nEmptying the container.\n");
        gasCon.AddCargo(15);
        gasCon.EmptyContainer();
        Console.WriteLine(gasCon);
        
        
        CargoContainer frCon = new FridgeCargoContainer(
            50, 5, 40, 20, "Bananas", 10
        );
        
        
        Console.WriteLine("\nCreating a container.\n");
        Console.Write("Enter a container type: ");
        var newContainer = CreateContainer(Console.ReadLine());
        

        CargoContainerShip ship1 = new CargoContainerShip(20, 5, 50);
        CargoContainerShip ship2 = new CargoContainerShip(20, 5, 50);

        Console.WriteLine("\nAdding many containers to a ship.\n");
        ship1.AddBundleOfContainers([liqCon /*0*/, gasCon /*1*/, frCon /*2*/,
            new GasCargoContainer(50, 5, 40, 20, 100), //3
            new GasCargoContainer(50, 5, 40, 20, 100) //4
        ]);
        Console.WriteLine(ship1);
        
        
        Console.WriteLine("\nAdding container to a ship.\n");
        if (newContainer != null) ship2.AddContainer(newContainer);
        Console.WriteLine(ship2);

        
        Console.WriteLine("\nDeleting a container from a ship.\n");
        ship1.DeleteContainer("KON-L-1");
        Console.WriteLine(ship1);


        Console.WriteLine("\nReplacing container with another.\n");
        CargoContainer conToChange = new FridgeCargoContainer(
            50, 5, 40, 20, "Meat", -10
        );
        ReplaceContainer(ship1, ship1.Containers[3], conToChange);
        Console.Write(ship1);


        Console.WriteLine("\nMoving a container from one ship to another.\n");
        MoveFromOneShipToAnother(ship1, ship2);
        Console.WriteLine(ship1);
        Console.WriteLine(ship2);
    }

    private static CargoContainer? CreateContainer(string type)
    {
        if (!"LFG".Contains(type))
        {
            Console.WriteLine("Invalid container.");
            return null;
        }
        Console.Write("Enter height of the container: ");
        var containerHeight = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter weight of the container: ");
        var containerWeight = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter depth of the container: ");
        var containerDepth = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter max cargo weight: ");
        var maxCargoWeight = Convert.ToDouble(Console.ReadLine());

        CargoContainer? resCon = null;
        switch (type)
        {
            case "L":
            {
                Console.Write("Is cargo dangerous? Print 1/0: ");
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
                Console.Write("Enter a pressure level: ");
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
                Console.Write("Enter a product type: ");
                var productType = Console.ReadLine();
                Console.Write("Enter a needed temperature: ");
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

    private static void ReplaceContainer(CargoContainerShip ship, CargoContainer con1, CargoContainer con2)
    {
        if (!ship.Containers.Contains(con1))
        {
            Console.WriteLine("There is no such container.");
            return;
        }

        var ind = ship.Containers.IndexOf(con1);
        ship.Containers[ind] = con2;
        Console.WriteLine($"Container {con1.SerialNumber} replaced with container {con2.SerialNumber}.");
    }

    private static void MoveFromOneShipToAnother(CargoContainerShip ship1, CargoContainerShip ship2)
    {
        Console.WriteLine("Enter serial number of container you want to move: ");
        var serNum = Console.ReadLine();
        var conToMove = ship1.Containers.FirstOrDefault(x => x.SerialNumber == serNum);
        if (conToMove == null)
        {
            Console.WriteLine("No such container.");
            return;
        }

        ship1.Containers.Remove(conToMove);
        ship2.Containers.Add(conToMove);
        Console.WriteLine($"Container {conToMove.SerialNumber} is move from ship {ship1.Id} to ship {ship2.Id}.");
    }
}