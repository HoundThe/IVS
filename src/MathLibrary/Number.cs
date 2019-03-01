using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Number : IExpression
    {
        private double value;

        public Number(double value)
        {
            this.value = value;
        }

        public double Evaluate()
        {
            return value;
        }
    }
}
