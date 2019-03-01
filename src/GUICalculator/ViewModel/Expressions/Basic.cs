﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GUICalculator.View
{
    class Basic : Expression
    {

        public Basic()
            : base("BasicExpressionTemplate")
        {
            this.AddAuxiliary();
        }

        public ObservableCollection<Expression> Items { get; set; } = new ObservableCollection<Expression>();

        public override void AddExpression(Expression activeExpression, Expression expression)
        {
            //Expression activeExpression = Caret.Instance.ActiveExpression;
            int activeIndex = Items.IndexOf(activeExpression);
            if (activeIndex >= 0)
            {
                if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
                    activeIndex++;
                Items.Insert(activeIndex, expression);

                // remove auxiliary
                if (activeExpression is Auxiliary)
                    Items.Remove(activeExpression);
                return;
            }
            throw new KeyNotFoundException("Active expression wasn't found therefore a new expression couldn't be added.");
        }

        public override Expression NextChild(Expression currentChild)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (currentChild == Items[i])
                {
                    if (i + 1 == Items.Count)
                        return null;
                    return Items[i + 1];
                }
            }
            throw new KeyNotFoundException("Expression not found.");
        }

        public override Expression PreviousChild(Expression currentChild)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (currentChild == Items[i])
                {
                    if (i == 0)
                        return null;
                    return Items[i - 1];
                }
            }
            throw new KeyNotFoundException("Expression not found.");
        }

        public override Expression LastChild()
        {
            if (Items.Count > 0)
                return Items[Items.Count - 1];
            return null;
        }

        public override Expression FirstChild()
        {
            if (Items.Count > 0)
                return Items[0];
            return null;
        }

        public override bool DeleteChild(Expression child)
        {
            bool result = Items.Remove(child);
            Expression aux = AddAuxiliary();
            Caret.Instance.SetActiveExpression(aux);
            return result;
        }

        
        public override Expression AddAuxiliary()
        {
            if (Items.Count == 0)
            {
                var aux = new Auxiliary();
                aux.ParentExpression = this;
                Items.Add(aux);
                return aux;
            }
            return null;
        }
    }
}
