namespace Map
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool programOn = true;
            string userInput;

            Map map = new Map();
            while (programOn)
            {
                Console.Clear();
                map.CreateMap();
                map.PrintMap();
                Console.WriteLine("Enter = new Map \t|\t0 = Exit");
                userInput = Console.ReadLine();
                if (userInput == "0")
                {
                    programOn = false;
                }
            }
        }
    }
    class Map
    {
        int mapFactor = 40;
        int borderRadius = 2;
        int[,] coordinates = new int[80, 80];
        Random rand = new Random();

        public void CreateMap()
        {
            for (int i = 0; i < mapFactor; i++)
            {
                for (int j = 0; j < mapFactor; j++)
                {
                    coordinates[i, j] = rand.Next(2);
                }
            }
            ShapeLand();
        }

        public void PrintMap()
        {
            for (int i = 0; i <= mapFactor; i++)
            {
                for (int j = 0; j <= mapFactor; j++)
                {
                    if (j == 0 || j == mapFactor)
                    {
                        Console.Write("|");
                    }
                    else if (i == 0)
                    {
                        Console.Write("'");
                    }
                    else if (i == mapFactor)
                    {
                        Console.Write(".");
                    }
                    else if (coordinates[i, j] == 1)
                    {
                        Console.Write("X");
                    }
                    else
                    {

                        Console.Write(" ");
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        private void ShapeLand()
        {
            bool formTop = false;
            bool formLeft = false;
            bool formRight = false;
            bool formBottom = false;
            bool insideBorders = false;

            for (int i = 0; i <= mapFactor; i++)
            {
                for (int j = 0; j <= mapFactor; j++)
                {
                    if (i < mapFactor - borderRadius && j < mapFactor - borderRadius &&
                        i > borderRadius && j > borderRadius)
                    {
                        insideBorders = true;
                    }
                    if (insideBorders &&
                        coordinates[i - 1, j + 1] == 1 &&
                        coordinates[i - 1, j] == 1 &&
                        coordinates[i - 1, j - 1] == 1)
                    {
                        formTop = true;
                    }
                    if (insideBorders &&
                       coordinates[i - 1, j - 1] == 1 &&
                       coordinates[i, j - 1] == 1 &&
                       coordinates[i + 1, j - 1] == 1)
                    {
                        formLeft = true;
                    }
                    if (insideBorders &&
                        coordinates[i - 1, j + 1] == 1 &&
                        coordinates[i, j + 1] == 1 &&
                        coordinates[i + 1, j + 1] == 1)
                    {
                        formRight = true;
                    }
                    if (insideBorders &&
                        coordinates[i + 1, j + 1] == 1 &&
                        coordinates[i + 1, j] == 1 &&
                        coordinates[i + 1, j - 1] == 1)
                    {
                        formBottom = true;
                    }
                    if (insideBorders &&
                        (formBottom || formRight || formLeft || formTop))
                    {
                        coordinates[i, j] = 1;
                    }
                    else
                    {
                        coordinates[i, j] = 0;
                    }                    

                    formTop = false;
                    formLeft = false;
                    formRight = false;
                    formBottom = false;
                    insideBorders = false;
                }
            }
        }
    }
}