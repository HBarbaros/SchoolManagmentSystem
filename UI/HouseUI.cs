public class HouseUI
{
    private HouseRepo _houseRepo;

    public HouseUI(HouseRepo houseRepo)
    {
        _houseRepo = houseRepo;
    }

    public void DisplayAllHousesInOrder()
    {
        List<House> h = _houseRepo.GetHousesByRanking().ToList();

        foreach (var house in h)
        {
            Console.WriteLine("\n Name: " + house.Name +
                                "\n Points: " + house.Points);
        }
    }

    public void DisplayAllHouses()
    {

        List<House> h = _houseRepo.GetAllHouses();

        foreach (var house in h)
        {
            Console.WriteLine("\n ID" + house.Id +
                                "\n Name: " + house.Name +
                                "\n Points: " + house.Points);
        }

    }

    public void DeductHousePoints()
    {
        Console.Clear();
        DisplayAllHouses();
        Console.WriteLine("Select house (ID): ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (_houseRepo.CheckIdExists(id))
            {
                Console.WriteLine("Amount to deduct: ");
                if (int.TryParse(Console.ReadLine(), out int amount))
                {
                    if (_houseRepo.CheckAmount(amount, "-") == true)
                    {
                        _houseRepo.MinusHousePoints(id, amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount format");
                }
            }
            else
            {
                Console.WriteLine("ID DOESNSR EXSIT");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID");
        }
        return;
    }

    public void AddHousePoints()
    {
        Console.Clear();
        DisplayAllHouses();
        Console.WriteLine("Select house (ID): ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (_houseRepo.CheckIdExists(id))
            {
                Console.WriteLine("Amount to add: ");
                if (int.TryParse(Console.ReadLine(), out int amount))
                {
                    if (_houseRepo.CheckAmount(amount, "+") == true)
                    {
                        _houseRepo.AddHousePoints(id, amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount");

                    }
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
            else
            {
                Console.WriteLine("ID Doesnt existttt");
            }
        }
        else
        {
            Console.WriteLine("Invalid id");
        }
    }
}