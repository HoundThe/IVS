/************************************************************
 *      ROZSIVAL MICHAL                                     *
 *      IVS - project 2                                     *
 *      FEB/MAR 2019                                        *
 *      Class of the MathLibary                             *
 *      Version 1.0                                         *
 ************************************************************/

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
        private double result = 0;
        private int naturalRoot;
        private readonly int iteration = 1000;

        /// <summary>
        /// Contructor inicializing arguments
        /// </summary>
        /// <param name="mantis"></param>
        /// <param name="root"></param>
        public RootExp(IExpression mantis, IExpression root)
        {
            this.mantis = mantis;
            this.root = root;
        }

        /// <summary>
        /// Method chceking if root is natural number
        /// </summary>
        /// <returns></returns>
        private bool Natural()
        {
            if (root.Evaluate() < 0.0)
            {
                return false;
            }
            if (root.Evaluate() - (int)root.Evaluate() != 0)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Method checking if root is even number
        /// </summary>
        /// <returns>true if natural root is even number</returns>
        private bool EvenRoot()
        {
            if (root.Evaluate() / 2.0 - naturalRoot/2  == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Comptuting nth root of number using formula: n root of x ~ x ^ (1/n) ~ e^((1/n)*ln(x))
        /// </summary>
        private void Root()
        {
            double z; //auxiliary value for continued fraction computing 
            bool negativeInput = (mantis.Evaluate() < 0 ? true : false); //keeping the sign for the negative input and odd rooth
            //---Computing ln(x)
            double lnX = 0;
            double absMantis = (mantis.Evaluate() >= 0 ? mantis.Evaluate() : -mantis.Evaluate());
            z = (absMantis - 1) / (absMantis + 1);
            for (int i = iteration; i > 0; i--)
            {
                lnX = (i * i * z * z) / (2.0 * i + 1.0 - lnX);
            }
            lnX = 2 * z / (1 - lnX);
            //---Computing e^(alfa), where alfa = (1/n)*ln(x)
            z = (1.0 / naturalRoot) * lnX;
            for(int i = iteration; i > 0; i--)
            {
                result = (i * z) / ((i + 1.0 + z - result));
            }
            result = 1.0 / (1.0 - z / (1.0 + z - result));
            result = (negativeInput && !EvenRoot()) ? -result: result;
        }

        /// <summary>
        /// Calculating root of mantis
        /// </summary>
        /// <returns>root of mantis or throw error if root is not natural number or even root of negative value</returns>
        public double Evaluate()
        {
            if(!Natural()) //if root is not natural number
            {
                throw new ArgumentException("Can only calculate natural root of number!");
            }
            naturalRoot = (int)root.Evaluate();
            if(naturalRoot == 0) //if root is zero
            {
                throw new ArgumentException("Root cannot be zero!");
            }
            if (EvenRoot() && mantis.Evaluate() < 0)
            {
                throw new ArgumentException("Cant compute even root of negative value!");
            }
            if (mantis.Evaluate() == 0.0) //nth root of zero is zero
            {
                result = 0;
            }
            else if(naturalRoot == 1) //first root of any number is same number
            {
                result = mantis.Evaluate();
            }
            else
            {
                Root();
            }
            return result;
        }
    }
}
