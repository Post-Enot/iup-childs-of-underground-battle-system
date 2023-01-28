using System;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Интерфейс класса логики боевой сцены.
    /// </summary>
    public interface IBattle
    {
        public event Action Inited;

        /// <summary>
        /// Запускает логику боевой сцены, используя переданный контекст.
        /// </summary>
        /// <param name="battleContext">Контекст боевой сцены.</param>
        public void Init(IBattleContext battleContext);

        /// <summary>
        /// Запускает выполнение сценария боя.
        /// </summary>
        public void StartBattleScript();
    }
}
