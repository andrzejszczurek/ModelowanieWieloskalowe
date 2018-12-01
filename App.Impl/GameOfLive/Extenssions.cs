using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Impl.GameOfLive
{
   public static class Extenssions
   {
      public static T[][] Fill<T>(this T[][] a_2DimArray, T a_value)
      {
         for (int i = 0; i < a_2DimArray.Length; i++)
            for (int j = 0; j < a_2DimArray[i].Length; j++)
               a_2DimArray[i][j] = a_value;

         return a_2DimArray;
      }
   }
}
