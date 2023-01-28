namespace IUP.ChildsOfUnderground.BattleSystem
{
    public interface ITurnQueue
    {
        public ITurnQueueMember CurrentMember { get; }
        public int MembersCount { get; }

        public void AddMember(ITurnQueueMember member);

        public bool RemoveMember(ITurnQueueMember member);

        public ITurnQueueMember MoveNext();
    }
}
