namespace ContainerShip.Classes;

public class Container
{
    public Type type;
    public int weight;
    public readonly int maxCarryWeight = 120000;


    public Container(Type type)
    {
        Random random = new();
        weight = random.Next(4000, 30000);
        this.type = type;
    }

    public Container(int weight, Type type) //set weight for testing
    {
        this.weight = weight;
        this.type = type;
    }
}

public enum Type
{
    Standard,
    Valuable,
    Cooled,
    CooledValuable
    
}