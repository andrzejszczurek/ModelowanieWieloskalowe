namespace App.Impl.Conditions.Boudary
{
   public class PeriodicalBoudary : IBoudaryConditionRule
   {
      public int?[][] PrepareLocalGrid(int a_y, int a_x, int?[][] a_populationGrid)
      {
         var localGrid = new int?[3][];
         int?[] currentRow = a_populationGrid[a_y];
         int?[] aboveRow = a_y == 0 ? a_populationGrid[a_populationGrid.Length - 1] : a_populationGrid[a_y - 1];
         int?[] underRow = a_y == a_populationGrid.Length - 1 ? a_populationGrid[0] : a_populationGrid[a_y + 1];

         localGrid[0] = GetLocalRowForGrid(a_x, aboveRow);
         localGrid[1] = GetLocalRowForGrid(a_x, currentRow);
         localGrid[2] = GetLocalRowForGrid(a_x, underRow);

         return localGrid;
      }

      private int?[] GetLocalRowForGrid(int x, int?[] a_row)
      {
         int?[] a_localRow;
         if (x == 0)
            a_localRow = new int?[3] { a_row[a_row.Length - 1], a_row[x], a_row[x + 1] };
         else if (x == a_row.Length - 1)
            a_localRow = new int?[3] { a_row[x - 1], a_row[x], a_row[0] };
         else
            a_localRow = new int?[3] { a_row[x - 1], a_row[x], a_row[x + 1] };

         return a_localRow;
      }

   }
}
