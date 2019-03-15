using GUICalculator.Command;
using GUICalculator.View;
using GUICalculator.ViewModel;
using GUICalculator.ViewModel.Expressions;
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
        public ICommand _multiplicationCommand;
        public ICommand _powerCommand;
        public ICommand _rootCommand;
        public ICommand _squareRootCommand;
        public ICommand _ansCommand;
        public ICommand _clearCommand;
        public ICommand _deleteCommand;
        public ICommand _evaluateCommand;
        public ICommand _sineCommand;
        public ICommand _cosineCommand;
        public ICommand _tangentCommand;

        public MainWindowVM()
        {
            ClearExpressions();
        }

        public ICommand CharacterInputCommand => _characterInputCommand ?? (_characterInputCommand = new RelayCommand<string>(AddCharacterExpression));
        public ICommand MultiplicationCommand => _multiplicationCommand ?? (_multiplicationCommand = new RelayCommand(AddMultiplicationExpression));
        public ICommand PowerCommand => _powerCommand ?? (_powerCommand = new RelayCommand(AddPowerExpression));
        public ICommand RootCommand => _rootCommand ?? (_rootCommand = new RelayCommand(AddRootExpression));
        public ICommand SquareRootCommand => _squareRootCommand ?? (_squareRootCommand = new RelayCommand(AddSquareRootExpression));
        public ICommand AnsCommand => _ansCommand ?? (_ansCommand = new RelayCommand(PerformAns));
        public ICommand ClearCommand => _clearCommand ?? (_clearCommand = new RelayCommand(ClearExpressions));
        public ICommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(() => DeleteExpression(Direction.Left)));
        public ICommand EvaluateCommand => _evaluateCommand ?? (_evaluateCommand = new RelayCommand(EvaluateExpression));
        public ICommand SineCommand => _sineCommand ?? (_sineCommand = new RelayCommand(() => AddTrigonometricExpression(TrigonometricFunctionType.Sine)));
        public ICommand CosineCommand => _cosineCommand ?? (_cosineCommand = new RelayCommand(() => AddTrigonometricExpression(TrigonometricFunctionType.Cosine)));
        public ICommand TangentCommand => _tangentCommand ?? (_tangentCommand = new RelayCommand(() => AddTrigonometricExpression(TrigonometricFunctionType.Tangent)));

        public View.Expression Expression
        {
            get => _expression;
            set
            {
                _expression = value;
                OnPropertyChanged(nameof(Expression));
            }
        }
        
        private void EvaluateExpression()
        {
            throw new NotImplementedException();
        }

        private void ClearExpressions()
        {
            Expression = new Basic();
            Caret.Instance.SetActiveExpression(Expression.FirstChild());
        }

        private void PerformAns()
        {
            throw new NotImplementedException();
        }

        public void AddRootExpression()
        {
            Expression root = new Root();
            AddNewExpression(Caret.Instance.ActiveExpression, root);
            Caret.Instance.SetActiveExpression(root.FirstChild());
        }

        public void AddSquareRootExpression()
        {
            Expression squareRoot = new SquareRoot();
            AddNewExpression(Caret.Instance.ActiveExpression, squareRoot);
            Caret.Instance.SetActiveExpression(squareRoot.FirstChild());
        }

        public void AddPowerExpression()
        {
            Expression power = new Power();
            AddNewExpression(Caret.Instance.ActiveExpression, power);
            Caret.Instance.SetActiveExpression(power.FirstChild());
        }

        public void AddTrigonometricExpression(TrigonometricFunctionType type)
        {
            Expression trigFunc = new TrigonometricFunction(type);
            AddNewExpression(Caret.Instance.ActiveExpression, trigFunc);
            Caret.Instance.SetActiveExpression(trigFunc.FirstChild());
        }

        public void AddMultiplicationExpression()
        {
            Expression multiplicationSign = new MultiplicationSign();
            AddNewExpression(Caret.Instance.ActiveExpression, multiplicationSign);
            Caret.Instance.SetActiveExpression(multiplicationSign);
        }

        public void AddCharacterExpression(string str)
        {
            if (str.Length != 1)
                throw new Exception("String's length should be 1.");
            AddCharacterExpression(str[0]);
        }

        public void AddCharacterExpression(char character)
        {
            Expression characterExp = null;
            switch (character)
            {
                case '(':
                    {
                        characterExp = new LeftParenthesis();
                    } break;
                case ')':
                    {
                        characterExp = new RightParenthesis();
                    } break;
                default:
                    {
                        characterExp = new Character(character);
                    } break;
            }

            Expression activeExp = Caret.Instance.ActiveExpression;
            AddNewExpression(activeExp, characterExp);
            Caret.Instance.SetActiveExpression(characterExp);
        }

        public void AddNewExpression(Expression activeExp, Expression newExpression)
        {
            //Expression activeExp = Caret.Instance.ActiveExpression;
            if (activeExp != null)
            {
                // create new expression and add it to the appropriate parent expression
                Expression parent = activeExp.ParentExpression;
                if (parent == null)
                    return;
                parent.AddExpression(activeExp, newExpression);
                newExpression.ParentExpression = parent;

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
            Console.WriteLine("Caret side: {0}", Caret.Instance.ExpressionSide);
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
                Caret.Instance.UpdateActiveExpression();
                //Console.WriteLine("ExpSide {0}, Active value: {1}", Caret.Instance.ExpressionSide, ((Character)Caret.Instance.ActiveExpression).Value);
            }
        }

    }
}
