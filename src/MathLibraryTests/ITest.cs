using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibraryTests
{
    /// <summary>
    /// Auxiliari interface for AdditionExpTest, SubtrationExpTest, MultiplicationExpTest and DivisionExpTest classes
    /// Including testing methods
    /// </summary>
    interface ITest
    {
        void WithZero();

        void TwoDifferentNumbers();

        void TwoSameNumbers();

        void TwoOppositeNumbers();

        void TwoSpecialFormatNumbers();
    }
}
