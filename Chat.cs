namespace ContainerShip;

public class Chat
{
    public int AskLength()
    {
        while (true)
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.Write("Ship length: ");
            var response = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------------");

            int result;
            if (int.TryParse(response, out result) && BiggerThanZero(result))
            {
                return result;
            }

            Console.WriteLine("Length must be a positive number :-(");
            Console.WriteLine("-------------------------------------------------------");
        }
    }

    public int AskWidth()
    {
        while (true)
        {
            Console.Write("Ship width:");
            var response = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------------");

            int result;
            if (int.TryParse(response, out result) && BiggerThanZero(result))
            {
                return result;
            }

            Console.WriteLine("Width must be a positive number :-(");
            Console.WriteLine("-------------------------------------------------------");
        }
    }

    public int AskCooledContainer()
    {
        while (true)
        {
            Console.Write("Cooled container amount:");
            var response = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------------");

            int result;
            if (int.TryParse(response, out result) && NotNegative(result))
            {
                return result;
            }

            Console.WriteLine("Cooled container amount must be a positive number :-(");
            Console.WriteLine("-------------------------------------------------------");
        }
    }

    public int AskValuableContainer()
    {
        while (true)
        {
            Console.Write("Valuable container amount:");
            var response = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------------");

            int result;
            if (int.TryParse(response, out result) && NotNegative(result))
            {
                return result;
            }

            Console.WriteLine("Valuable container amount must be a positive number :-(");
            Console.WriteLine("-------------------------------------------------------");
        }
    }

    public int AskCooledValuableContainer()
    {
        while (true)
        {
            Console.Write("Cooled valuable container amount:");
            var response = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------------");

            int result;
            if (int.TryParse(response, out result))
            {
                return result;
            }

            if (NotNegative(result))
            {
                return result;
            }

            Console.WriteLine("Cooled valuable container amount must be a positive number :-(");
            Console.WriteLine("-------------------------------------------------------");
        }
    }

    public int AskNormalContainer()
    {
        while (true)
        {
            Console.Write("Normal container amount:");
            var response = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------------");

            int result;
            if (int.TryParse(response, out result) && NotNegative(result))
            {
                return result;
            }

            Console.WriteLine("Normal Container amount must be a positive number :-(");
            Console.WriteLine("-------------------------------------------------------");
        }
    }

    public bool BiggerThanZero(int input)
    {
        return input > 0;
    }

    public bool NotNegative(int input)
    {
        return input >= 0;
    }
}