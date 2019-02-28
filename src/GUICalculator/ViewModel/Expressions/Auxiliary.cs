using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GUICalculator.View
{
    internal class Auxiliary : Expression
    {
        public Auxiliary()
        {
            this.Template = Application.Current.FindResource("AuxiliaryExpressionTemplate") as ControlTemplate;
            this.DataContext = this;
        }
        
        public override Expression FirstChild()
        {
            return null;
        }

        public override Expression LastChild()
        {
            return null;
        }

        public override Expression NextChild(Expression currentChild)
        {
            return null;
        }

        public override Expression PreviousChild(Expression currentChild)
        {
            return null;
        }

        public override Expression MoveLeft(Expression child, bool jumpIn)
        {
            if (ParentExpression == null)
                return null;
            return ParentExpression.MoveLeft(this, false);
        }

        public override Expression MoveRight(Expression child, bool jumpIn)
        {
            if (ParentExpression == null)
                return null;
            return ParentExpression.MoveRight(this, false);
        }

        public override void AddExpression(Expression activeExpression, Expression expression)
        {
            return;
        }

        public override bool DeleteChild(Expression child)
        {
            throw new NotSupportedException("Not supported operation");
        }

        public override Expression AddAuxiliary()
        {
            throw new NotSupportedException("Not supported operation");
        }
    }
}
