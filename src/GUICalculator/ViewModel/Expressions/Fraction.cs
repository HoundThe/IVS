using GUICalculator.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalculator.ViewModel.Expressions
{
    class Fraction : Expression
    {
        public Fraction() 
            : base("FractionExpressionTemplate")
        {
            AddAuxiliary(); // add one aux to the numerator
            AddAuxiliary(); // add one aux to the denominator
        }
        public ObservableCollection<Expression> NumeratorExpression { get; set; } = new ObservableCollection<Expression>();
        public ObservableCollection<Expression> DenominatorExpression { get; set; } = new ObservableCollection<Expression>();

        public override Expression AddAuxiliary()
        {
            ObservableCollection<Expression> collection = null;

            if (NumeratorExpression.Count == 0)
                collection = NumeratorExpression;
            else if (DenominatorExpression.Count == 0)
                collection = DenominatorExpression;

            if (collection != null)
            {
                var aux = new Auxiliary();
                aux.ParentExpression = this;
                collection.Add(aux);
                return aux;
            }
            return null;
        }

        public override void AddExpression(Expression activeExpression, Expression expressionToBeAdded)
        {
            int activeIndex = NumeratorExpression.IndexOf(activeExpression);
            if (activeIndex >= 0)
            {
                if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
                    activeIndex++;
                NumeratorExpression.Insert(activeIndex, expressionToBeAdded);

                // remove auxiliary
                if (activeExpression is Auxiliary)
                    NumeratorExpression.Remove(activeExpression);
                return;
            }

            activeIndex = DenominatorExpression.IndexOf(activeExpression);
            if (activeIndex >= 0)
            {
                if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
                    activeIndex++;
                DenominatorExpression.Insert(activeIndex, expressionToBeAdded);

                // remove auxiliary
                if (activeExpression is Auxiliary)
                    DenominatorExpression.Remove(activeExpression);
                return;
            }
            throw new KeyNotFoundException("Active expression wasn't found therefore a new expression couldn't be added.");
        }

        public override bool DeleteChild(Expression child)
        {
            bool result = NumeratorExpression.Remove(child) || DenominatorExpression.Remove(child);
            Expression aux = AddAuxiliary();
            Caret.Instance.SetActiveExpression(aux, ExpressionSide.Left);
            return result;
        }

        public override Expression FirstChild()
        {
            if (NumeratorExpression.Count > 0)
                return NumeratorExpression[0];
            if (DenominatorExpression.Count > 0)
                return DenominatorExpression[0];
            return null;
        }

        public override Expression LastChild()
        {
            if (DenominatorExpression.Count > 0)
                return DenominatorExpression[DenominatorExpression.Count - 1];
            if (NumeratorExpression.Count > 0)
                return NumeratorExpression[NumeratorExpression.Count - 1];
            return null;
        }

        public override Expression NextChild(Expression currentChild)
        {
            for (int i = 0; i < NumeratorExpression.Count; i++)
            {
                if (currentChild == NumeratorExpression[i])
                {
                    if (i + 1 == NumeratorExpression.Count)
                    {
                        if (DenominatorExpression.Count > 0 && Caret.Instance.ExpressionSide == ExpressionSide.Right)
                        {
                            Caret.Instance.ExpressionSide = ExpressionSide.Left;
                            return DenominatorExpression[0];
                        }
                        return null;
                    }
                    return NumeratorExpression[i + 1];
                }
            }
            for (int i = 0; i < DenominatorExpression.Count; i++)
            {
                if (currentChild == DenominatorExpression[i])
                {
                    if (i + 1 == DenominatorExpression.Count)
                        return null;
                    return DenominatorExpression[i + 1];
                }
            }
            throw new KeyNotFoundException("Expression not found.");
        }

        public override Expression PreviousChild(Expression currentChild)
        {
            for (int i = 0; i < DenominatorExpression.Count; i++)
            {
                if (currentChild == DenominatorExpression[i])
                {
                    if (i == 0)
                    {
                        if (NumeratorExpression.Count > 0 && Caret.Instance.ExpressionSide == ExpressionSide.Left)
                        {
                            Caret.Instance.ExpressionSide = ExpressionSide.Right;
                            return NumeratorExpression[NumeratorExpression.Count - 1];
                        }
                        return null;
                    }
                    return DenominatorExpression[i - 1];
                }
            }
            for (int i = 0; i < NumeratorExpression.Count; i++)
            {
                if (currentChild == NumeratorExpression[i])
                {
                    if (i == 0)
                        return null;
                    return NumeratorExpression[i - 1];
                }
            }
            throw new KeyNotFoundException("Expression not found.");
        }
    }
}
