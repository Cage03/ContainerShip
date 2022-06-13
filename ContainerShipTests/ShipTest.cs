using System;
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
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LengthBelowOne()
    {
        //arrange
        //act
        var ship = new Ship(-1, 10);
        //assert
        Assert.Fail("Program should not continue");
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void WidthBelowOne()
    {
        //arrange
        //act
        var ship = new Ship(10, -1);
        //assert
        Assert.Fail("Program should not continue");
    }

    [TestMethod]
    public void MaxWeightTest()
    {
        //arrange
        var dockyard = new Dockyard(1,1,1,1);
        var ship = new Ship(4, 4);
        //act
        dockyard.DockShip(ship);
        //assert
        Assert.AreEqual(2400000, dockyard._dockedShip.MaxWeight, "Ship maxWeight not set correctly");
    }
}