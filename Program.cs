using System.Runtime.CompilerServices;
using ContainerShip;
using ContainerShip.Classes;
using Type = ContainerShip.Classes.Type;

public class Program
{
    public static void Main(string[] args)
    {
        UserInterface();
    }

    private static void UserInterface()
    {
        var chat = new Chat();

        Ship ship = new(chat.AskLength(), chat.AskWidth());
        Dockyard dockyard = new(
            chat.AskCooledContainer(),
            chat.AskValuableContainer(),
            chat.AskCooledValuableContainer(),
            chat.AskNormalContainer());

        dockyard.DockShip(ship);
        dockyard.PlaceValuableCooled();
        dockyard.PlaceValuable();
        dockyard.PlaceCooled();
        dockyard.PlaceStandard();
        dockyard.ReverseLists();

        if (dockyard._dockedShip.MaxWeight >
            dockyard._dockedShip.Rows.Count * dockyard._dockedShip.Rows[0].Stacks.Count * 150000 / 2)
        {
            Console.WriteLine("50% of ships weight has to be used");
            UserInterface();
        }

        Console.WriteLine("Visualisation string:");
        Console.WriteLine("\n" + Visualisation(ship.Rows, ship.Rows.Count, ship.Rows[0].Stacks.Count));
    }

    public static string Visualisation(List<Row> rows, int width, int length)
    {
        string url = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length={length}&width={width}";
        string urlStacks = "";
        string urlWeight = "";
        foreach (var row in rows)
        {
            string stackUrlStacks = "";
            string stackUrlWeight = "";
            foreach (var stack in row.Stacks)
            {
                stackUrlStacks += StackBuilder(stack);
                stackUrlWeight += WeightBuilder(stack);
            }

            if (stackUrlStacks.Length > 0)
            {
                stackUrlStacks = stackUrlStacks.Remove(stackUrlStacks.Length - 1, 1);
            }

            if (stackUrlWeight.Length > 0)
            {
                stackUrlWeight = stackUrlWeight.Remove(stackUrlWeight.Length - 1, 1);
            }

            urlStacks += stackUrlStacks + "/";
            urlWeight += stackUrlWeight + "/";
        }

        urlStacks = urlStacks.Remove(urlStacks.Length - 1, 1);
        urlWeight = urlWeight.Remove(urlWeight.Length - 1, 1);
        return $"{url}&stacks={urlStacks}&weights={urlWeight}";
    }

    public static string CheckUrl(string url, string seperate)
    {
        if (url == ",")
        {
            return $"{seperate}{seperate}";
        }

        return url;
    }

    public static string StackBuilder(Stack stack)
    {
        string returnString = "";
        foreach (var container in stack.Containers)
        {
            returnString += (int) container.type + 1;
        }

        return returnString + ",";
    }

    public static string WeightBuilder(Stack stack)
    {
        string returnString = "";
        foreach (var container in stack.Containers)
        {
            returnString += container.weight / 1000 + "-";
        }

        if (returnString.Length == 0)
        {
            return ",";
        }

        returnString = returnString.Remove(returnString.Length - 1, 1);
        return returnString + ",";
    }
}