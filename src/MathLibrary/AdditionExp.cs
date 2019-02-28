using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    class AdditionExp : IExpression
    {
        private IExpression addend1;
        private IExpression addend2;

        /// <summary>
        /// Initializing the addend1 and addend2
        /// </summary>
        /// <param name="addend1"></param>
        /// <param name="addend2"></param>
        public AdditionExp(IExpression addend1, IExpression addend2)
        {
            this.addend1 = addend1;
            this.addend2 = addend2;
        }

        /// <summary>
        /// Sum two number inicialized by constructor
        /// </summary>
        /// <returns>Sum of addend1 and addend2</returns>
        public double Evaluate()
        {
            return addend1.Evaluate() + addend2.Evaluate();
        }
    }
}
