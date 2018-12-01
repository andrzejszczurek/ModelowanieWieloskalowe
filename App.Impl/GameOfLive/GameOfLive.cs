using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Impl.GameOfLive
{
   public class GameOfLive
   {
      public int CellSize { get; }

      private readonly int m_width;

      private readonly int m_height;

      public GameOfLive(int a_height, int a_width, int a_cellSize)
      {
         m_width = a_width / a_cellSize;
         m_height = a_height / a_cellSize;
         CellSize = a_cellSize;
      }

      public State[][] GetDeadPopulation()
      {
         return Init2DimArrar<State>(m_height, m_width).Fill(State.Dead);
      }

      public State[][] GetNextPopulationCycle(State[][] a_actualCycle)
      {
         var nextCycle = Init2DimArrar<State>(m_height, m_width);
         for (int i = 0; i < a_actualCycle.Length; i++)
            for (int j = 0; j < a_actualCycle[i].Length; j++)
               nextCycle[i][j] = GetNextCellState(i, j, a_actualCycle);

         return nextCycle;
      }

      private State GetNextCellState(int i, int j, State[][] a_populationGrid)
      {
         var actualState = a_populationGrid[i][j];
         State[] currnetRow = a_populationGrid[i];
         State[] aboveRow = i == 0 ? a_populationGrid[m_height-1] : a_populationGrid[i-1];
         State[] underRow = i == m_height-1 ? a_populationGrid[0] : a_populationGrid[i + 1];

         int aliveNumber = GetAliveNumber(j, aboveRow) + GetAliveNumber(j, currnetRow, true) + GetAliveNumber(j, underRow);

         var newState = GetNextCellStateInternal(actualState, aliveNumber);
         return newState;
      }

      private int GetAliveNumber(int j, State[] a_row, bool a_isExamined = false)
      {
         State[] pattern;
         if (j == 0)
            pattern = new State[3] { a_row[a_row.Length - 1], a_row[j], a_row[j + 1] };
         else if (j == a_row.Length-1)
            pattern = new State[3] { a_row[j - 1], a_row[j], a_row[0] };
         else
            pattern = new State[3] { a_row[j - 1], a_row[j], a_row[j + 1] };


         if (a_isExamined)
         {
            if (a_row[j] == State.Alive)
               return pattern.Count(x => x == State.Alive) - 1;
         }

         return pattern.Count(x => x == State.Alive);
      }

      private State GetNextCellStateInternal(State a_actualState, int a_neighberCount)
      {
         if (a_actualState == State.Alive)
            return (a_neighberCount == 2 || a_neighberCount == 3) ? State.Alive : State.Dead;

         return a_neighberCount == 3 ? State.Alive : State.Dead;
      }

      private T[][] Init2DimArrar<T>(int height, int width)
      {
         var arr = new T[height][];
         for (int i = 0; i < arr.Length; i++)
            arr[i] = new T[width];

         return arr;
      }
   }
}
