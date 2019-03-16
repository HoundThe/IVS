using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalculator.Model
{
    class InfixToPostfixConverter
    {
        private string operators = "+-*/!^";
        private int[] precedences = { 1, 1, 2, 2, 3, 4 };
        private string[] functions = { "sqrt", "rt", "sin", "cos", "tg" };

        private bool IsDigit(char ch)
        {
            return Char.IsDigit(ch) || ch == 'e' || ch == 'p';
        }

        private bool IsOperator(char ch)
        {
            return operators.Contains(ch);
        }

        private bool IsFunction(string str)
        {
            return functions.Contains(str);
        }

        private int GetPrecedence(char ch)
        {
            int index = operators.IndexOf(ch);
            if (index < 0)
                throw new FormatException("Unrecognized operator.");
            return precedences[index];
        }

        public string Convert(string infix)
        {
            StringBuilder postfix = new StringBuilder();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < infix.Length; i++)
            {
                if (IsDigit(infix[i]))
                {
                    postfix.Append(infix[i]);
                    if (i + 1 < infix.Length && !IsDigit(infix[i + 1]))
                        postfix.Append(" ");
                }
                else if (infix[i] == '(')
                {
                    stack.Push(infix[i].ToString());
                }
                else if (infix[i] == ')')
                {
                    while (stack.Peek()[0] != '(')
                    {
                        postfix.Append(stack.Pop());
                        postfix.Append(" ");
                    }
                    stack.Pop(); // pop '(' from the stack

                    if (IsFunction(stack.Peek()))
                    {
                        postfix.Append(stack.Pop());
                        postfix.Append(" ");
                    }
                }
                else if (IsOperator(infix[i]))
                {
                    while (stack.Count > 0 && 
                        IsOperator(stack.Peek()[0]) &&
                        GetPrecedence(stack.Peek()[0]) > GetPrecedence(infix[i]))
                    {
                        string op = stack.Pop();
                        postfix.Append(op[0]);
                        postfix.Append(" ");
                    }
                    stack.Push(infix[i].ToString());
                }
                else
                {
                    int n = i;
                    while (Char.IsLetter(infix[n]))
                        n++;
                    string function = infix.Substring(i, n - i);
                    if (IsFunction(function))
                    {
                        stack.Push(function);
                        i = n - 1;
                    }
                }
            }

            while (stack.Count > 0)
            {
                postfix.Append(stack.Pop());
                if (stack.Count != 0)
                    postfix.Append(" ");
            }
            return postfix.ToString();
        }
    }
}
