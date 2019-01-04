using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Impl.Conditions.Boudary
{
   public class NonPeriodicalBoudary : IBoudaryConditionRule
   {
      public int?[][] PrepareLocalGrid(int a_y, int a_x, int?[][] a_populationGrid)
      {
         var localGrid = new int?[3][];

         int?[] aboveRow = a_y == 0 ? null : a_populationGrid[a_y - 1];
         if (aboveRow is null)
            localGrid[0] = new int?[3] { null, null, null };
         else
            localGrid[0] = GetLocalRowForGrid(a_x, aboveRow);

         int?[] currentRow = a_populationGrid[a_y];
         localGrid[1] = GetLocalRowForGrid(a_x, currentRow);

         int?[] underRow = a_y == a_populationGrid.Length - 1 ? null : a_populationGrid[a_y + 1];
         if (underRow is null)
            localGrid[2] = new int?[3] { null, null, null };
         else
            localGrid[2] = GetLocalRowForGrid(a_x, underRow);

         return localGrid;
      }

      private int?[] GetLocalRowForGrid(int x, int?[] a_row)
      {
         int?[] a_localRow;
         if (x == 0)
            a_localRow = new int?[3] { null, a_row[x], a_row[x + 1] };
         else if (x == a_row.Length - 1)
            a_localRow = new int?[3] { a_row[x - 1], a_row[x], null };
         else
            a_localRow = new int?[3] { a_row[x - 1], a_row[x], a_row[x + 1] };

         return a_localRow;
      }

   }
}
