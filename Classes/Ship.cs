namespace ContainerShip.Classes;

public class Ship
{
    public List<Row> Rows = new();
    public int MaxWeight;

    public Ship(int length, int width)
    {
        for (int i = 0; i < width; i++)
        {
            Rows.Add(new Row(length));
        }
    }
}