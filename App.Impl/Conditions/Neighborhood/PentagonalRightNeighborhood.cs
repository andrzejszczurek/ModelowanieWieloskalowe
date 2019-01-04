namespace App.Impl.Conditions.Neighborhood
{
   public class PentagonalRightNeighborhood : INeighborhoodRule
   {
      public int?[][] ApplyRuleToLocalGrid(int?[][] a_localGrid)
      {
         // - V V
         // - o V
         // - V V
         a_localGrid[0][0] = null;
         a_localGrid[1][0] = null;
         a_localGrid[2][0] = null;
         return a_localGrid;
      }
   }
}
