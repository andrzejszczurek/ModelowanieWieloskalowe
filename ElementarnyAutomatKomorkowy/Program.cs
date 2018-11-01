using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarnyAutomatKomorkowy
{
   class Program
   {
      static void Main(string[] args)
      {
         byte baseValue = 30;

         var tab = GetStartetCollection(20);
         Display(tab);
         var resultTab = new StateType[tab.Length];

         var provider = new StateProvider(baseValue);

         int counter = 0;
         do
         {
            for (int i = 0; i < tab.Length; i++)
            {
               resultTab[i] = provider.GetCurrentState(tab, i);
            }
            Console.WriteLine();
            Display(resultTab);

            for (int i = 0; i < tab.Length; i++)
            {
               tab[i] = resultTab[i];
            }
         } while (++counter < 10);

         Console.ReadLine();
      }

      private static StateType[] GetStartetCollection(uint size)
      {
         var arr = new StateType[size];
         for (int i = 0; i < arr.Length; i++)
         {
            if (i == arr.Length / 2)
               arr[i] = StateType.Full;
            else
               arr[i] = StateType.Empty;
         }
         return arr;
      }

      private static void Display(StateType[] arr)
      {
         foreach (var el in arr)
         {
            var c = el == StateType.Full ? "#" : " ";
            Console.Write(c + " ");
         }
      }
   }
}
