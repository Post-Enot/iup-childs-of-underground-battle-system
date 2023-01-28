using IUP.Toolkits.CellarMaps;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public class BattleContext : IBattleContext
    {
        /// <summary>
        /// Конструктор контекста боевой сцены.
        /// </summary>
        /// <param name="battleArenaPattern">Паттерн боевой арены.</param>
        /// <param name="battleScript">Сценарий боевой сцены.</param>
        public BattleContext(
            CellarMapAsset battleArenaPattern,
            IBattleScript battleScript)
        {
            ArenaPattern = battleArenaPattern;
            BattleScript = battleScript;
        }

        public CellarMapAsset ArenaPattern { get; }
        public IBattleScript BattleScript { get; }
    }
}
