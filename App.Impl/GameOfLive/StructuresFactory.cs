using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Impl.GameOfLive
{
   public enum Shape
   {
      Point,

      Static_1,
      Static_2,
      Static_3,

      OscilatorHorizontal,
      OscilatorVertical,
      Oscilator_2,

      Glider,
      Matuzalem,

      Gun,
   }

   public class Seed
   {
      public int X { get; set; }

      public int Y { get; set; }

      public Seed(int x, int y)
      {
         X = x;
         Y = y;
      }
   }

   public class StructuresFactory
   {
      public State[][] PutStructure(State[][] a_grid, Seed a_seed, Shape shape)
      {
         switch (shape)
         {
            case Shape.Static_1:
               {
                  CreateStatic1(a_grid, a_seed);
                  break;
               }
            case Shape.Static_2:
               {
                  CreateStatic2(a_grid, a_seed);
                  break;
               }
            case Shape.Static_3:
               {
                  CreateStatic3(a_grid, a_seed);
                  break;
               }
            case Shape.Point:
               {
                  CreatePoint(a_grid, a_seed);
                  break;
               }
            case Shape.Glider:
               {
                  CreateGlider(a_grid, a_seed);
                  break;
               }
            case Shape.Oscilator_2:
               {
                  CreateOscilator2(a_grid, a_seed);
                  break;
               }
            case Shape.OscilatorHorizontal:
               {
                  CreateOscilatorH(a_grid, a_seed);
                  break;
               }
            case Shape.OscilatorVertical:
               {
                  CreateOscilatorV(a_grid, a_seed);
                  break;
               }
            case Shape.Matuzalem:
               {
                  CreateMatuzalem(a_grid, a_seed);
                  break;
               }
            case Shape.Gun:
               {
                  CreateGun(a_grid, a_seed);
                  break;
               }
         }
         return a_grid;
      }

      private void CreateGun(State[][] a_grid, Seed a_seed)
      {
         var (Y, X) = GetBoundary(a_grid, a_seed);
         a_grid[ForBoundary(a_seed.Y, Y)][ForBoundary(a_seed.X+27, X)] = State.Alive;

         a_grid[ForBoundary(a_seed.Y+1, Y)][ForBoundary(a_seed.X+27, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+1, Y)][ForBoundary(a_seed.X+25, X)] = State.Alive;

         a_grid[ForBoundary(a_seed.Y+2, Y)][ForBoundary(a_seed.X+24, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+2, Y)][ForBoundary(a_seed.X+23, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+2, Y)][ForBoundary(a_seed.X+16, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+2, Y)][ForBoundary(a_seed.X+15, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+2, Y)][ForBoundary(a_seed.X+37, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+2, Y)][ForBoundary(a_seed.X+38, X)] = State.Alive;

         a_grid[ForBoundary(a_seed.Y+3, Y)][ForBoundary(a_seed.X + 24, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+3, Y)][ForBoundary(a_seed.X + 23, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+3, Y)][ForBoundary(a_seed.X + 18, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+3, Y)][ForBoundary(a_seed.X + 14, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+3, Y)][ForBoundary(a_seed.X + 37, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+3, Y)][ForBoundary(a_seed.X + 38, X)] = State.Alive;

         a_grid[ForBoundary(a_seed.Y+4, Y)][ForBoundary(a_seed.X + 24, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+4, Y)][ForBoundary(a_seed.X + 23, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+4, Y)][ForBoundary(a_seed.X + 19, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+4, Y)][ForBoundary(a_seed.X + 13, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+4, Y)][ForBoundary(a_seed.X+3, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+4, Y)][ForBoundary(a_seed.X + 4, X)] = State.Alive;

         a_grid[ForBoundary(a_seed.Y + 5, Y)][ForBoundary(a_seed.X + 25, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y + 5, Y)][ForBoundary(a_seed.X + 27, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y + 5, Y)][ForBoundary(a_seed.X + 19, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y + 5, Y)][ForBoundary(a_seed.X + 13, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y + 5, Y)][ForBoundary(a_seed.X + 20, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y + 5, Y)][ForBoundary(a_seed.X + 17, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y + 5, Y)][ForBoundary(a_seed.X+3, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y + 5, Y)][ForBoundary(a_seed.X + 4, X)] = State.Alive;

         a_grid[ForBoundary(a_seed.Y + 6, Y)][ForBoundary(a_seed.X + 19, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y + 6, Y)][ForBoundary(a_seed.X + 13, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y + 6, Y)][ForBoundary(a_seed.X + 27, X)] = State.Alive;

         a_grid[ForBoundary(a_seed.Y + 7, Y)][ForBoundary(a_seed.X + 14, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y + 7, Y)][ForBoundary(a_seed.X + 18, X)] = State.Alive;

         a_grid[ForBoundary(a_seed.Y + 8, Y)][ForBoundary(a_seed.X + 15, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y + 8, Y)][ForBoundary(a_seed.X + 16, X)] = State.Alive;

      }

      private void CreateMatuzalem(State[][] a_grid, Seed a_seed)
      {
         var (Y, X) = GetBoundary(a_grid, a_seed);
         a_grid[ForBoundary(a_seed.Y, Y)][ForBoundary(a_seed.X, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y, Y)][ForBoundary(a_seed.X+1, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y-1, Y)][ForBoundary(a_seed.X+1, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y-1, Y)][ForBoundary(a_seed.X+2, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+1, Y)][ForBoundary(a_seed.X+1, X)] = State.Alive;

      }

      private void CreateOscilator2(State[][] a_grid, Seed a_seed)
      {
         var (Y, X) = GetBoundary(a_grid, a_seed);
         a_grid[ForBoundary(a_seed.Y, Y)][ForBoundary(a_seed.X, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y, Y)][ForBoundary(a_seed.X+1, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+1, Y)][ForBoundary(a_seed.X, X)] = State.Alive;

         a_grid[ForBoundary(a_seed.Y+2, Y)][ForBoundary(a_seed.X+3, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+3, Y)][ForBoundary(a_seed.X+2, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+3, Y)][ForBoundary(a_seed.X+3, X)] = State.Alive;
      }

      private void CreateStatic1(State[][] a_grid, Seed a_seed)
      {
         var (Y, X) = GetBoundary(a_grid, a_seed);
         a_grid[ForBoundary(a_seed.Y, Y)][ForBoundary(a_seed.X, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y, Y)][ForBoundary(a_seed.X-1, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y-1, Y)][ForBoundary(a_seed.X, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y-1, Y)][ForBoundary(a_seed.X-1, X)] = State.Alive;

      }

      private void CreateStatic2(State[][] a_grid, Seed a_seed)
      {
         var (Y, X) = GetBoundary(a_grid, a_seed);
         a_grid[ForBoundary(a_seed.Y, Y)][ForBoundary(a_seed.X, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+1, Y)][ForBoundary(a_seed.X+1, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+1, Y)][ForBoundary(a_seed.X+2, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y, Y)][ForBoundary(a_seed.X+3, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y-1, Y)][ForBoundary(a_seed.X+1, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y-1, Y)][ForBoundary(a_seed.X+2, X)] = State.Alive;
      }

      private void CreateStatic3(State[][] a_grid, Seed a_seed)
      {
         var (Y, X) = GetBoundary(a_grid, a_seed);
         a_grid[ForBoundary(a_seed.Y, Y)][ForBoundary(a_seed.X, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+1, Y)][ForBoundary(a_seed.X+1, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y+1, Y)][ForBoundary(a_seed.X+2, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y, Y)][ForBoundary(a_seed.X+3, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y-1, Y)][ForBoundary(a_seed.X+1, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y-1, Y)][ForBoundary(a_seed.X+3, X)] = State.Alive;
         a_grid[ForBoundary(a_seed.Y-2, Y)][ForBoundary(a_seed.X+2, X)] = State.Alive;
      }

      private void CreatePoint(State[][] a_grid, Seed a_seed)
      {
         a_grid[a_seed.Y][a_seed.X] = State.Alive;
      }

      private void CreateOscilatorH(State[][] a_grid, Seed a_seed)
      {
         int boundaryX = a_grid[a_seed.Y].Length - 1;
         a_grid[a_seed.Y][a_seed.X] = State.Alive;

         a_grid[a_seed.Y][ForBoundary(a_seed.X - 1, boundaryX)] = State.Alive;
         a_grid[a_seed.Y][ForBoundary(a_seed.X + 1, boundaryX)] = State.Alive;

      }

      private void CreateOscilatorV(State[][] a_grid, Seed a_seed)
      {
         int boundaryY = a_grid.Length - 1;
         a_grid[a_seed.Y][a_seed.X] = State.Alive;

         a_grid[ForBoundary(a_seed.Y - 1, boundaryY)][a_seed.X] = State.Alive;
         a_grid[ForBoundary(a_seed.Y + 1, boundaryY)][a_seed.X] = State.Alive;

      }

      private void CreateGlider(State[][] a_grid, Seed a_seed)
      {
         a_grid[a_seed.Y - 2][a_seed.X] = State.Alive;
         a_grid[a_seed.Y - 1][a_seed.X + 1] = State.Alive;
         a_grid[a_seed.Y][a_seed.X - 1] = State.Alive;
         a_grid[a_seed.Y][a_seed.X] = State.Alive;
         a_grid[a_seed.Y][a_seed.X + 1] = State.Alive;
      }

      private int ForBoundary(int v, int boundary)
      {
         if (v < 0)
            return v + boundary + 1;
         if (v > boundary)
            return v - boundary - 1;

         return v;
      }

      private (int Y, int X) GetBoundary(State[][] a_grid, Seed a_seed)
      {
         int boundaryX = a_grid[a_seed.Y].Length - 1;
         int boundaryY = a_grid.Length - 1;
         return (boundaryY, boundaryX);
      }
   }
}
