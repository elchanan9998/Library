using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.AppCode
{
    public class GlobFunc
    {
        public static int GetMax(int[] arr)
        {
            int max = 0;
            for(int i = 0; i < arr.Length; i++)
                if (arr[i] > max)
                
                    max = arr[i];
                return max;
            
        }
    }
}