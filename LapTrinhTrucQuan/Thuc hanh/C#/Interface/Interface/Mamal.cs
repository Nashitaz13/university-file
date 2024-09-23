using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    interface iAbility: iThinking, iIntelligent
    {
    }
    interface iThinking
    {
        void thinking_behavior();
    }
    interface iIntelligent
    {
        void intelligent_behavior();
    }
    public class Human : Mamal, iAbility
    {
        public Human();
        public void thinking_behavior();
        public void intelligent_behavior();
    }
    public class Whale : Mamal
    {
        public Whale();
    }
    abstract class Mamal
    {
    }
}
