using UnityEngine;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Интерфейс клеточной сущности, размещаемой на клетках боевой арены.
    /// </summary>
    public interface ICellEntity
    {
        /// <summary>
        /// Координата сущности.
        /// </summary>
        public Vector2Int Position { get; }
        /// <summary>
        /// Ссылка на клетку, на которой в данный момент расположена сущность.
        /// </summary>
        public ICell Cell { get; }
        /// <summary>
        /// Боевая арена, на которой в данный момент расположена сущность.
        /// </summary>
        public IBattleArena BattleArena { get; }
        /// <summary>
        /// Readonly-набор тегов сущности.
        /// </summary>
        public IReadonlyTagSet Tags { get; }
    }
}
