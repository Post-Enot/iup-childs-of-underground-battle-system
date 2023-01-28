using System;
using UnityEngine;
using IUP.Toolkits;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Абстрактный класс-основа для спавнера сущностей.
    /// </summary>
    public sealed class EntitySpawner : MonoBehaviour, IEntitySpawner
    {
        [SerializeField] private GameObject _emptyCellEntityPrefab;
        [SerializeField] private SDictionary<string, GameObject> _entityPrefabs;

        public ICellEntityPresenter SpawnEntityByMappingKey(
            string mappingKey,
            IBattleArenaPresenter battleArenaPresenter,
            IBattleEventBus eventBus,
            Vector2Int coordinate) => SpawnEntityByMappingKey(
                mappingKey,
                battleArenaPresenter,
                eventBus,
                coordinate.x,
                coordinate.y);

        public ICellEntityPresenter SpawnEntityByMappingKey(
            string mappingKey,
            IBattleArenaPresenter battleArenaPresenter,
            IBattleEventBus eventBus,
            int x,
            int y)
        {
            GameObject entityPrefab;
            if (mappingKey == null)
            {
                entityPrefab = _emptyCellEntityPrefab;
            }
            else
            {
                if (!_entityPrefabs.Value.ContainsKey(mappingKey))
                {
                    throw new ArgumentException($"Ключ сопоставления {mappingKey}, переданный аргументом " +
                        $"{nameof(mappingKey)} не найден.");
                }
                entityPrefab = _entityPrefabs.Value[mappingKey];
            }
            return SpawnEntity(entityPrefab, battleArenaPresenter, eventBus, x, y);
        }

        private ICellEntityPresenter SpawnEntity(
            GameObject entityPrefab,
            IBattleArenaPresenter battleArenaPresenter,
            IBattleEventBus eventBus,
            int x,
            int y)
        {
            GameObject entityObject = Instantiate(entityPrefab);
            var entityPresenter = entityObject.GetComponent<ICellEntityPresenter>();
            entityPresenter.Init(battleArenaPresenter, eventBus, x, y);
            battleArenaPresenter.SetEntityOnCell(entityPresenter, x, y);
            if (entityPresenter is ITurnQueueMember member)
            {
                SpawnTurnQueueMemberContext context = new(member);
                eventBus.InvokeEventCallbacks(context);
            }
            return entityPresenter;
        }
    }
}
