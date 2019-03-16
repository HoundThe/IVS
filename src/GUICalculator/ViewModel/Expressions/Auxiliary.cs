using GUICalculator.ViewModel.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GUICalculator.View
{
    internal class Auxiliary : TerminalExpression
    {
        public Auxiliary()
            : base("AuxiliaryExpressionTemplate")
        {
            Background = Brushes.LightGray;
        }

        protected override void OnMouseClick(object sender, MouseButtonEventArgs e)
        {
            Caret.Instance.SetActiveExpression(this, ExpressionSide.Left);
            e.Handled = true;
        }

        public override Expression MoveLeft(Expression child, bool jumpIn)
        {
            // Without this modification of caret's expression side it would be needed
            // to press the left arrow key twice to move left because the auxiliary is invisible.
            if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
            {
                Caret.Instance.ExpressionSide = ExpressionSide.Left;
            }
            return ParentExpression.MoveLeft(this, false);
        }

        public override Expression MoveRight(Expression child, bool jumpIn)
        {
            // Without this modification of caret's expression side it would be needed
            // to press the left arrow key twice to move right because the auxiliary is invisible.
            if (Caret.Instance.ExpressionSide == ExpressionSide.Left)
            {
                Caret.Instance.ExpressionSide = ExpressionSide.Right;
            }
            return ParentExpression.MoveRight(this, false);
        }

        public override string ConvertToString()
        {
            return String.Empty;
        }
    }
}
