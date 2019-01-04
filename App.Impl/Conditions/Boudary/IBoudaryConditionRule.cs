namespace App.Impl.Conditions.Boudary
{
   public interface IBoudaryConditionRule
   {
      int?[][] PrepareLocalGrid(int a_y, int a_x, int?[][] a_stateGrid);
   }
}
