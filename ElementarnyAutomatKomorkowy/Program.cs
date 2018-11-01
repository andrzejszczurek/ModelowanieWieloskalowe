using System;

namespace ElementarnyAutomatKomorkowy
{
   class Program
   {
      static void Main(string[] args)
      {
         byte systemBase = 30;
         int size = 60;
         var arr = new StateType[size].Fill();
         arr[arr.Length / 2] = StateType.Full;
         arr.Display();
         var resultArr = new StateType[arr.Length];
         var provider = new StateProvider(systemBase);

         int counter = 0;
         do
         {
            for (int i = 0; i < arr.Length; i++)
            {
               resultArr[i] = provider.GetCurrentState(arr, i);
            }
            resultArr.Display();
            arr = (StateType[])resultArr.Clone();
         } while (++counter < 10);

         Console.ReadKey();
      }
   }
}
