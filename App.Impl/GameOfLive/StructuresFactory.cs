using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Impl.GameOfLive
{
   public enum Shape
   {
      Oscilator,
      Glider,
   }

   public class Seed
   {
      public Seed(int x, int y )
      {
         X = x;
         Y = y;
      }

      public int X { get; set; }

      public int Y { get; set; }
   }

   public class StructuresFactory
   {
      public State[][] PutStructure(State[][] a_grid, Seed a_seed, Shape shape)
      {
         switch (shape)
         {
            case Shape.Glider:
               {
                  CreateGlider(a_grid, a_seed);
                  break;
               }

            case Shape.Oscilator:
               {
                  CreateOscilator(a_grid, a_seed);
                  break;
               }
         }
         return a_grid;
      }

      private void CreateOscilator(State[][] a_grid, Seed a_seed)
      {
         a_grid[a_seed.Y][a_seed.X-1] = State.Alive;
         a_grid[a_seed.Y][a_seed.X] = State.Alive;
         a_grid[a_seed.Y][a_seed.X+1] = State.Alive;
      }

      private void CreateGlider(State[][] a_grid, Seed a_seed)
      {
         a_grid[a_seed.Y - 2][a_seed.X] = State.Alive;
         a_grid[a_seed.Y - 1][a_seed.X + 1] = State.Alive;
         a_grid[a_seed.Y][a_seed.X - 1] = State.Alive;
         a_grid[a_seed.Y][a_seed.X] = State.Alive;
         a_grid[a_seed.Y][a_seed.X + 1] = State.Alive;
      }
   }
}
