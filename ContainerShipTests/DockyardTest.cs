using System;
using System.Collections.Generic;
using System.ComponentModel;
using ContainerShip.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = ContainerShip.Classes.Container;
using Type = System.Type;


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
        Assert.AreEqual(ship, dockyard._dockedShip, "Ship not docked correctly");
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
        foreach (var cooledContainer in dockyard.CooledContainers)
        {
            Assert.IsTrue(cooledContainers.Contains(cooledContainer), "Ship does not contain" + cooledContainer);
        }
    }

    [TestMethod]
    public void PlaceTooManyCooledTest()
    {
        //arrange
        var ship = new Ship(4, 4);
        var dockyard = new Dockyard(9000, 32, 6, 19);
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
        Assert.AreEqual(20, cooledContainers.Count, "Ship contains too many cooledContainers");
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
            Assert.IsTrue(dockyard.ValuableContainers.Contains(valuableContainer),
                $"Ship does not contain({valuableContainer})");
        }
    }

    [TestMethod]
    public void PlaceTooManyValuableTest()
    {
        //arrange
        var ship = new Ship(4, 4);
        var dockyard = new Dockyard(6, 9000, 6, 19);
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
        Assert.AreEqual(8, valuableContainers.Count, "Ship contains too many valuableContainers");
    }

    [TestMethod]
    public void PlaceValuableCooledTest()
    {
        //arrange
        var ship = new Ship(4, 4);
        var dockyard = new Dockyard(6, 4, 6, 19);
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
        foreach (var valuableCooledContainer in valuableCooledContainers)
        {
            Assert.IsTrue(dockyard.ValuableCooledContainers.Contains(valuableCooledContainer),
                "Ship does not contain" + valuableCooledContainer);
        }
    }

    [TestMethod]
    public void PlaceTooManyValuableCooledTest()
    {
        //arrange
        var ship = new Ship(4, 4);
        var dockyard = new Dockyard(6, 4, 9000, 19);
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
        Assert.AreEqual(4, valuableCooledContainers.Count, "Ship contains too many valuableCooledContainers");
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
            Assert.IsTrue(dockyard.StandardContainers.Contains(standardContainer),
                "Ship does not contain" + standardContainer);
        }
    }

    [TestMethod]
    public void PlaceTooManyStandardTest()
    {
        //arrange
        var ship = new Ship(4, 4);
        var dockyard = new Dockyard(6, 32, 6, 9000);
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

        //assert 4x4x150.000 = a max weight of 2.400.000 =>
        //min container weight = 3.000 => 2.400.000/3.000 = 800
        Assert.IsTrue(standardContainers.Count < 801, "Ship contains too many standardContainers");
    }

    [TestMethod]
    public void SkipRowTest()
    {
        //arrange
        var ship = new Ship(7, 4);
        var dockyard = new Dockyard(6, 100, 6, 400);
        dockyard.DockShip(ship);
        //act
        dockyard.PlaceValuableCooled();
        dockyard.PlaceCooled();
        dockyard.PlaceValuable();
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

        //assert 4x4x150.000 = a max weight of 2.400.000 =>
        //min container weight = 3.000 => 2.400.000/3.000 = 800
        Assert.IsFalse(dockyard._dockedShip.Rows[0].Stacks[2].Containers.Count > 0,
            "1. Stack should not container containers");
        Assert.IsFalse(dockyard._dockedShip.Rows[1].Stacks[2].Containers.Count > 0,
            "2. Stack should not container containers");
        Assert.IsFalse(dockyard._dockedShip.Rows[2].Stacks[2].Containers.Count > 0,
            "3. Stack should not container containers");
    }
}