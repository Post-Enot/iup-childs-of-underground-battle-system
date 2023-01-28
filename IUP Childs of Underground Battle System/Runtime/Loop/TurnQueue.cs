using System.Collections.Generic;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public sealed class TurnQueue : ITurnQueue
    {
        public ITurnQueueMember CurrentMember => _members[_currentMemberIndex];
        public int MembersCount => _members.Count;

        private readonly List<ITurnQueueMember> _members = new();
        private int _currentMemberIndex;

        public void AddMember(ITurnQueueMember member)
        {
            for (int i = 0; i < _members.Count; i += 1)
            {
                if (member.TurnPriority > _members[i].TurnPriority)
                {
                    if (i < _currentMemberIndex)
                    {
                        _currentMemberIndex += 1;
                    }
                    _members.Insert(i, member);
                    return;
                }
            }
            _members.Add(member);
        }

        public bool RemoveMember(ITurnQueueMember member)
        {
            return _members.Remove(member);
        }

        public ITurnQueueMember MoveNext()
        {
            if (_members.Count == 0)
            {
                return null;
            }
            _currentMemberIndex += 1;
            if (_currentMemberIndex >= _members.Count)
            {
                _currentMemberIndex = 0;
            }
            return _members[_currentMemberIndex];
        }
    }
}
