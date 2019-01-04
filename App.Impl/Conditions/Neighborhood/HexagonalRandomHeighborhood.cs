using System;

namespace App.Impl.Conditions.Neighborhood
{
   public class HexagonalRandomHeighborhood : INeighborhoodRule
   {
      private readonly Random m_random;

      private readonly HexagonalLeftHeighborhood m_leftNeighborhood;

      private readonly HexagonalRightNeighborhood m_rightNeighborhood;

      public HexagonalRandomHeighborhood()
      {
         m_random = new Random();
         m_leftNeighborhood = new HexagonalLeftHeighborhood();
         m_rightNeighborhood = new HexagonalRightNeighborhood();
      }

      public int?[][] ApplyRuleToLocalGrid(int?[][] a_localGrid)
      {
         if (m_random.Next(0, 9999) % 2 == 0)
            return m_leftNeighborhood.ApplyRuleToLocalGrid(a_localGrid);

         return m_rightNeighborhood.ApplyRuleToLocalGrid(a_localGrid);
      }
   }
}
