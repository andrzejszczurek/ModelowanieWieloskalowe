using App.Impl.NaiwyRozrostZiaren.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace App.Impl.NaiwyRozrostZiaren
{
   public class SimulationCreator
   {
      private readonly GrainElementCreator m_seedCreator;

      private readonly Simulation m_simulation;

      private readonly int m_cellSize;

      public int?[][] CurrentState { get; set; }

      public Size GridSize { get; set; }

      public SimulationCreator(int a_height, int a_width, int a_cellSize)
      {
         m_seedCreator = new GrainElementCreator();
         m_simulation = new Simulation(a_height, a_width, a_cellSize, 
            BoundaryCondition.Periodical, Neighborhood.Moore);
         m_cellSize = a_cellSize;
         GridSize = new Size(a_width, a_height);
         CurrentState = m_simulation.GetCustomPopulation();
      }

      public Bitmap PutPoint(int a_X, int a_Y)
      {
         PutPointInternal(a_X, a_Y);
         return PopulationGridToBitmap();
      }

      private void PutPointInternal(int a_X, int a_Y)
      {
         CurrentState[a_Y][a_X] = m_seedCreator.CreateNew().Id;
      }

      public Bitmap PopulationGridToBitmapForNextStep()
      {
         CurrentState = m_simulation.GetNextPopulationCycle(CurrentState);
         return PopulationGridToBitmap();
      }

      public Bitmap PopulationGridToBitmap()
      {
         var bmp = new Bitmap(GridSize.Width, GridSize.Height);
         var sb = new SolidBrush(Color.Black);

         Graphics g = Graphics.FromImage(bmp);
         for (int i = 0; i < CurrentState.Length; i++)
         {
            for (int j = 0; j < CurrentState[i].Length; j++)
            {
               var elementId = CurrentState[i][j];
               if (elementId != null)
               {
                  var element = m_seedCreator.GetElementById(elementId.Value);
                  g.FillRectangle(new SolidBrush(element.Color), CreateCell(j, i, m_cellSize));
               }
            }
         }
         return bmp;
      }

      public Rectangle CreateCell(int a_x, int a_y, int a_size = 10)
      {
         var cell = new Rectangle(new Point(a_x * a_size, a_y * a_size), new Size(a_size, a_size));
         return cell;
      }

      public void ResetGrid()
      {
         CurrentState = m_simulation.GetCustomPopulation();
         m_seedCreator.Elements.Clear();
      }

      public bool IsAnyFreeSpace()
      {
         int freeCellCounter = 0;
         for (int i = 0; i < CurrentState.Length; i++)
            freeCellCounter += CurrentState[i].Count(c => c is null);

         return freeCellCounter != 0;
      }

      public Bitmap GenerateRandomStartGrains(int a_count, int? offset = null)
      {
         Random random = new Random();

         for (int i = 0; i < a_count; i++)
         {
            var y = random.Next(0, GridSize.Height / m_cellSize);
            var x = random.Next(0, GridSize.Width / m_cellSize);

            if (CheckIsNewGrainInOffset(x, y, offset))
               continue;

            PutPointInternal(x, y);
         }
         return PopulationGridToBitmap();
      }

      public static Array GetSupportedBoundaries()
      {
         return System.Enum.GetValues(typeof(BoundaryCondition));
      }

      public static Array GetSupportedNeighborhoods()
      {
         return System.Enum.GetValues(typeof(Neighborhood));
      }

      public void SetBoundary(BoundaryCondition a_boundaryCondition)
      {
         m_simulation.BoundaryCondition = a_boundaryCondition;
      }

      public void SetNeighborhood(Neighborhood a_neighborhood)
      {
         m_simulation.Neighborhood = a_neighborhood;
      }

      public BoundaryCondition GetBoundary()
         => m_simulation.BoundaryCondition;

      public IEnumerable<GrainElement> GetGrains() 
         => m_seedCreator.Elements;


      private bool CheckIsNewGrainInOffset(int x, int y, int? offset)
      {
         if (offset is null)
            return false;
         // TODO:
         return false;
      }
   }
}
