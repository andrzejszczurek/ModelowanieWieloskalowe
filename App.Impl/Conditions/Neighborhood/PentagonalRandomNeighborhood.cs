using System;

namespace App.Impl.Conditions.Neighborhood
{
   public class PentagonalRandomNeighborhood : INeighborhoodRule
   {
      private readonly Random m_random;

      private readonly PentagonalLeftNeighborhood m_leftNeighborhood;

      private readonly PentagonalRightNeighborhood m_rightNeighborhood;

      public PentagonalRandomNeighborhood()
      {
         m_random = new Random();
         m_leftNeighborhood = new PentagonalLeftNeighborhood();
         m_rightNeighborhood = new PentagonalRightNeighborhood();
      }

      public int?[][] ApplyRuleToLocalGrid(int?[][] a_localGrid)
      {
         if (m_random.Next(0, 9999) % 2 == 0)
            return m_leftNeighborhood.ApplyRuleToLocalGrid(a_localGrid);

         return m_rightNeighborhood.ApplyRuleToLocalGrid(a_localGrid);
      }
   }
}
