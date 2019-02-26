using GUICalculator.View;
using GUICalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUICalculator.ViewModel
{
    /// <summary>
    /// This class contains logic for handling user actions (such as button clicks) 
    /// and delegates it further for processing.
    /// </summary>
    public sealed class MainWindowVM : ViewModelBase
    {
        public View.Expression _expression;

        public MainWindowVM()
        {
            var exp = new Basic(null);
            var sqRoot = new Root(exp);
            AddNumber(54.45, sqRoot);
            AddNumber('*', sqRoot);
            var sqRoot2 = new Root(sqRoot);
            AddNumber(46.6, sqRoot2);
            sqRoot.InnerExpression.Add(sqRoot2);
            exp.Items.Add(sqRoot);
            exp.Items.Add(new Character('+', exp));
            AddNumber(54.24, exp);
            exp.Items.Add(new Character('+', exp));
            AddNumber(46, exp);
            Expression = exp;
        }

        private void AddNumber(double num, Root root)
        {
            string characters = num.ToString();
            foreach (char c in characters)
            {
                root.InnerExpression.Add(new Character(c, root));
            }
        }

        private void AddNumber(double num, Basic basic)
        {
            string characters = num.ToString();
            foreach (char c in characters)
            {
                basic.Items.Add(new Character(c, basic));
            }
        }

        public View.Expression Expression
        {
            get => _expression;
            set
            {
                _expression = value;
                OnPropertyChanged(nameof(Expression));
            }
        }


        //public ObservableCollection<ContentContr> Expressions { get; set; } = new ObservableCollection<Expression>();
    }
}
