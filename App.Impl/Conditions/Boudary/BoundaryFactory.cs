using App.Impl.NaiwyRozrostZiaren.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Impl.Conditions.Boudary
{
   public class BoundaryFactory
   {
      public IBoudaryConditionRule CreateBoudary(BoundaryCondition condition)
      {
         switch (condition)
         {
            case BoundaryCondition.Periodical:
               return new PeriodicalBoudary();
            case BoundaryCondition.NonPeriodical:
               return new NonPeriodicalBoudary();
            default:
               throw new Exception("Unsupported boudary");
         }
      }

   }
}
