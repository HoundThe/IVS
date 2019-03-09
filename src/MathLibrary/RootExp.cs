using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class RootExp : IExpression
    {
        private IExpression mantis;
        private IExpression root;

        public RootExp(IExpression mantis, IExpression root)
        {
            this.mantis = mantis;
            this.root = root;
        }

        public double Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
