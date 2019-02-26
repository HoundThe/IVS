using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUICalculator.View
{
    static class FrameworkElementExtension
    {

        public static Point LeftPositionOf(this FrameworkElement element)
        {
            return element.TranslatePoint(new Point(0, 0), Application.Current.MainWindow);
        }

        public static Point RightPositionOf(this FrameworkElement element)
        {
            Point point = LeftPositionOf(element);
            point.X += element.ActualWidth;
            return point;
        }
    }
}
