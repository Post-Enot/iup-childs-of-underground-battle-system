namespace IUP.ChildsOfUnderground.BattleSystem
{
    public interface IBattleLoop
    {
        /// <summary>
        /// True, если боевой цикл запущен.
        /// </summary>
        public bool IsIterating { get; }

        /// <summary>
        /// «апускает итерацию боевого цикла.
        /// </summary>
        public void StartIteration();

        /// <summary>
        /// ѕрерывает итерацию боевого цикла.
        /// </summary>
        public void StopIteration();
    }
}
