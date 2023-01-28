namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Контекст события спавна сущности-участника очереди ходов боевого цикла.
    /// </summary>
    public sealed class SpawnTurnQueueMemberContext : BattleEventContext
    {
        public SpawnTurnQueueMemberContext(ITurnQueueMember turnQueueMember)
        {
            Member = turnQueueMember;
        }

        public ITurnQueueMember Member { get; }
    }
}
