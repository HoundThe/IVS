using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class SineExp : IExpression
    {
        private IExpression value;

        public SineExp(IExpression value)
        {
            this.value = value;
        }

        public double Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
