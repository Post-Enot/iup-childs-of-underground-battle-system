using System.Collections.Generic;
using UnityEngine;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public interface ICell
    {
        public IReadOnlyCollection<ICellEntity> Entities { get; }
        public IBattleArena BattleArena { get; }
        public Vector2Int Position { get; }

        public bool CanPutEntity(ICellEntity entity);

        public bool PutEntity(ICellEntity entity);

        public bool RemoveEntity(ICellEntity entity);

        public TEntity TryGetEntity<TEntity>() where TEntity : ICellEntity;

        public List<TEntity> TryGetEntities<TEntity>() where TEntity : ICellEntity;
    }
}
