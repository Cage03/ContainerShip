using System.Collections.Generic;
using System.ComponentModel;
using ContainerShip.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = ContainerShip.Classes.Container;


namespace ContainerShipTests;

[TestClass]
public class DockyardTest
{
    [TestMethod]
    public void CreateDockyard()
    {
        //arrange
        var cooled = 20;
        var valuable = 32;
        var cooledValuable = 7;
        var standard = 46;
        //act
        var dockyard = new Dockyard(cooled, valuable, cooledValuable, standard);
        //assert
        Assert.AreEqual(20, dockyard.CooledContainers.Count);
        Assert.AreEqual(32, dockyard.ValuableContainers.Count);
        Assert.AreEqual(7, dockyard.ValuableCooledContainers.Count);
        Assert.AreEqual(46, dockyard.StandardContainers.Count);
    }

    [TestMethod]
    public void DockShip()
    {
        //arrange
        var ship = new Ship(1, 1);
        var dockyard = new Dockyard(1, 1, 1, 1);
        //act
        dockyard.DockShip(ship);
        //assert
        Assert.AreEqual(ship, dockyard._dockedShip);
    }

    [TestMethod]
    public void PlaceCooledTest()
    {
        //arrange
        var ship = new Ship(4, 4);
        var dockyard = new Dockyard(6, 32, 6, 19);
        dockyard.DockShip(ship);
        //act
        dockyard.PlaceCooled();
        List<Container> cooledContainers = new();

        foreach (var row in ship.Rows)
        {
            foreach (var container in row.Stacks[0].Containers)
            {
                cooledContainers.Add(container);
            }
        }

        //assert
        Assert.AreEqual(6, cooledContainers.Count);

        foreach (var cooledContainer in dockyard.CooledContainers)
        {
            Assert.IsTrue(cooledContainers.Contains(cooledContainer));
        }
    }

    [TestMethod]
    public void PlaceValuableTest()
    {
        //arrange
        var ship = new Ship(4, 4);
        var dockyard = new Dockyard(6, 32, 6, 19);
        dockyard.DockShip(ship);
        //act
        dockyard.PlaceValuable();
        List<Container> valuableContainers = new();

        foreach (var row in ship.Rows)
        {
            foreach (var stack in row.Stacks)
            {
                foreach (var container in stack.Containers)
                {
                    valuableContainers.Add(container);
                }
            }
        }
        //assert

        foreach (var valuableContainer in valuableContainers)
        {
            Assert.IsTrue(dockyard.ValuableContainers.Contains(valuableContainer));
        }
    }

    [TestMethod]
    public void PlaceValuableCooledTest()
    {
        //arrange
        var ship = new Ship(4, 4);
        var dockyard = new Dockyard(6, 32, 6, 19);
        dockyard.DockShip(ship);
        //act
        dockyard.PlaceValuableCooled();
        List<Container> valuableCooledContainers = new();

        foreach (var row in ship.Rows)
        {
            foreach (var stack in row.Stacks)
            {
                foreach (var container in stack.Containers)
                {
                    valuableCooledContainers.Add(container);
                }
            }
        }

        //assert
        Assert.AreEqual(4, valuableCooledContainers.Count);
        foreach (var valuableCooledContainer in valuableCooledContainers)
        {
            Assert.IsTrue(dockyard.ValuableCooledContainers.Contains(valuableCooledContainer));
        }
    }

    [TestMethod]
    public void PlaceStandardTest()
    {
        //arrange
        var ship = new Ship(4, 4);
        var dockyard = new Dockyard(6, 32, 6, 19);
        dockyard.DockShip(ship);
        //act
        dockyard.PlaceStandard();
        List<Container> standardContainers = new();

        foreach (var row in ship.Rows)
        {
            foreach (var stack in row.Stacks)
            {
                foreach (var container in stack.Containers)
                {
                    standardContainers.Add(container);
                }
            }
        }

        //assert
        Assert.AreEqual(19, standardContainers.Count);
        foreach (var standardContainer in standardContainers)
        {
            Assert.IsTrue((dockyard.StandardContainers.Contains(standardContainer)));
        }
    }
}