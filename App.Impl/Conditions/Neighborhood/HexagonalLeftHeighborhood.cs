namespace App.Impl.Conditions.Neighborhood
{
   public class HexagonalLeftHeighborhood : INeighborhoodRule
   {
      public int?[][] ApplyRuleToLocalGrid(int?[][] a_localGrid)
      {
         // V V -
         // V o V
         // - V V
         a_localGrid[0][2] = null;
         a_localGrid[2][0] = null;
         return a_localGrid;
      }
   }
}
