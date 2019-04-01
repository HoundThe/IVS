using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GUICalculator.View.Converter
{
    class RoundValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value as string;
            double number;
            if (double.TryParse(val, out number))
            {
                long precision = 10000000000;
                int counter = 0;
                while (number < precision && counter < 10)
                {
                    number *= 10;
                    counter++;
                }
                number = Math.Round(number);
                for (counter--; counter >= 0; counter--)
                {
                    number /= 10;
                }
                return number;
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
