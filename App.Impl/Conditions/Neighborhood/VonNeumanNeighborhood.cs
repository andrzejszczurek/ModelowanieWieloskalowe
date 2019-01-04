namespace App.Impl.Conditions.Neighborhood
{
   public class VonNeumanNeighborhood : INeighborhoodRule
   {
      public int?[][] ApplyRuleToLocalGrid(int?[][] a_localGrid)
      {
         // - V -
         // V o V
         // - V -
         a_localGrid[0][0] = null;
         a_localGrid[0][2] = null;
         a_localGrid[2][0] = null;
         a_localGrid[2][2] = null;
         return a_localGrid;
      }
   }
}
