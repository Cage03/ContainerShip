using System;
using System.ComponentModel;
using ContainerShip.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = ContainerShip.Classes.Container;
using Type = ContainerShip.Classes.Type;

namespace ContainerShipTests;

[TestClass]
public class ContainerTest
{
    [TestMethod]
    public void CreateStandardContainer()
    {
        //arrange
        var type = Type.Standard;
        //act
        var container = new Container(type);
        //assert
        Assert.IsTrue(container.weight > 0);
        Assert.AreEqual(Type.Standard, container.type);
    }
    [TestMethod]
    public void CreateValuableContainer()
    {
        //arrange
        var type = Type.Valuable;
        //act
        var container = new Container(type);
        //assert
        Assert.IsTrue(container.weight > 0);
        Assert.AreEqual(Type.Valuable, container.type);
    }
    [TestMethod]
    public void CreateCooledValuableContainer()
    {
        //arrange
        var type = Type.CooledValuable;
        //act
        var container = new Container(type);
        //assert
        Assert.IsTrue(container.weight > 0);
        Assert.AreEqual(Type.CooledValuable, container.type);
    }
    [TestMethod]
    public void CreateCooledContainer()
    {
        //arrange
        var type = Type.Cooled;
        //act
        var container = new Container(type);
        //assert
        Assert.IsTrue(container.weight > 0);
        Assert.AreEqual(Type.Cooled, container.type);
    }
    [TestMethod]
    public void CreateEmptyContainer()
    {
        //arrange
        var type = Type.Cooled;
        //act
        var container = new Container(0, type);
        //assert
        Assert.AreEqual(0, container.weight);
        Assert.AreEqual(Type.Cooled, container.type);
    }
}