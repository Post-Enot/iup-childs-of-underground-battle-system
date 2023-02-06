using IUP.Toolkits.CellarMaps;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Интерфейс контекста боевой сцены.
    /// </summary>
    public interface IBattleContext
    {
        /// <summary>
        /// Паттерн боевой арены.
        /// </summary>
        public IReadOnlyCellarMap ArenaPattern { get; }
        /// <summary>
        /// Сценарий боевой сцены.
        /// </summary>
        public IBattleScript BattleScript { get; }
    }
}
