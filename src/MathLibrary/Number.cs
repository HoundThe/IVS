using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Number : IExpression
    {

        private double number;
        public Number(double number)
        {
            this.number = (double) number;
        }
        public double Evaluate()
        {
            return number;
        }
    }
}
