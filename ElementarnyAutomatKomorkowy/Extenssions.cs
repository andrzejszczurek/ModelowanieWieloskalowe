using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarnyAutomatKomorkowy
{
   public static class Extenssions
   {
      /// <summary>
      /// Uzupełnia tablicę stanów określonym stanem
      /// </summary>
      /// <param name="arr">Tablica stanów</param>
      /// <param name="state">Stan (domyślnie pusty)</param>
      /// <returns>Tablica stanów</returns>
      public static StateType[] Fill(this StateType[] arr, StateType state = StateType.Empty)
      {
         for (int i = 0; i < arr.Length; i++)
         {
            arr[i] = state;
         }
         return arr;
      }

      /// <summary>
      /// Wyświetla tablicę stanów
      /// </summary>
      /// <param name="arr">Tablica stanów</param>
      public static void Display(this StateType[] arr)
      {
         foreach (var el in arr)
         {
            var c = el == StateType.Full ? "#" : " ";
            Console.Write(c + " ");
         }
         Console.WriteLine();
      }
   }
}
