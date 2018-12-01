using App.Impl.GameOfLive;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfLive
{
   public class GameCreator
   {
      private readonly Size m_size;

      private readonly Size m_area; 

      public readonly GameOfLive m_gameOfLive;

      public State[][] Population { get; set; }

      public StructuresFactory StructuresFactory { get; private set; }

      public GameCreator(int a_cellSize, Size a_area)
      {
         m_area = a_area;
         m_size = new Size(a_cellSize, a_cellSize);
         m_gameOfLive = new GameOfLive(m_area.Height, m_area.Width, a_cellSize);
         StructuresFactory = new StructuresFactory();
         Population = m_gameOfLive.GetDeadPopulation();
      }

      public State[][] CreateStartPopulation()
      {
         return m_gameOfLive.GetDeadPopulation();
      }

      public Rectangle CreateCell(int x, int y)
      {
         var cell = new Rectangle(new Point(x * m_gameOfLive.CellSize, y * m_gameOfLive.CellSize), m_size);
         return cell;
      }

      public Bitmap PopulationGridToBitmap()
      {
         var bmp = new Bitmap(m_area.Width, m_area.Height);
         Population = m_gameOfLive.GetNextPopulationCycle(Population);
         Graphics g = Graphics.FromImage(bmp);
         SolidBrush sb = new SolidBrush(Color.Black);

         for (int i = 0; i < Population.Length; i++)
         {
            for (int j = 0; j < Population[i].Length; j++)
            {
               if (Population[i][j] == State.Alive)
                  g.FillRectangle(sb, CreateCell(j, i));
            }
         }
         return bmp;
      }

   }
}
