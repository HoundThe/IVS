using System;
using System.Collections.Generic;
using MathLibrary;
using System.Linq;
namespace GUICalculator.Model
{
    // Parses the expressions into one line form for better processing later
    class InputParser
    {
        private static readonly string[] oneParamOperators = { "sin", "cos", "tg", "!", "sqrt" };
        public InputParser() { }

        public double EvaluatePostfixExp(string postfixExpression)
        {
            Stack<double> operandStack = new Stack<double>();
            double number = 0;
            bool isNumber = false;

            foreach (string element in postfixExpression.Split(' '))
            {
                isNumber = Double.TryParse(element, out number);
                if (element == "π")
                {
                    isNumber = true;
                    number = Constants.Pi;
                }
                else if (element == "e")
                {
                    isNumber = true;
                    number = Constants.E; // TODO from math lib
                }
                if (isNumber == true)
                {
                    operandStack.Push(number);
                }
                else
                {
                    if (oneParamOperators.Contains(element))
                        operandStack.Push(GetOperation(element, new Number(operandStack.Pop()), new Number(0)).Evaluate());

                    else operandStack.Push(GetOperation(element, new Number(operandStack.Pop()), new Number(operandStack.Pop())).Evaluate());
                }
            }
            return operandStack.Pop();
        }

        private IExpression GetOperation(string op, IExpression rightOperand, IExpression leftOperand)
        {
            switch (op)
            {
                case "-":
                    return new SubtractionExp(leftOperand, rightOperand);
                case "+":
                    return new AdditionExp(leftOperand, rightOperand);
                case "*":
                    return new MultiplicationExp(leftOperand, rightOperand);
                case "/":
                    return new DivisionExp(leftOperand, rightOperand);
                case "^":
                    return new PowerExp(leftOperand, rightOperand);
                case "cos":
                    return new CosineExp(rightOperand);
                case "sin":
                    return new SineExp(rightOperand);
                case "!":
                    return new FactorialExp(rightOperand);
                case "sqrt":
                    return new RootExp(rightOperand, new Number(2));
                case "rt":
                    return new RootExp(rightOperand, leftOperand);

                default: throw new Exception("Illegal operation");
            }
        }
    }
}
