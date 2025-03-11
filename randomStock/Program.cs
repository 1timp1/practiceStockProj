﻿namespace randomstock
{
    class Program
    {
        static void Main(string[] args)
        {


            int size = 10;
            int startPrice = 100;
            int step;
            double[] prices = new double[size];
            int current = 1;
            prices[0] = startPrice;
            while (current < size)
            {
                prices[current] = genPrice(prices[current - 1]);
                current += 1;
            }
            for (int i = 0; i < size; i++)
            {
                if (i == size - 1)
                {
                    Console.WriteLine(prices[i]);
                }
                else
                {
                    Console.Write(prices[i] + ", ");
                }
            }
            drawChart(size, startPrice, prices);

            Console.ReadLine();
        }

        static void drawChart(int size, int startPrice, double[] prices)
        {
            //SCALE  : each height = 2
            int[] plots = new int[prices.Length];

            for (int i = 0; i < prices.Length; i++)
            {
                plots[i] = getHeightCell(prices[i], size);
            }


            for (int i = 0; i < size + 1; i++)
            {
                for (int j = 0; j < size + 1; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("|");
                    }
                    else if(j == size)
                    {
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        bool printIT = CheckCell(i, j, plots);
                        if (printIT == true)
                        {
                            Console.Write("t ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                }
                if (i == size)
                {
                    Console.WriteLine("--------------------");
                }
            }
        }

        public static double genPrice(double start)
        {

            int rand;
            double newNum;
            Random RNG = new Random();
            rand = RNG.Next(1,11);
            if (rand <= 5)
            {
                newNum = -1 * 0.01 * rand;
            }
            else
            {
                newNum = 0.01 * (rand - 5);
            }

            return (newNum * start) + start;

        }

        public static int getHeightCell(double number, int max)
        {
            if(number > 110 || number < 90)
            {
                return max;
            }
            else
            {
                int x = Convert.ToInt32(number - 100);
                int y = x / 2;
                int z = y + 5;
                return 10 - z;
            }
        }

        public static bool CheckCell(int y, int x, int[] plots)
        {
            if (plots[x] == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

