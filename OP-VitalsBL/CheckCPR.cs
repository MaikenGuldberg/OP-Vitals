using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_VitalsBL
{
    public class CheckCPR
    {
        private static int[] weight = { 4, 3, 2, 7, 6, 5, 4, 3, 2, 1 };

        public static bool cprOK(string nr)
        {
            int sum = 0;

            if (nr.Length == 10)
            {
                for (int i = 0; i < nr.Length; i++)
                {
                    char[] chars = nr.ToCharArray();
                    sum += (chars[i] - 0x30) * weight[i];
                }
                int res = sum % 11;
                if (res == 0)
                    return true;
            }
            return false;
        }
    }
}
