using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_xUnit
{
    public class Triangle
    {
        public bool TriangleInequality(double a, double b, double c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                if (a <= (b + c) && b <= (a + c) && c <= (a + b))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
