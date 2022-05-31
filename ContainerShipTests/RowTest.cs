using ContainerShip.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContainerShipTests;

[TestClass]
public class RowTest
{
    [TestMethod]
    public void CreateRow()
    {
        //arrange
        var length = 20;
        //act
        var row = new Row(length);
        //assert
        Assert.AreEqual(length, row.Stacks.Count);
    }
}