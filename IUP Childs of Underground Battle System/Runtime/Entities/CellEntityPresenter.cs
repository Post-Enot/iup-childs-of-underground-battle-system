using UnityEngine;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Абстрактный класс Unity-представления клеточной сущности.
    /// </summary>
    public abstract class CellEntityPresenter : MonoBehaviour, ICellEntityPresenter
    {
        public abstract ICellEntity Entity { get; }

        public abstract void Init(
            IBattleArenaPresenter battleArenaPresenter,
            IBattleEventBus eventBus,
            Vector2Int coordinate);

        public abstract void Init(
            IBattleArenaPresenter battleArenaPresenter,
            IBattleEventBus eventBus,
            int x,
            int y);
    }
}
