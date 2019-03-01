using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class CosineExp : IExpression
    {
        private IExpression result;
        private IExpression value;

        /// <summary>
        /// Iniciali
        /// </summary>
        /// <param name="value"></param>
        public CosineExp(IExpression value)
        {
            this.value = value;
        }

        /// <summary>
        /// Calculate cosine of inputed value in radians
        /// </summary>
        /// <returns>Cosine of value</returns>
        public double Evaluate()
        {
            throw new NotImplementedException();// Todo
        }
    }
}
