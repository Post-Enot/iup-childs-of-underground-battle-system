using IUP.Toolkits.CellarMaps;
using UnityEngine;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public interface IBattleArenaGenerator
    {
        /// <summary>
        /// Ссылка на спавнер сущностей, используемый при генерации боевой арены.
        /// </summary>
        public IEntitySpawner EntitySpawner { get; }

        /// <summary>
        /// Генерирует боевую арену на основе паттерна.
        /// </summary>
        /// <param name="arenaPattern">Паттерн боевой арены.</param>
        /// <param name="entitiesRoot">Корневой transform иерархии для сущностей боевой арены.</param>
        /// <returns></returns>
        public IBattleArenaPresenter Generate(
            IReadOnlyCellarMap arenaPattern,
            IBattleEventBus eventBus,
            Transform entitiesRoot,
            Grid grid);
    }
}
