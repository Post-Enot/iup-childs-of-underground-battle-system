using UnityEngine;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Интерфейс Unity-представления клеточной сущности.
    /// </summary>
    public interface ICellEntityPresenter
    {
        /// <summary>
        /// Ссылка на модель сущности.
        /// </summary>
        public ICellEntity Entity { get; }
#pragma warning disable IDE1006 // Стили именования
        /// <summary>
        /// Ссылка на transform Unity-представления клеточной сущности.
        /// </summary>
        public Transform transform { get; }
#pragma warning restore IDE1006 // Стили именования

        /// <summary>
        /// Инициализирует зависимости Unity-представления сущности.
        /// </summary>
        /// <param name="battleArenaPresenter"></param>
        /// <param name="eventBus"></param>
        /// <param name="coordinate"></param>
        public void Init(
            IBattleArenaPresenter battleArenaPresenter,
            IBattleEventBus eventBus,
            Vector2Int coordinate);

        /// <summary>
        /// Инициализирует зависимости Unity-представления сущности.
        /// </summary>
        /// <param name="battleArenaPresenter"></param>
        /// <param name="eventBus"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Init(
            IBattleArenaPresenter battleArenaPresenter,
            IBattleEventBus eventBus,
            int x,
            int y);
    }
}
