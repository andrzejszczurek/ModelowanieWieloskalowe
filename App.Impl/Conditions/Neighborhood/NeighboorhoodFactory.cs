using System;

namespace App.Impl.Conditions.Neighborhood
{
   public class NeighboorhoodFactory
   {
      public INeighborhoodRule CreateRule(NaiwyRozrostZiaren.Enum.Neighborhood a_neighborhood)
      {
         switch (a_neighborhood)
         {
            case NaiwyRozrostZiaren.Enum.Neighborhood.Moore:
               return new MooreNeighborhood();
            case NaiwyRozrostZiaren.Enum.Neighborhood.VonNeuman:
               return new VonNeumanNeighborhood();
            case NaiwyRozrostZiaren.Enum.Neighborhood.HexagonalLeft:
               return new HexagonalLeftHeighborhood();
            case NaiwyRozrostZiaren.Enum.Neighborhood.HexagonalRight:
               return new HexagonalRightNeighborhood();
            case NaiwyRozrostZiaren.Enum.Neighborhood.HexagonalRandom:
               return new HexagonalRandomHeighborhood();
            case NaiwyRozrostZiaren.Enum.Neighborhood.PentagonalLeft:
               return new PentagonalLeftNeighborhood();
            case NaiwyRozrostZiaren.Enum.Neighborhood.PentagonalRight:
               return new PentagonalRightNeighborhood();
            case NaiwyRozrostZiaren.Enum.Neighborhood.PentagonalRandom:
               return new PentagonalRandomNeighborhood();
            default:
               throw new Exception($"Not Supported neighbornood '{a_neighborhood}'");
         }
      }
   }
}
