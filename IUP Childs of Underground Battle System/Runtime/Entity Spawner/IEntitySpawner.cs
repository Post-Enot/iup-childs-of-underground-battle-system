using UnityEngine;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Интерфейс класса, отвечающего за инициализацию сущности.
    /// </summary>
    public interface IEntitySpawner
    {
        /// <summary>
        /// Инициализирует и возвращает представление сущности по ключу сопоставления.
        /// </summary>
        /// <param name="mappingKey">Ключ сопоставления сущности.</param>
        /// <param name="battleArenaPresenter">Представление боевой арены, на которой 
        /// инициализируется сущность.</param>
        /// <param name="eventBus">Ссылка на шину событий боевой арены.</param>
        /// <param name="coordinate">Координата клетки, на которой инициализируется сущность.</param>
        /// <returns></returns>
        public ICellEntityPresenter SpawnEntityByMappingKey(
            string mappingKey,
            IBattleArenaPresenter battleArenaPresenter,
            IBattleEventBus eventBus,
            Vector2Int coordinate);

        /// <summary>
        /// Инициализирует и возвращает представление сущности по ключу сопоставления.
        /// </summary>
        /// <param name="mappingKey">Ключ сопоставления сущности.</param>
        /// <param name="battleArenaPresenter">Представление боевой арены, на которой 
        /// инициализируется сущность.</param>
        /// <param name="eventBus">Ссылка на шину событий боевой арены.</param>
        /// <param name="x">X-компонента координаты клетки, на которой инициализируется сущность.</param>
        /// <param name="y">Y-компонента координаты клетки, на которой инициализируется сущность.</param>
        /// <returns>Возвращает ссылку на интерфейс представления сущности.</returns>
        public ICellEntityPresenter SpawnEntityByMappingKey(
            string mappingKey,
            IBattleArenaPresenter battleArenaPresenter,
            IBattleEventBus eventBus,
            int x,
            int y);
    }
}
