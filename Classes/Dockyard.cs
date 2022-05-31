using System.Reflection.Metadata.Ecma335;

namespace ContainerShip.Classes;

public class Dockyard
{
    public List<Container> CooledContainers = new();
    public List<Container> ValuableContainers = new();
    public List<Container> ValuableCooledContainers = new();
    public List<Container> StandardContainers = new();

    public Ship _dockedShip;

    public Dockyard(int cooled, int valuable, int valuableCooled, int normal)
    {
        for (var i = 0; i < cooled; i++)
        {
            CooledContainers.Add(new Container(Type.Cooled));
        }

        for (var i = 0; i < valuable; i++)
        {
            ValuableContainers.Add(new Container(Type.Valuable));
        }

        for (var i = 0; i < valuableCooled; i++)
        {
            ValuableCooledContainers.Add(new Container(Type.CooledValuable));
        }

        for (var i = 0; i < normal; i++)
        {
            StandardContainers.Add(new Container(Type.Standard));
        }

        OrderLists();
    }

    public void DockShip(Ship ship)
    {
        _dockedShip = ship;
        _dockedShip.MaxWeight = _dockedShip.Rows.Count * _dockedShip.Rows[0].Stacks.Count * 150000;
    }

    public void PlaceCooled()
    {
        for (var i = 0; i < CooledContainers.Count; i++)
        {
            var widthIndex = i;
            if (_dockedShip.MaxWeight - CooledContainers[i].weight <= 0) return;

            //whenever widthIndex reaches the amount of rows, widthIndex = 0 to restart the cycle
            for (;widthIndex >= _dockedShip.Rows.Count;)
            {
                widthIndex -= _dockedShip.Rows.Count;
            }

            //if number is uneven container is placed on the right side
            if ((widthIndex + 1) % 2 == 0)
            {
                widthIndex = _dockedShip.Rows.Count - (widthIndex + 1) / 2;
            }
            //if number is even container is placed on the left side
            else
            {
                widthIndex /= 2;
            }

            _dockedShip.Rows[widthIndex].Stacks[0].PlaceContainer(CooledContainers[i]);
            _dockedShip.MaxWeight -= CooledContainers[i].weight;
        }
    }


    public void PlaceValuable()
    {
        for (var i = 0; i < ValuableContainers.Count; i++)
        {
            var widthIndex = i;
            var lengthIndex = 1;
            //check weight
            if (_dockedShip.MaxWeight - ValuableContainers[i].weight <= 0) return;
            //if widthIndex exceeds total amount of rows, widthIndex becomes 0 and lengthIndex increases
            for (; widthIndex >= _dockedShip.Rows.Count;)
            {
                widthIndex -= _dockedShip.Rows.Count;
                lengthIndex++;
            }

            //makes sure there's a gap between containers after two are placed 0,1 - 3,4 - 6,7 etc.
            if (lengthIndex > 1)
            {
                lengthIndex += Convert.ToInt32(Math.Floor((decimal) (lengthIndex / 2)));
            }

            //when there are no spots left to fill, stop.
            if (lengthIndex >= _dockedShip.Rows[0].Stacks.Count)
            {
                break;
            }

            //if number is uneven container is placed on the right side
            if ((widthIndex + 1) % 2 == 0)
            {
                widthIndex = _dockedShip.Rows.Count - (widthIndex + 1) / 2;
            }
            //if number is even container is placed on the left side
            else
            {
                widthIndex /= 2;
            }

            _dockedShip.Rows[widthIndex].Stacks[lengthIndex]
                .PlaceContainer(ValuableContainers[i]);
            _dockedShip.MaxWeight -= ValuableContainers[1].weight;
        }
    }

    public void PlaceValuableCooled()
    {
        for (var i = 0; i < ValuableCooledContainers.Count; i++)
        {
            if (_dockedShip.MaxWeight - ValuableCooledContainers[i].weight <= 0) return;
            if (i < _dockedShip.Rows.Count)
            {
                _dockedShip.Rows[i].Stacks[0].PlaceContainer(ValuableCooledContainers[i]);
                _dockedShip.MaxWeight -= ValuableCooledContainers[i].weight;
            }
        }
    }

    public void PlaceStandard()
    {
        var x = 0;
        var lengthIndex = 0;
        foreach (var standardContainer in StandardContainers)
        {
            var widthIndex = 0;
            if (_dockedShip.MaxWeight - standardContainer.weight <= 0) return;

            if (x >= _dockedShip.Rows.Count)
            {
                x = 0;
                lengthIndex++;
            }

            if (lengthIndex >= _dockedShip.Rows[0].Stacks.Count)
            {
                lengthIndex = 0;
            }

            //if number is uneven container is placed on the right side
            if ((x + 1) % 2 == 0)
            {
                widthIndex = _dockedShip.Rows.Count - (x + 1) / 2;
            }

            //if number is even container is placed on the left side
            else
            {
                widthIndex = x / 2;
            }

            if (lengthIndex < 2)
            {
                _dockedShip.Rows[widthIndex].Stacks[lengthIndex].PlaceContainer(standardContainer);
                _dockedShip.MaxWeight -= standardContainer.weight;
                x++;
                continue;
            }

            if (!IsValuable(widthIndex, lengthIndex - 2)
                || !IsValuable(widthIndex, lengthIndex - 1))
            {
                _dockedShip.Rows[widthIndex].Stacks[lengthIndex].PlaceContainer(standardContainer);
                _dockedShip.MaxWeight -= standardContainer.weight;
            }

            x++;
        }
    }

    public void OrderLists()
    {
        CooledContainers = CooledContainers.OrderBy(x => -x.weight).ToList();
        ValuableContainers = ValuableContainers.OrderBy(x => -x.weight).ToList();
        ValuableCooledContainers = ValuableCooledContainers.OrderBy(x => -x.weight).ToList();
        StandardContainers = StandardContainers.OrderBy(x => x.weight).ToList();
    }

    //checks if a certain stack contains a valuable type container
    public bool IsValuable(int widthIndex, int lengthIndex)
    {
        if (lengthIndex <= _dockedShip.Rows.Count)
        {
            return false;
        }

        foreach (var container in _dockedShip.Rows[widthIndex].Stacks[lengthIndex].Containers)
        {
            if (container.type == Type.Valuable || container.type == Type.CooledValuable)
            {
                return true;
            }
        }

        return false;
    }
}