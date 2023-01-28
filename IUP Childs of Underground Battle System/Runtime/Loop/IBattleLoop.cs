namespace IUP.ChildsOfUnderground.BattleSystem
{
    public interface IBattleLoop
    {
        /// <summary>
        /// True, ���� ������ ���� �������.
        /// </summary>
        public bool IsIterating { get; }

        /// <summary>
        /// ��������� �������� ������� �����.
        /// </summary>
        public void StartIteration();

        /// <summary>
        /// ��������� �������� ������� �����.
        /// </summary>
        public void StopIteration();
    }
}
