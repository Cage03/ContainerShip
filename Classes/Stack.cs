namespace ContainerShip.Classes;

public class Stack
{
    public List<Container> Containers = new();
    public int weight;

    public bool PlaceContainer(Container container)
    {
        var highestWeightContainer = new Container(0, Type.Cooled);
        var totalWeight = container.weight;

        foreach (var container1 in Containers)
        {
            if (container1.weight > highestWeightContainer.weight &&
                container1.type is not (Type.Valuable or Type.CooledValuable))
            {
                highestWeightContainer = container1;
            }

            totalWeight += container1.weight;
        }

        weight = totalWeight;
        if (container.weight > highestWeightContainer.weight)
        {
            totalWeight -= container.weight;
            if (totalWeight >= container.maxCarryWeight) return false;
            Containers.Add(container);
            return true;
        }

        totalWeight -= highestWeightContainer.weight;
        if (totalWeight > highestWeightContainer.maxCarryWeight) return false;
        Containers.Remove(highestWeightContainer);
        Containers.Add(container);
        Containers.Add(highestWeightContainer);
        return true;
    }

    public string StackUrl()
    {
        string url = "";
        foreach (var container in Containers)
        {
            url += $"{(int)container.type + 1}";
        }

        return url;
    }

    public string WeightUrl()
    {
        string url = "";
        foreach (var container in Containers)
        {
            url += $"-{container.weight}";
        }
        if (url == "")
        {
            return url;
        }
        return url.Substring(1);
    }
}