using GUICalculator.Command;
using GUICalculator.View;
using GUICalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
//using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUICalculator.ViewModel
{
    /// <summary>
    /// This class contains logic for handling user actions (such as button clicks) 
    /// and delegates it further for processing.
    /// </summary>
    public sealed class MainWindowVM : ViewModelBase
    {
        public Expression _expression;
        public ICommand _characterInputCommand;
        public ICommand _rootCommand;

        public MainWindowVM()
        {
            Expression = new Basic();
            Caret.Instance.SetActiveExpression(Expression.FirstChild());

            //var exp = new Basic(null);
            //var sqRoot = new Root(exp);
            //AddNumber(54.45, sqRoot);
            //AddNumber('*', sqRoot);
            //var sqRoot2 = new Root(sqRoot);
            //AddNumber(46.6, sqRoot2);
            //sqRoot.InnerExpression.Add(sqRoot2);
            //exp.Items.Add(sqRoot);
            //exp.Items.Add(new Character('+', exp));
            //AddNumber(54.24, exp);
            //exp.Items.Add(new Character('+', exp));
            //AddNumber(46, exp);
            //Expression = exp;
        }

        public ICommand CharacterInputCommand
        {
            get
            {
                if (_characterInputCommand == null)
                    _characterInputCommand = new RelayCommand<string>(AddCharacterExpression);
                return _characterInputCommand;
            }
        }

        public ICommand RootCommand
        {
            get
            {
                if (_rootCommand == null)
                    _rootCommand = new RelayCommand(AddRootExpression);
                return _rootCommand;
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

        public void AddRootExpression()
        {
            Expression activeExp = Caret.Instance.ActiveExpression;
            Root root = new Root();
            AddNewExpression(activeExp, root);
            Caret.Instance.SetActiveExpression(root.FirstChild());
        }

        public void AddCharacterExpression(string str)
        {
            if (str.Length != 1)
                throw new Exception("String's length should be 1.");
            AddCharacterExpression(str[0]);
        }

        public void AddCharacterExpression(char character)
        {
            Expression activeExp = Caret.Instance.ActiveExpression;
            Expression characterExp = new Character(character);
            AddNewExpression(activeExp, characterExp);
        }

        public void AddNewExpression(Expression activeExp, Expression newExpression)
        {
            //Expression activeExp = Caret.Instance.ActiveExpression;
            if (activeExp != null)
            {
                // create new expression and add it to the appropriate parent expression
                Expression parent = activeExp.ParentExpression;
                newExpression.ParentExpression = parent;
                parent.AddExpression(activeExp, newExpression);

                // make sure the new expression is displayed and new position is calculated for this element
                activeExp.UpdateLayout();
                parent.UpdateLayout();
                newExpression.UpdateLayout();

                Caret.Instance.ExpressionSide = ExpressionSide.Right;
                // make sure the the caret is displayed correctly after parent's layout is updated
                Caret.Instance.UpdateActiveExpression();
            }
        }

        public void MoveCaret(Direction direction)
        {
            Caret caret = Caret.Instance;
            Expression exp = null;

            if (direction == Direction.Left)
                exp = caret.ActiveExpression.MoveLeft(null, true);
            else if (direction == Direction.Right)
                exp = caret.ActiveExpression.MoveRight(null, true);

            if (exp == null)
                return;

            caret.SetActiveExpression(exp);
            caret.RestartBlinking();
        }

        public void DeleteExpression(Direction direction)
        {
            Expression activeExp = Caret.Instance.ActiveExpression;
            if (activeExp == null)
                return;
            Expression parentExp = activeExp.ParentExpression;
            if (parentExp == null)
                return;

            Expression nextActive;
            Expression toBeRemoved;

            if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
            {
                if (direction == Direction.Left)
                {
                    nextActive = parentExp.PreviousChild(activeExp);
                    toBeRemoved = activeExp;

                    // handle the situation when the toBeRemoved is leftmost
                    if (nextActive == null)
                    {
                        Caret.Instance.ExpressionSide = ExpressionSide.Left;
                        nextActive = parentExp.NextChild(activeExp);
                    }
                }
                else
                {
                    nextActive = activeExp;
                    toBeRemoved = parentExp.NextChild(activeExp);
                }
            }
            else
            {
                if (direction == Direction.Left)
                {
                    nextActive = activeExp;
                    toBeRemoved = parentExp.PreviousChild(activeExp); 
                }
                else
                {
                    nextActive = parentExp.NextChild(activeExp);
                    toBeRemoved = activeExp;

                    // handle the situation when the toBeRemoved is rightmost
                    if (nextActive == null)
                    {
                        Caret.Instance.ExpressionSide = ExpressionSide.Right;
                        nextActive = parentExp.PreviousChild(activeExp);
                    }
                }
            }

            if (toBeRemoved != null)
            {
                //Console.WriteLine("ExpSide {0}, Active value: {1}", Caret.Instance.ExpressionSide, ((Character)Caret.Instance.ActiveExpression).Value);
                parentExp.DeleteChild(toBeRemoved);
                parentExp.UpdateLayout();
                Caret.Instance.SetActiveExpression(nextActive);
                //Console.WriteLine("ExpSide {0}, Active value: {1}", Caret.Instance.ExpressionSide, ((Character)Caret.Instance.ActiveExpression).Value);
            }
        }

    }
}
