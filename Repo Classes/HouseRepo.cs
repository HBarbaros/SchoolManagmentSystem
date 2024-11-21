using System.Data.Common;

public class HouseRepo : DapperRepo<House>
{
    public HouseRepo(DatabaseConnection databaseConnection) : base(databaseConnection)
    {
    }

    public List<House> GetAllHouses()
    {

        return GetAll("Houses").ToList();
    }

    public bool? CheckAmount(int amount, string plusorminus)
    {
        if (plusorminus == "+")
        {
            if (amount > 0)
            {
                return true;
            }
        }
        if (plusorminus == "-")
        {
            if (amount > 0)
            {
                return true;
            }
        }
        return null;
    }

    public bool CheckIdExists(int id)
    {

        List<House> h = GetAllHouses();

        foreach (var house in h)
        {
            if (id == house.Id)
            {
                return true;
            }
        }
        return false;








    }

}




