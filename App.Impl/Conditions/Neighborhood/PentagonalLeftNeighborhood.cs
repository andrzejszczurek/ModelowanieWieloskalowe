namespace App.Impl.Conditions.Neighborhood
{
   public class PentagonalLeftNeighborhood : INeighborhoodRule
   {
      public int?[][] ApplyRuleToLocalGrid(int?[][] a_localGrid)
      {
         // V V -
         // V o -
         // V V -
         a_localGrid[2][0] = null;
         a_localGrid[2][1] = null;
         a_localGrid[2][2] = null;
         return a_localGrid;
      }
   }
}
