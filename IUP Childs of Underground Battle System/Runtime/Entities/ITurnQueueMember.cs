using System.Collections;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Интерфейс клеточной сущности, участвующей в очереди ходов.
    /// </summary>
    public interface ITurnQueueMember
    {
        /// <summary>
        /// Приоритет хода. В первую очередь ходят сущности с самым высоким значением приоритета.
        /// </summary>
        public int TurnPriority { get; }

        /// <summary>
        /// Метод-корутина, вызываемая при совершении сущностью хода в боевом цикле.
        /// </summary>
        public IEnumerator MakeTurn();
    }
}
