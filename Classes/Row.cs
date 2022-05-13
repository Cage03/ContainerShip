namespace ContainerShip.Classes;

public class Row
{
    public List<Stack> Stacks = new();

    public Row(int length)
    {
        for (int i = 0; i < length; i++)
        {
            Stacks.Add(new Stack());
        }
    }
}

// 0 
// 
//
//
//
// 
// z 