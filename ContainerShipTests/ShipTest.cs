using ContainerShip.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContainerShipTests;

[TestClass]
public class ShipTest
{
    [TestMethod]
    public void CreateShip()
    {
        //arrange
        var length = 25;
        var width = 35;
        //act
        var ship = new Ship(length, width);
        //assert
        Assert.AreEqual(width, ship.Rows.Count);
        Assert.AreEqual(length, ship.Rows[0].Stacks.Count);
    }
}