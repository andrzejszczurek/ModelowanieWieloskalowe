using App.Impl.GameOfLive;
using System.Drawing;

namespace TheGameOfLive
{
   public class GameCreator
   {
      public State[][] Population { get; set; }

      public Shape CurrentShape { get; set; }

      public bool IsGameActive { get; set; }

      public StructuresFactory StructuresFactory { get; private set; }

      private readonly Size m_size;

      private readonly Size m_area; 

      public readonly GameOfLive m_gameOfLive;

      public GameCreator(int a_cellSize, Size a_area)
      {
         m_area = a_area;
         m_size = new Size(a_cellSize, a_cellSize);
         m_gameOfLive = new GameOfLive(m_area.Height, m_area.Width, a_cellSize);
         StructuresFactory = new StructuresFactory();
         Population = m_gameOfLive.GetDeadPopulation();
         CurrentShape = Shape.Point;
      }

      public State[][] CreateStartPopulation()
      {
         return m_gameOfLive.GetDeadPopulation();
      }

      public Rectangle CreateCell(int a_x, int a_y)
      {
         var cell = new Rectangle(new Point(a_x * m_gameOfLive.CellSize, a_y * m_gameOfLive.CellSize), m_size);
         return cell;
      }

      public Rectangle CreateCell(int a_x, int a_y, int a_size)
      {
         var cell = new Rectangle(new Point(a_x * a_size, a_y * a_size), new Size(a_size, a_size));
         return cell;
      }

      public Bitmap PopulationGridToBitmapForNextStep()
      {
         Population = m_gameOfLive.GetNextPopulationCycle(Population);
         return PopulationGridToBitmap();
      }

      public Bitmap PopulationGridToBitmap()
      {
         var bmp = new Bitmap(m_area.Width, m_area.Height);

         Graphics g = Graphics.FromImage(bmp);
         SolidBrush sb = new SolidBrush(Color.Black);

         for (int i = 0; i < Population.Length; i++)
         {
            for (int j = 0; j < Population[i].Length; j++)
            {
               if (Population[i][j] == State.Alive)
                  g.FillRectangle(sb, CreateCell(j, i));
               else
                  g.DrawRectangle(new Pen(sb, 1), CreateCell(j, i));
            }
         }
         return bmp;
      }

      public Bitmap GetCustomPopulationGrid(Size a_grid, int a_cellSize, Shape? a_shape)
      {
         var bmp = new Bitmap(a_grid.Width, a_grid.Height);
         var population = new GameOfLive(a_grid.Height, a_grid.Width, a_cellSize).GetCustomPopulation(State.Dead);
         Graphics g = Graphics.FromImage(bmp);
         SolidBrush sb = new SolidBrush(Color.Black);

         if (a_shape != null)
            population 
               = StructuresFactory
               .PutStructure(population, new Seed((a_grid.Width / a_cellSize) / 2, (a_grid.Height / a_cellSize) / 2), a_shape.Value);

         for (int i = 0; i < population.Length; i++)
         {
            for (int j = 0; j < population[i].Length; j++)
            {
               if (population[i][j] == State.Alive)
                  g.FillRectangle(sb, CreateCell(j, i, a_cellSize));
               else
                  g.DrawRectangle(new Pen(sb, 1), CreateCell(j, i, a_cellSize));
            }
         }
         return bmp;
      }


      public Bitmap PutPoint(int a_X, int a_Y)
      {
         Seed seed = new Seed(a_X / m_size.Height, a_Y / m_size.Width);
         Population = StructuresFactory.PutStructure(Population, seed, Shape.Point);
         return PopulationGridToBitmap();
      }

      public Bitmap PutShape(Shape a_shape, int a_X, int a_Y)
      {
         Seed seed = new Seed(a_X / m_size.Height, a_Y / m_size.Width);
         return PutShape(a_shape, seed);
      }

      public Bitmap PutShape(Shape a_shape, Seed a_seed)
      {
         Population = StructuresFactory.PutStructure(Population, a_seed, a_shape);
         return PopulationGridToBitmap();
      }

      public Bitmap PutSelectedShape(int a_X, int a_Y)
      {
         return PutShape(CurrentShape, a_X, a_Y);
      }

      public Bitmap PutSelectedShape(Seed a_seed)
      {
         return PutShape(CurrentShape, a_seed);
      }

   }
}
