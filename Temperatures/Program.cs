using System;
using static System.Console;

namespace Temperatures
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] weekOne = { 87, 98, 78, 88, 79, 89, 92 };
            ArrayOfTemperatures tempTest = new ArrayOfTemperatures(weekOne);

            WriteLine("Average Temp: {0}", tempTest.ReturnAverage().ToString("F2"));
            WriteLine("Lowest Temp: {0}", tempTest.ReturnSmallest().ToString("F0"));
            WriteLine("Highest Temp: {0}", tempTest.ReturnLargest().ToString("F0"));
            WriteLine("Average Temp excluding Lowest: {0}", tempTest.ReturnAverageExcludingSmallest().ToString("F2"));
            WriteLine("Number of Days below {0}: {1}", 80, tempTest.ReturnDaysBelow(80));
            WriteLine("Press any key to see the final test...");

            WriteLine(tempTest);
            ReadLine();

        }


        class ArrayOfTemperatures
        {
            private int[] temperature;

            public ArrayOfTemperatures()
            {

            }

            public int[] Temp
            {
                get { return temperature; }
                set { temperature = value; }
            }

            public ArrayOfTemperatures(int[] temp)
            {
                temperature = new int[temp.Length];
                temperature = temp;
            }

            public int ReturnSum()
            {
                int sum = temperature[0];
                for (int i = 1; i < temperature.Length; i++)
                {
                    sum += temperature[i];
                }
                return sum;
            }

            public double ReturnAverage()
            {
                double average = Convert.ToDouble(ReturnSum()) / Convert.ToDouble(temperature.Length);
                return average;
            }

            public int ReturnSmallest()
            {
                int min = temperature[0];
                for (int i = 0; i < temperature.Length; i++)
                {
                    if (temperature[i] < min)
                    {
                        min = temperature[i];
                    }

                }
                return min;
            }
            
            public int ReturnLargest()
            {
                int max = temperature[0];
                for (int i = 0; i < temperature.Length; i++)
                {
                    if (temperature[i] > max)
                    {
                        max = temperature[i];
                    }

                }
                return max;
            }

            public double ReturnAverageExcludingSmallest()
            {
                double excAvgTemp = Convert.ToDouble(ReturnSum()) - Convert.ToDouble(ReturnSmallest());
                excAvgTemp = excAvgTemp / Convert.ToDouble(temperature.Length - 1);
                return excAvgTemp;
            }

            public int ReturnDaysBelow(int temp)
            {
                int numOfDays = 0;
                foreach (int t in temperature)
                {
                    if (t < temp)
                    {
                        numOfDays++;
                    }
                }
                return numOfDays;
            }

            public override string ToString()
            {
                string tempRes = "Values in the Temperature Array\n\n";
                for (int i = 0; i < temperature.Length; i++)
                {
                    if (i == 2 || i == 5)
                    {
                        tempRes += temperature[i] + "\t\n";
                    }
                    else
                    {
                        tempRes += temperature[i] + "\t";
                    }



                } 
                return tempRes + "\nTemperatures ranged from " + ReturnSmallest() + " to " + ReturnLargest();
            }
        }
    }
}

