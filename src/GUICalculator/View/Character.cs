using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GUICalculator.View
{
    class Character : Expression
    {

        public Character(char value, Expression parent)
            : base(parent)
        {
            Value = value;
            this.Template = Application.Current.FindResource("CharacterExpressionTemplate") as ControlTemplate;
            this.DataContext = this;
        }


        public char Value { get; set; }

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
    }
}
