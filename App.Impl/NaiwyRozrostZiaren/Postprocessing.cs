using App.Impl.Conditions.Boudary;
using App.Impl.Conditions.Neighborhood;
using App.Impl.NaiwyRozrostZiaren.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Impl.NaiwyRozrostZiaren
{
   public class Postprocessing
   {
      private readonly int?[][] m_area;

      private readonly int m_cellSize;

      public Postprocessing(int?[][] area, int a_cellSize)
      {
         m_area = area;
         m_cellSize = a_cellSize;
      }

      public void CalculateAverageGrainSurface(IEnumerable<GrainElement> a_grains)
      {
         foreach (var grain in a_grains)
            grain.AverageSurface = CalculateAverageGrainSurface(grain.Id);
      }

      public void CalculateBoudaryLength(IEnumerable<GrainElement> a_grains, BoundaryCondition a_boundary)
      {
         var boundary = new BoundaryFactory().CreateBoudary(a_boundary);
         var neighboorhood = new NeighboorhoodFactory().CreateRule(Neighborhood.VonNeuman);

         foreach (var grain in a_grains)
            grain.BoundaryLength = CalculateBoudaryLength(grain.Id, boundary, neighboorhood) * m_cellSize;
      }

      private double CalculateAverageGrainSurface(int grainId)
      {
         var pixels = 0;

         for (int i = 0; i < m_area.Length; i++)
            pixels += m_area[i].Count(g => g.Value == grainId);

         return pixels * m_cellSize * m_cellSize;
      }

      private int CalculateBoudaryLength(int a_id, IBoudaryConditionRule a_boundary, INeighborhoodRule a_neighborhood)
      {
         var bounds = 0;
         for (int y = 0; y < m_area.Length; y++)
         {
            for (int x = 0; x < m_area[y].Length; x++)
            {
               var id = m_area[y][x].Value;
               if (id != a_id)
                  continue;

               var localGrid = a_neighborhood.ApplyRuleToLocalGrid(a_boundary.PrepareLocalGrid(y, x, m_area));
               bounds += GetBounds(a_id, localGrid);
            }
         }
         return bounds;
      }

      private int GetBounds(int a_examinedId, int?[][] localGrid)
      {
         var result = 0;
         for (int i = 0; i < localGrid.Length; i++)
         {
            for (int j = 0; j < localGrid[i].Length; j++)
            {
               var id = localGrid[j][i];
               if (id != null && id != a_examinedId)
                  result++;
            }
         }
         return result;
      }
   }
}
