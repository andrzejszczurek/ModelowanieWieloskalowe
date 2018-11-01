using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarnyAutomatKomorkowy
{
   public enum StateType
   {
      Full,
      Empty
   }

   public class Rule
   {
      private int _priority;

      public StateType Previous { get; set; }

      public StateType Next { get; set; }

      public StateType CurrentState { get; set; }

      public StateType? Calculated { get; set; }

      private Rule()
         : this(StateType.Empty, StateType.Empty, StateType.Empty, null)
      { }

      private Rule(int priority, StateType prev, StateType current, StateType next, StateType? calculated)
      {
         Next = next;
         Previous = prev;
         Calculated = calculated;
         CurrentState = current;
         _priority = priority;
      }

      private Rule(StateType prev, StateType current, StateType next, StateType? calculated)
      {
         Next = next;
         Previous = prev;
         Calculated = calculated;
         CurrentState = current;
      }

      public static Rule[] Custom()
         => new List<Rule>()
         {
            new Rule(0, StateType.Empty, StateType.Empty, StateType.Empty, null),
            new Rule(1, StateType.Empty, StateType.Empty, StateType.Full, null),
            new Rule(2, StateType.Empty, StateType.Full, StateType.Empty, null),
            new Rule(3, StateType.Empty, StateType.Full, StateType.Full, null),
            new Rule(4, StateType.Full, StateType.Empty, StateType.Empty, null),
            new Rule(5, StateType.Full, StateType.Empty, StateType.Full, null),
            new Rule(6, StateType.Full, StateType.Full, StateType.Empty, null),
            new Rule(7, StateType.Full, StateType.Full, StateType.Full, null),
         }.OrderBy(s => s._priority).ToArray();

      public static Rule[] GetRuleSet30()
         => new List<Rule>()
         {
            new Rule(0 ,StateType.Empty, StateType.Empty, StateType.Empty, StateType.Empty),
            new Rule(1 ,StateType.Empty, StateType.Empty, StateType.Full, StateType.Full),
            new Rule(2 ,StateType.Empty, StateType.Full, StateType.Empty, StateType.Full),
            new Rule(3 ,StateType.Empty, StateType.Full, StateType.Full, StateType.Full),
            new Rule(4 ,StateType.Full, StateType.Empty, StateType.Empty, StateType.Full),
            new Rule(5 ,StateType.Full, StateType.Empty, StateType.Full, StateType.Empty),
            new Rule(6 ,StateType.Full, StateType.Full, StateType.Empty, StateType.Empty),
            new Rule(7 ,StateType.Full, StateType.Full, StateType.Full, StateType.Empty),
         }.OrderBy(s => s._priority).ToArray();
   }
}
