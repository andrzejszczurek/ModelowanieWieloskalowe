namespace App.Impl.Conditions.Neighborhood
{
   public interface INeighborhoodRule
   {
      int?[][] ApplyRuleToLocalGrid(int?[][] a_localGrid);
   }
}
