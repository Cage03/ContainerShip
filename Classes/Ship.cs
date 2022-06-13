namespace ContainerShip.Classes;

public class Ship
{
    public List<Row> Rows = new();
    public int MaxWeight;

    public Ship(int length, int width)
    {
        if (length < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        if (width < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(width));
        }
        for (int i = 0; i < width; i++)
        {
            Rows.Add(new Row(length));
        }
    }
}