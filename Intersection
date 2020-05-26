using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gVennDiagram
{
    class Intersect
    {
        int[] Intersection(int[] Equations1, int[] Equations2, int LA1, int LA2)
        {
            int[] result = new int[LA1 + LA2];
            int index = 0, i = 0, j = 0;

            while (i < LA1 && j < LA2)
            {
                if (Equations1[i] < Equations2[j])
                {
                    i++;
                }
                else if (Equations2[j] < Equations1[i])
                {
                    j++;
                }
                else
                {
                    result[index++] = Equations2[j++];
                    i++;
                }
            }
            return result;
        }
    }
}
