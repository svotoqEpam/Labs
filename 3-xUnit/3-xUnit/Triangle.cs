using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_xUnit
{
    public class Triangle
    {
        public bool TriangleInequality(double sideA, double sideB, double sideC)
        {
            if (sideA > 0 && sideB > 0 && sideC > 0)
            {
                if (sideA <= (sideB + sideC) && sideB <= (sideA + sideC) && sideC <= (sideA + sideB))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
