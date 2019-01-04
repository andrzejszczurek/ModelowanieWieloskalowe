namespace App.Impl.Conditions.Neighborhood
{
   public class HexagonalRightNeighborhood : INeighborhoodRule
   {
      public int?[][] ApplyRuleToLocalGrid(int?[][] a_localGrid)
      {
         // - V V
         // V o V
         // V V -
         a_localGrid[0][0] = null;
         a_localGrid[0][2] = null;
         return a_localGrid;
      }
   }
}
