// Product
public class House
{
    public string Walls { get; set; }
    public string Roof { get; set; }
    public string Foundation { get; set; }
    public string Interior { get; set; }

    public override string ToString()
    {
        return $"House with {Walls} walls, {Roof} roof, {Foundation} foundation, and {Interior} interior.";
    }
}

// Abstract Builder
public interface IHouseBuilder
{
    void BuildWalls();
    void BuildRoof();
    void BuildFoundation();
    void BuildInterior();
    House GetHouse();
}

// Concrete Builder 1
public class WoodenHouseBuilder : IHouseBuilder
{
    private House _house = new House();

    public void BuildWalls() => _house.Walls = "Wooden walls";
    public void BuildRoof() => _house.Roof = "Wooden roof";
    public void BuildFoundation() => _house.Foundation = "Wooden foundation";
    public void BuildInterior() => _house.Interior = "Wooden interior";

    public House GetHouse() => _house;
}

// Concrete Builder 2
public class StoneHouseBuilder : IHouseBuilder
{
    private House _house = new House();

    public void BuildWalls() => _house.Walls = "Stone walls";
    public void BuildRoof() => _house.Roof = "Stone roof";
    public void BuildFoundation() => _house.Foundation = "Stone foundation";
    public void BuildInterior() => _house.Interior = "Stone interior";

    public House GetHouse() => _house;
}

// Director
public class HouseDirector
{
    private IHouseBuilder _builder;

    public HouseDirector(IHouseBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructHouse()
    {
        _builder.BuildFoundation();
        _builder.BuildWalls();
        _builder.BuildRoof();
        _builder.BuildInterior();
    }

    public House GetHouse() => _builder.GetHouse();
}

// Client
class Program
{
    static void Main(string[] args)
    {
        // Build a wooden house
        IHouseBuilder woodenHouseBuilder = new WoodenHouseBuilder();
        HouseDirector director = new HouseDirector(woodenHouseBuilder);
        director.ConstructHouse();
        House woodenHouse = director.GetHouse();
        Console.WriteLine(woodenHouse);

        // Build a stone house
        IHouseBuilder stoneHouseBuilder = new StoneHouseBuilder();
        director = new HouseDirector(stoneHouseBuilder);
        director.ConstructHouse();
        House stoneHouse = director.GetHouse();
        Console.WriteLine(stoneHouse);
    }
}
