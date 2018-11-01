using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarnyAutomatKomorkowy
{
   public class StateProvider
   {
      private IEnumerable<Rule> m_ruleSet;

      public StateProvider()
         : this(30)
      { 
      }

      public StateProvider(byte systemBase)
      {
         SimpleConfigTest();
         m_ruleSet = PrepareRuleSet(GetStateConfiguration(systemBase), Rule.Custom());
      }

      private void SimpleConfigTest()
      {
         var base30Config = PrepareRuleSet(GetStateConfiguration(30), Rule.Custom()).ToArray();
         int i = 0;
         foreach (var rule in Rule.GetRuleSet30())
         {
            if (rule.Calculated != base30Config[i++].Calculated)
               throw new OperationCanceledException("Brak możliwości stworzenia konfiguracji. Nie poprawna implementacja składowych providera.");
         }
      }

      private IEnumerable<Rule> PrepareRuleSet(StateType[] configArray, IEnumerable<Rule> baseRuleSet)
      {
         if (configArray.Length != 8)
            throw new ArgumentException($"Tablica konfiguracyjna ma nie prawidłową długość: {configArray}");

         int i = 0;
         foreach (var rule in baseRuleSet)
         {
            rule.Calculated = configArray[i];
            i++;
         }

         return baseRuleSet;
      }

      private StateType[] GetStateConfiguration(byte a_base)
      {
         var configArr = new StateType[8];

         for (int x = 0; x < configArr.Length; x++)
            configArr[x] = StateType.Empty;

         int i = 0;
         while (a_base > 0)
         {
            configArr[i] = a_base % 2 == 0 ? StateType.Empty : StateType.Full;
            a_base /= 2;
            i++;
         }
         return configArr;
      }

      public StateType GetCurrentState(StateType[] arr, int i)
      {
         (StateType p, StateType c, StateType n) pattern;
         if (i <= 0)
            pattern = (arr[arr.Length - 1], arr[i], arr[i + 1]);
         else if (i >= arr.Length - 1)
            pattern = (arr[i - 1], arr[i], arr[0]);
         else
            pattern = (arr[i - 1], arr[i], arr[i + 1]);

         return CalculateType(pattern.p, pattern.c, pattern.n);
      }

      private StateType CalculateType(StateType previous, StateType current, StateType next)
         => m_ruleSet.Single(x => x.Previous == previous
                                               && x.CurrentState == current
                                               && x.Next == next).Calculated.Value;
   }
}
