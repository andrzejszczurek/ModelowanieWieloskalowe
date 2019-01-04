namespace App.Impl.Conditions.Neighborhood
{
   public class MooreNeighborhood : INeighborhoodRule
   {
      public int?[][] ApplyRuleToLocalGrid(int?[][] a_localGrid)
      {
         // V V V
         // V o V
         // V V V
         return a_localGrid;
      }
   }
}
