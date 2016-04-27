using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_of_life_2
{
    class Program
    {
        public static int getAdjacent(int x, int y, int height, int width, bool[,] field)
        {

            int adjacentTiles = 0;

            if(x != 0 && y != 0)
            {
                if (field[x - 1, y - 1])
                {
                    adjacentTiles++;
                }
            }

            if(y != 0)
            {
                if (field[x, y - 1])
                {
                    adjacentTiles++;
                }
            }

            if(x != width && y != 0)
            {
                if (field[x + 1, y - 1])
                {
                    adjacentTiles++;
                }
            }

            if(x != 0)
            {
                if (field[x - 1, y])
                {
                    adjacentTiles++;
                }
            }

            if(x != width)
            {
                if (field[x + 1, y])
                {
                    adjacentTiles++;
                }
            }

            if(x != 0 && y != height)
            {
                if (field[x - 1, y + 1])
                {
                    adjacentTiles++;
                }
            }

            if(y != height)
            {
                if (field[x, y + 1])
                {
                    adjacentTiles++;
                }
            }

            if(x != width && y != height)
            {
                if (field[x + 1, y + 1])
                {
                    adjacentTiles++;
                }
            }

            return adjacentTiles;

        }

        public static int[] position (int x, int y)
        {

            return new int []{ x, y };

        }

        static void Main(string[] args)
        {

            Console.SetWindowSize(100, 35);

            //Console.WriteLine("Enter width:");
            int x = 17; //int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter height:");
            int y = 17; //int.Parse(Console.ReadLine());

            Console.Clear();

            bool[,] playingZone = new bool[x, y];
            List<int[]> birth = new List<int[]>();
            List<int[]> kill = new List<int[]>();

            playingZone[4, 4] = true;
            playingZone[5, 4] = true;
            playingZone[6, 5] = true;
            playingZone[6, 3] = true;
            playingZone[7, 4] = true;
            playingZone[8, 4] = true;
            playingZone[9, 4] = true;
            playingZone[10, 4] = true;
            playingZone[11, 5] = true;
            playingZone[11, 3] = true;
            playingZone[12, 4] = true;
            playingZone[13, 4] = true;

            int adjacentTiles = 0;
            string printString = "";

            do
            {

                for (int j = 0; j < y; j++)
                {

                    for (int i = 0; i < x; i++)
                    {

                        if (playingZone[i, j])
                        {

                            printString += "o ";

                        }
                        else
                        {

                            printString += "  ";

                        }

                    }

                    printString += "\n";

                }

                //printString += "\n\nPress return to see the next generation.";
                Console.WriteLine(printString);

                //Console.ReadLine();
                System.Threading.Thread.Sleep(250);

                printString = ("");

                for (int j = 0; j < y; j++)
                {

                    for (int i = 0; i < y; i++)
                    {

                        adjacentTiles = getAdjacent(i, j, y - 1, x - 1, playingZone);

                        if (playingZone[i, j])
                        {

                            if (adjacentTiles < 2)
                            {

                                kill.Add(new int[] { i, j });

                            }

                            else if (adjacentTiles > 3)
                            {

                                kill.Add(new int[] { i, j });

                            }

                        }

                        else
                        {

                            if (adjacentTiles == 3)
                            {

                                birth.Add(new int[] { i, j });

                            }

                        }

                    }
                }

                for(int i = 0; i < kill.Count; i++)
                {

                    playingZone[kill[i][0], kill[i][1]] = false;

                }

                for (int i = 0; i < birth.Count; i++)
                {

                    playingZone[birth[i][0], birth[i][1]] = true;

                }

                birth.Clear();
                kill.Clear();

                Console.Clear();
            }
            while (true);
        }
    }
}