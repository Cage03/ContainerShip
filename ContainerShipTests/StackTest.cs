using ContainerShip.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContainerShipTests;

[TestClass]
public class StackTest
{
    [TestMethod]
    public void PlaceContainerTest()
    {
        //arrange
        var stack = new Stack();
        var container = new Container(0, Type.Standard);
        //act
        stack.PlaceContainer(container);
        //assert
        Assert.AreEqual(container, stack.Containers[0], "Container not placed correctly");
    }

    [TestMethod]
    public void PlaceWeightedContainer()
    {
        //arrange
        var stack = new Stack();
        var emptyContainer = new Container(0, Type.Standard);
        var weightedContainer = new Container(4001, Type.Standard);
        //act
        stack.PlaceContainer(emptyContainer);
        stack.PlaceContainer(weightedContainer);
        //assert
        Assert.AreEqual(weightedContainer, stack.Containers[^1],"Container not placed in the right spot");
    }

    [TestMethod]
    public void MaxWeightReached()
    {
        //arrange
        var ship = new Ship(1, 1);
        var weight = 29900;

        //act
        for (var i = 0; i < 10; i++)
        {
            ship.Rows[0].Stacks[0].PlaceContainer(new Container(weight, Type.Standard));
            weight++;
        }
        //assert
    }
}