using System.Collections.Generic;
using IUP.Toolkits.Matrices;
using UnityEngine;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public sealed class BattleArena : IBattleArena
    {
        public BattleArena(int width, int height, IBattleEventBus eventBus)
        {
            _arena = new Matrix<ICell>(width, height);
            _arena.InitAllElements((int x, int y) => new Cell(this, x, y));
            _eventBus = eventBus;
            _eventBus.RegisterEventCallback(
                (EntityDestroyedContext context) =>
                RemoveEntityFromCell(context.Entity.Position, context.Entity));
        }

        public int Width => _arena.Width;
        public int Height => _arena.Height;
        public IReadOnlyCollection<ICellEntity> Entities => _entities;

        private readonly Matrix<ICell> _arena;
        private readonly HashSet<ICellEntity> _entities = new();
        private readonly IBattleEventBus _eventBus;

        public ICell this[Vector2Int coordinate] => this[coordinate.x, coordinate.y];

        public ICell this[int x, int y] =>
            _arena.IsCoordinateInDefinitionDomain(x, y) ? _arena[x, y] : InstantiateBeyondCell(x, y);

        public void SetEntityOnCell(int x, int y, ICellEntity entity)
        {
            _ = this[x, y].PutEntity(entity);
            _ = _entities.Add(entity);
        }

        public void SetEntityOnCell(Vector2Int position, ICellEntity entity) =>
            SetEntityOnCell(position.x, position.y, entity);

        public void RemoveEntityFromCell(int x, int y, ICellEntity entity)
        {
            _ = this[x, y].RemoveEntity(entity);
            _ = _entities.Remove(entity);
        }

        public void RemoveEntityFromCell(Vector2Int position, ICellEntity entity) =>
            RemoveEntityFromCell(position.x, position.y, entity);

        /// <summary>
        /// Создаёт экземпляр специальной клетки, находящейся вне области определения матрицы боевой арены.
        /// </summary>
        /// <param name="x">X-компонента координаты клетки.</param>
        /// <param name="y">Y-компонента координаты клетки.</param>
        /// <returns></returns>
        private Cell InstantiateBeyondCell(int x, int y)
        {
            var beyondCell = new Cell(this, x, y);
            var beyond = new Beyond(x, y, this, beyondCell);
            beyondCell.PutEntity(beyond);
            return beyondCell;
        }
    }
}
