using System.Collections.Generic;
using UnityEngine;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public sealed class Cell : ICell
    {
        public Cell(IBattleArena battleArena, Vector2Int position)
        {
            BattleArena = battleArena;
            Position = position;
        }

        public Cell(IBattleArena battleArena, int x, int y)
        {
            BattleArena = battleArena;
            Position = new Vector2Int(x, y);
        }

        public IReadOnlyCollection<ICellEntity> Entities => _entities;
        public IBattleArena BattleArena { get; }
        public Vector2Int Position { get; }

        private readonly HashSet<ICellEntity> _entities = new();
        private readonly HashSet<ICanPutEntityEventReceiver> _canPutEntityEventReceivers = new();
        private readonly HashSet<IPutEntityEventReceiver> _putEntityEventReceivers = new();
        private readonly HashSet<IRemoveEntityEventReceiver> _removeEntityEventReceivers = new();

        public bool CanPutEntity(ICellEntity entity)
        {
            foreach (ICanPutEntityEventReceiver receiver in _canPutEntityEventReceivers)
            {
                if (!receiver.OnCanPutEntity(entity))
                {
                    return false;
                }
            }
            return true;
        }

        public bool PutEntity(ICellEntity entity)
        {
            bool result = false;
            if (CanPutEntity(entity))
            {
                _entities.Add(entity);
                if (entity is ICanPutEntityEventReceiver canPutEntityEventReceiver)
                {
                    _canPutEntityEventReceivers.Add(canPutEntityEventReceiver);
                }
                if (entity is IPutEntityEventReceiver putEntityEventReceiver)
                {
                    _putEntityEventReceivers.Add(putEntityEventReceiver);
                }
                if (entity is IRemoveEntityEventReceiver removeEntityEventReceiver)
                {
                    _removeEntityEventReceivers.Add(removeEntityEventReceiver);
                }
                result = true;
            }
            foreach (IPutEntityEventReceiver receiver in _putEntityEventReceivers)
            {
                receiver.OnPutEntity(entity);
            }
            return result;
        }

        public bool RemoveEntity(ICellEntity entity)
        {
            bool result = _entities.Remove(entity);
            foreach (IRemoveEntityEventReceiver receiver in _removeEntityEventReceivers)
            {
                receiver.OnRemoveEntity(entity);
            }
            _ = _canPutEntityEventReceivers.Remove(entity as ICanPutEntityEventReceiver);
            _ = _putEntityEventReceivers.Remove(entity as IPutEntityEventReceiver);
            _ = _removeEntityEventReceivers.Remove(entity as IRemoveEntityEventReceiver);
            return result;
        }

        public TEntity TryGetEntity<TEntity>() where TEntity : ICellEntity
        {
            foreach (ICellEntity entity in _entities)
            {
                if (entity is TEntity wantedEntity)
                {
                    return wantedEntity;
                }
            }
            return default;
        }

        public List<TEntity> TryGetEntities<TEntity>() where TEntity : ICellEntity
        {
            List<TEntity> wantedEntities = new();
            foreach (ICellEntity entity in _entities)
            {
                if (entity is TEntity wantedEntity)
                {
                    wantedEntities.Add(wantedEntity);
                }
            }
            return wantedEntities;
        }
    }
}
