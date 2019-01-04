using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace App.Impl.NaiwyRozrostZiaren
{
   public class GrainElementCreator
   {
      public List<GrainElement> Elements { get; private set; }

      private int m_currentId;

      private Random m_random;

      public GrainElementCreator()
      {
         Elements = new List<GrainElement>();
         m_currentId = 0;
         m_random = new Random();
      }

      public GrainElement GetElementById(int id)
      {
         return Elements.Single(x => x.Id == id);
      }

      public GrainElement CreateNew()
      {
         var element = new GrainElement(GenerateUniqueId(), GenerateUniqueColor());
         Elements.Add(element);
         return element;
      }

      private int GenerateUniqueId()
      {
         return m_currentId++;
      }

      private Color GenerateUniqueColor()
      {
         int tryLimit = 50;
         do
         {
            var color = GetNextColor();
            if (!IsColorUsed(color))
               return color;
            
         } while (--tryLimit >= 0);

         throw new Exception("Nie udało się wygenerować unikalnego koloru dla elementu");
      }

      private Color GetNextColor()
      {
         var red = m_random.Next(0, 256);
         var green = m_random.Next(0, 256);
         var blue = m_random.Next(0, 256);
         return Color.FromArgb(red, green, blue);
      }

      private bool IsColorUsed(Color color)
      {
         return Elements.Any(e => e.Color == color);
      }

   }
}
