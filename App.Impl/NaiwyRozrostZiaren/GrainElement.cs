using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Impl.NaiwyRozrostZiaren
{
   public class GrainElement
   {
      public int Id { get; private set; }

      public Color Color { get; private set; }

      public double AverageSurface { get; set; }

      public double BoundaryLength { get; set; }

      public GrainElement(int a_id, Color a_color)
      {
         Id = a_id;
         Color = a_color;
      }
   }
}
