using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalculator.ViewModel
{
    internal sealed class Result : ViewModelBase
    {
        public Result(double value)
        {
            Value = value;
        }

        public double Value { get; set; }
    }
}
