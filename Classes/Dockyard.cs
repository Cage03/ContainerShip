using System.Reflection.Metadata.Ecma335;

namespace ContainerShip.Classes;

public class Dockyard
{
    private List<Container> CooledContainers = new();
    private List<Container> ValuableContainers = new();
    private List<Container> ValuableCooledContainers = new();
    private List<Container> StandardContainers = new();

    private Ship _dockedShip;

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
    }

    public void DockShip(Ship ship)
    {
        _dockedShip = ship;
    }

    public void PlaceCooled()
    {
        var j = 0;
        foreach (var container in CooledContainers)
        {
            if (j == _dockedShip.Rows.Count)
            {
                j = 0;
            }

            _dockedShip.Rows[j].Stacks[0].PlaceContainer(container);
            j++;
        }
    }

    public void PlaceValuable()
    {
        for (var i = 0; i < ValuableContainers.Count; i++)
        {
            var widthIndex = i;
            var lengthIndex = 0;

            for (; widthIndex >= _dockedShip.Rows.Count;)
            {
                widthIndex -= _dockedShip.Rows.Count;
                lengthIndex++;
            }

            if (lengthIndex > 1)
            {
                lengthIndex += Convert.ToInt32(Math.Floor((decimal) (lengthIndex / 2)));
            }

            if (lengthIndex == _dockedShip.Rows[0].Stacks.Count)
            {
                break;
            }

            if ((widthIndex + 1) % 2 == 0)
            {
                widthIndex = _dockedShip.Rows.Count - (widthIndex + 1) / 2;
            }
            else
            {
                widthIndex /= 2;
            }

            _dockedShip.Rows[widthIndex].Stacks[lengthIndex]
                .PlaceContainer(ValuableContainers[i]); //todo fix out of range when lengthIndex > stack count
        }
    }

    public void PlaceValuableCooled()
    {
        for (var i = 0; i < ValuableCooledContainers.Count; i++)
        {
            if (i < _dockedShip.Rows.Count)
            {
                _dockedShip.Rows[i].Stacks[0].PlaceContainer(ValuableCooledContainers[i]);
            }
        } //todo Maybe send back how many containers weren't placed?
    }

    public void PlaceStandard()
    {
        for (var i = 0; i < StandardContainers.Count; i++)
        {  
            //elke rij afgaan stack [0] plaatsen, dan [1], etc.
            //repeat tot containers op zijn of alle stacks vol zijn.
            var width = 0;
            var length = 0;
            var height = 0;

            for (; length < _dockedShip.Rows[0].Stacks.Count; length++)
            {
                for (; width < _dockedShip.Rows.Count; width++)
                {
                    
                }
            }
        }
    }
}