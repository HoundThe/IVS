using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUICalculator.View
{
    public class Caret : FrameworkElement
    {
        private readonly Timer timer;
        private readonly int blinkPeriod = 500;
        private Point location;
        private Pen pen = new Pen(Brushes.Black, 1);

        public static readonly DependencyProperty VisibleProperty =
            DependencyProperty.Register("Visible", typeof(bool),
            typeof(Caret), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));

        private Caret()
        {
            pen.Freeze();
            CaretHeight = DefaultHeight;
            Left = DefaultPosition.X;
            Top = DefaultPosition.Y;
            Visible = true;
            timer = new Timer(BlinkCaret, null, 0, blinkPeriod);
        }

        public static Caret Instance { get; } = new Caret();
        public double CaretHeight { get; set; }
        public Expression ActiveExpression { get; private set; }
        public ExpressionSide ExpressionSide { get; set; } // defines on which side of the ActiveExpression the Caret lies
        public Point DefaultPosition { get; } = new Point(0, 10);
        public double DefaultHeight { get; } = 18;

        protected override void OnRender(DrawingContext dc)
        {
            if (Visible)
            {
                dc.DrawLine(pen, location, new Point(Left, location.Y + CaretHeight));
            }
        }

        public bool Visible
        {
            get
            {
                return (bool)GetValue(VisibleProperty);
            }
            set
            {
                SetValue(VisibleProperty, value);
            }
        }

        public double Left
        {
            get { return location.X; }
            set
            {
                if (location.X != value)
                {
                    location.X = Math.Floor(value) + .5; //to avoid WPF antialiasing
                    if (Visible)
                    {
                        Visible = false;
                    }
                }
            }
        }

        public double Top
        {
            get { return location.Y; }
            set
            {
                if (location.Y != value)
                {
                    location.Y = Math.Floor(value) + .5; //to avoid WPF antialiasing
                    if (Visible)
                    {
                        Visible = false;
                    }
                }
            }
        }
        public bool RestartBlinking()
        {
            return timer.Change(0, blinkPeriod);
        }

        public void FlipSide()
        {
            ExpressionSide = ExpressionSide == ExpressionSide.Left ? 
                ExpressionSide.Right : ExpressionSide.Left;

            if (ActiveExpression == null)
                return;

            Point position;
            if (ExpressionSide == ExpressionSide.Left)
                position = ActiveExpression.RightPositionOf();
            else
                position = ActiveExpression.LeftPositionOf();
            Left = position.X;
        }

        public void SetActiveExpression(Expression exp)
        {
            ActiveExpression = exp;
            Point position = default(Point);

            if (ExpressionSide == ExpressionSide.Left)
                position = exp.LeftPositionOf();
            else
                position = exp.RightPositionOf();

            Left = position.X;
            Top = position.Y;
            CaretHeight = exp.ActualHeight;
            RestartBlinking();
        }

        private void BlinkCaret(Object state)
        {
            Dispatcher.Invoke(new Action(delegate { Visible = !Visible; }));
        }
        
    }
}
