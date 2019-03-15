using GUICalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace GUICalculator.View
{
    internal class SquareRoot : Expression
    {
        public SquareRoot()
            : base("SquareRootExpressionTemplate")
        {
            this.AddAuxiliary(); // add auxiliary to InnerExpression collection
        }
        
        public ObservableCollection<Expression> InnerExpression { get; set; } = new ObservableCollection<Expression>();

        public override void AddExpression(Expression activeExpression, Expression expressionToBeAdded)
        {
            int activeIndex = InnerExpression.IndexOf(activeExpression);
            if (activeIndex >= 0)
            {
                if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
                    activeIndex++;
                InnerExpression.Insert(activeIndex, expressionToBeAdded);

                // remove auxiliary
                if (activeExpression is Auxiliary)
                    InnerExpression.Remove(activeExpression);
                return;
            }
            
            throw new KeyNotFoundException("Active expression wasn't found therefore a new expression couldn't be added.");
        }

        public override Expression NextChild(Expression currentChild)
        {
            for (int i = 0; i < InnerExpression.Count; i++)
            {
                if (currentChild == InnerExpression[i])
                {
                    if (i + 1 == InnerExpression.Count)
                        return null;
                    return InnerExpression[i + 1];
                }
            }
            throw new KeyNotFoundException("Expression not found.");
        }

        public override Expression PreviousChild(Expression currentChild)
        {
            for (int i = 0; i < InnerExpression.Count; i++)
            {
                if (currentChild == InnerExpression[i])
                {
                    if (i == 0)
                        return null;
                    return InnerExpression[i - 1];
                }
            }
            throw new KeyNotFoundException("Expression not found.");
        }


        public override Expression LastChild()
        {
            if (InnerExpression.Count > 0)
                return InnerExpression[InnerExpression.Count - 1];
            return null;
        }

        public override Expression FirstChild()
        {
            if (InnerExpression.Count > 0)
                return InnerExpression[0];
            return null;
        }


        public override bool DeleteChild(Expression child)
        {
            bool result = InnerExpression.Remove(child);
            Expression aux = AddAuxiliary();
            Caret.Instance.SetActiveExpression(aux);
            return result;
        }

        public override Expression AddAuxiliary()
        {
            if (InnerExpression.Count == 0)
            {
                var aux = new Auxiliary();
                aux.ParentExpression = this;
                InnerExpression.Add(aux);
                return aux;
            }
            return null;
        }
    }
}
