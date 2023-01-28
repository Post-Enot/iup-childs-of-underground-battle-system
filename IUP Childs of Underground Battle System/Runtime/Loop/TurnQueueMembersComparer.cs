using System;
using System.Collections.Generic;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public sealed class TurnQueueMembersComparer : IComparer<ITurnQueueMember>
    {
        public int Compare(ITurnQueueMember aMember, ITurnQueueMember bMember)
        {
            if (aMember == null || bMember == null)
            {
                throw new ArgumentNullException();
            }
            return aMember.TurnPriority - bMember.TurnPriority;
        }
    }
}
