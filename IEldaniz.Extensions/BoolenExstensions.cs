using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEldaniz.Extensions
{
    public static class BoolenExstensions
    {
        public static bool ToBool(this short param)
        {
            if (param == 0)
                return false;
            else if (param == 1)
                return true;
            else
                throw new ArgumentOutOfRangeException(param + " dosn't convert to boolen type. Parameter value must be 0 or 1");
        }

        public static bool ToBool(this int param)
        {
            return param.ToShort().ToBool();
        }
    }
}
