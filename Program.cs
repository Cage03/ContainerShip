using System.Runtime.CompilerServices;
using ContainerShip;
using ContainerShip.Classes;

public class Program
{
    public static void Main(string[] args)
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
    }
}