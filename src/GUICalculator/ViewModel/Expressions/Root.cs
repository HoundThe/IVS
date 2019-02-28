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
    internal class Root : Expression
    {
        public Root()
        {
            this.Template = Application.Current.FindResource("RootExpressionTemplate") as ControlTemplate;
            this.DataContext = this;

            this.AddAuxiliary(); // add auxiliary to first collection
            this.AddAuxiliary(); // add auxiliary to the second collection
        }
        
        public ObservableCollection<Expression> OuterExpression { get; set; } = new ObservableCollection<Expression>();
        public ObservableCollection<Expression> InnerExpression { get; set; } = new ObservableCollection<Expression>();

        public override void AddExpression(Expression activeExpression, Expression expression)
        {
            //Expression activeExpression = Caret.Instance.ActiveExpression;
            int activeIndex = InnerExpression.IndexOf(activeExpression);
            if (activeIndex >= 0)
            {
                if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
                    activeIndex++;
                InnerExpression.Insert(activeIndex, expression);

                // remove auxiliary
                if (activeExpression is Auxiliary)
                    InnerExpression.Remove(activeExpression);
                return;
            }

            activeIndex = OuterExpression.IndexOf(activeExpression);
            if (activeIndex >= 0)
            {
                if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
                    activeIndex++;
                OuterExpression.Insert(activeIndex, expression);

                // remove auxiliary
                if (activeExpression is Auxiliary)
                    OuterExpression.Remove(activeExpression);
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

        public override Expression MoveLeft(Expression child, bool jumpIn)
        {
            if (Caret.Instance.ExpressionSide == ExpressionSide.Left)
            {
                if (child != null && PreviousChild(child) != null)
                {
                    Expression lastChild = PreviousChild(child).LastChild();
                    if (lastChild != null)
                    {
                        Caret.Instance.ExpressionSide = ExpressionSide.Right;
                        return lastChild;
                    }
                    Caret.Instance.ExpressionSide = ExpressionSide.Right;
                    return PreviousChild(child); // leave Left
                }
                else
                {
                    //Caret.Instance.ExpressionSide = ExpressionSide.Right;
                    Expression tmp;
                    if (ParentExpression != null && (tmp = ParentExpression.MoveLeft(this, false)) != null)
                        return tmp;
                }
            }
            else // Right
            {
                // jump in from right
                if (jumpIn && LastChild() != null)
                {
                    return LastChild(); // leave right
                }

                if (child != null && PreviousChild(child) != null)
                {
                    return PreviousChild(child); // leave right
                }
                else
                {
                    Caret.Instance.ExpressionSide = ExpressionSide.Left;
                    return child;
                }
            }
            return FirstChild();
        }

        public override Expression MoveRight(Expression child, bool jumpIn)
        {
            if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
            {
                if (child != null && NextChild(child) != null)
                {
                    Expression lastChild = NextChild(child).FirstChild();
                    if (lastChild != null)
                    {
                        Caret.Instance.ExpressionSide = ExpressionSide.Left;
                        return lastChild;
                    }

                    Caret.Instance.ExpressionSide = ExpressionSide.Left;
                    return NextChild(child); 
                }
                else
                {
                    //Caret.Instance.ExpressionSide = ExpressionSide.Left;
                    Expression tmp;
                    if (ParentExpression != null && (tmp = ParentExpression.MoveRight(this, false)) != null)
                        return tmp;
                }
            }
            else // Right
            {
                // jump in from right
                if (jumpIn && FirstChild() != null)
                {
                    return FirstChild(); // leave right
                }

                if (child != null && NextChild(child) != null)
                {
                    return NextChild(child); // leave right
                }
                else
                {
                    Caret.Instance.ExpressionSide = ExpressionSide.Right;
                    return child;
                }
            }
            return LastChild();
        }

        public override bool DeleteChild(Expression child)
        {
            bool result = InnerExpression.Remove(child) || OuterExpression.Remove(child);
            Expression aux = AddAuxiliary();
            Caret.Instance.SetActiveExpression(aux);
            return result;
        }

        public override Expression AddAuxiliary()
        {
            ObservableCollection<Expression> collection = null;

            if (InnerExpression.Count == 0)
                collection = InnerExpression;
            else if (OuterExpression.Count == 0)
                collection = OuterExpression;
            
            if (collection != null)
            {
                var aux = new Auxiliary();
                aux.ParentExpression = this;
                collection.Add(aux);
                return aux;
            }
            return null;
        }
    }
}
