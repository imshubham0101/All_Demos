using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsLib
{
    [Serializable]
    public class Maths
    {
        public int add(int x ,int y)
        {
            return x + y;
        }

        public int sub(int x ,int y)
        {
            return x - y;
        }
    }
}
