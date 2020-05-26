using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRedAlert
{
    class StackArray
    {
        int[][]array;
        int top;
        int maxstk;
        public StackArray(int capacity)
        {
            top = -1;
            maxstk = capacity;
            array = new int[maxstk][];
        }
        public bool isEmpty() 
        {
            if (top == -1)
                return true;
            else
                return false;
        }
        public bool isFull()
        {
            if (top == maxstk - 1)
                return true;
            else
                return false;
        }
        public void Push(int[] arr)
        {
            if (!isFull()) 
            {
                top++;
                array[top] = arr;
            }
        }
        public int[] Pop()
        {
            return array[top--];
        }
    }
}
