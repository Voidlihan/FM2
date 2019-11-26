using System;
using System.Collections.Generic;
using System.Text;

namespace FarmersMarket
{
    public static class StringCheck
    {
        public static bool CheckOnElements(this string str, char element)
        {
            int cntPlus = 0;
            for(int i = 0; i <str.Length; i++)
            {
                if(str[i].Equals(element))
                {
                    cntPlus++;
                }
            }
            if(cntPlus == 2) { return true; }
            return false;
        }
    }
}
