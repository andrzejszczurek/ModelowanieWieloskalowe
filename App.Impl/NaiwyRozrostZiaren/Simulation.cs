using App.Impl.Conditions.Boudary;
using App.Impl.Conditions.Neighborhood;
using App.Impl.GameOfLive;
using App.Impl.NaiwyRozrostZiaren.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Impl.NaiwyRozrostZiaren
{
   public class Simulation
   {
      public int CellSize { get; }

      private readonly int m_width;

      private readonly int m_height;

      private Random m_random;

      public BoundaryCondition BoundaryCondition { get; set; }

      public Neighborhood Neighborhood { get; set; }

      private readonly BoundaryFactory m_boundaryFactory;

      private readonly NeighboorhoodFactory m_neighboorhoodFactory;

      public Simulation(int a_height, int a_width, int a_cellSize
         ,BoundaryCondition a_boundary, Neighborhood a_neighbor)
      {
         m_width = a_width / a_cellSize;
         m_height = a_height / a_cellSize;
         CellSize = a_cellSize;
         m_random = new Random();
         BoundaryCondition = a_boundary;
         Neighborhood = a_neighbor;
         m_boundaryFactory = new BoundaryFactory();
         m_neighboorhoodFactory = new NeighboorhoodFactory();
      }

      public int?[][] GetCustomPopulation()
      {
         return Extenssions.Init2DimArray<int?>(m_height, m_width).Fill(default(int?));
      }

      public int?[][] GetNextPopulationCycle(int?[][] a_actualCycle)
      {
         var nextCycle = GetCustomPopulation();
         var boudary = m_boundaryFactory.CreateBoudary(BoundaryCondition);
         var neighboorhood = m_neighboorhoodFactory.CreateRule(Neighborhood);
         for (int y = 0; y < a_actualCycle.Length; y++)
            for (int x = 0; x < a_actualCycle[y].Length; x++)
            {
               if (a_actualCycle[y][x] == null)
                  nextCycle[y][x] = GetNextCellState(y, x, a_actualCycle, boudary, neighboorhood);
               else
                  nextCycle[y][x] = a_actualCycle[y][x];
            }

         return nextCycle;
      }

      private int? GetNextCellState(int a_y, int a_x, int?[][] a_populationGrid
         , IBoudaryConditionRule a_boudaryRule, INeighborhoodRule a_neighborhoodRule)
      {
         var localGrid = a_boudaryRule.PrepareLocalGrid(a_y, a_x, a_populationGrid);
         var dic = new Dictionary<int?, int?>();
         for (int y = 0; y < localGrid.Length; y++)
         {
            for (int x = 0; x < localGrid[y].Length; x++)
            {
               var id = localGrid[y][x];
               if (id == null)
                  continue;

               var inDic = dic.SingleOrDefault(d => d.Key == id);
               if (inDic.Key == null)
                  dic[id] = 1;
               else
                  dic[id] = dic[id].Value + 1;
            }
         }

         if (!dic.Any())
            return null;

         var newStateIds = dic.Where(d => d.Value == dic.Max(x => x.Value.Value));
         if (newStateIds.Count() == 1)
            return newStateIds.First().Key.Value;

         var ids = newStateIds.Select(n => n.Key).ToArray();
         var randomKeyIndex = m_random.Next(0, ids.Length);

         return ids[randomKeyIndex].Value;
      }
   }
}
