using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gVennDiagram
{
    class Union
    {
        // Union Method 
        int[] Unions(int[] Equations1, int[] Equations2, int LA1, int LA2)
        {
            int[] result = new int[LA1 + LA2];
            int index = 0, i = 0, j = 0;
            while (i < LA1 && j < LA2)
            {
                if (Equations1[i] < Equations2[j])
                {
                    if (Equations1[i] != 0)
                    {
                        result[index++] = Equations1[i++];
                    }
                    else
                    {
                        i++;
                    }
                }
                else if (Equations2[j] < Equations1[i])
                {
                    if (Equations2[j] != 0)
                    {
                        result[index++] = Equations2[j++];
                    }
                    else
                    {
                        j++;
                    }
                }
                else
                {
                    if (Equations2[j] != 0)
                    {
                        result[index++] = Equations2[j++];
                        i++;
                    }
                    else
                    {
                        j++; i++;
                    }
                }

            }
            while (i < LA1)
            {
                if (Equations1[i] != 0)
                {
                    result[index++] = Equations1[i++];
                }
                else
                {
                    i++;
                }
            }
            while (j < LA2)
            {
                if (Equations2[j] != 0)
                {
                    result[index++] = Equations2[j++];
                }
                else
                {
                    j++;
                }
            }
            return result;
        }
    }
}
