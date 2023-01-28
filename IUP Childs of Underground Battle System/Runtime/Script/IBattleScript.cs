namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Сценарий сражения. Отвечает за этапы боя, а также его завершение.
    /// </summary>
    public interface IBattleScript
    {
        /// <summary>
        /// True, если сценарий боя запущен.
        /// </summary>
        public bool IsPerformed { get; }

        /// <summary>
        /// Инициирует зависимости, необходимые сценарию боя.
        /// </summary>
        /// <param name="battleLoop">Ссылка на класс боевого цикла.</param>
        /// <param name="eventBus">Ссылка на шину событий боя.</param>
        /// <param name="arenaPresenter">Ссылка на Unity-представление боевой арены.</param>
        /// <param name="entitySpawner">Ссылка на класс-спавнер сущностей.</param>
        public void Init(
            IBattleLoop battleLoop,
            IBattleEventBus eventBus,
            IBattleArenaPresenter arenaPresenter,
            IEntitySpawner entitySpawner);

        /// <summary>
        /// Запускает сценарий боевой сцены.
        /// </summary>
        public void Start();
    }
}
