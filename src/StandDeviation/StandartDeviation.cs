using MathLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandDeviation
{
    class Program
    {
        /// <summary>
        /// Function for calculating sum of numbers from list.
        /// </summary>
        /// <param name="list">list of numbers</param>
        /// <param name="power"></param>
        /// <returns></returns>
        static double Sum(List<Number> list, int power)
        {
            double sum = 0;
            foreach (Number i in list)
            {
                sum += Math.Pow(i.Evaluate(), power);
            }
            return sum;
        }


        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            while (true)
            {
                //save line from stdin
                var temp = Console.ReadLine();
                //if are we at end of stdin, break
                if (string.IsNullOrEmpty(temp))
                {
                    break;
                }
                //add line to list
                list.Add(temp);
            }
            //list of numbers
            List<Number> numbers = new List<Number>();
            foreach(var line in list)
            {
                double num;
                if(double.TryParse(line, out num))
                {
                    Number temp = new Number(num);
                    numbers.Add(temp);
                }
            }
            //count of numbers
            int count = numbers.Count;
            //sum of numbers in list
            double sum = Sum(numbers, 1);
            //arithmetic sum
            double arithAverage = sum / count;

            //sum of numbers powered on 2 (numbers from list)
            sum = Sum(numbers, 2);

            //calculating Standart deviation
            double deviation = Math.Sqrt((sum - count * Math.Pow(arithAverage, 2)) / (count -1));

            Console.WriteLine(deviation);
            Console.ReadLine();
        }
    }
}
