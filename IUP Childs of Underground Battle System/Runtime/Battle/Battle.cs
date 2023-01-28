using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public sealed class Battle : MonoBehaviour, IBattle
    {
        [Header("Temporary:")]
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private float _minTurnDurationInSecond;

        [Header("Events:")]
        [SerializeField] private UnityEvent _inited;
        [SerializeField] private UnityEvent _started;

        public IBattleEventBus EventBus => _eventBus;
        public IBattleArenaPresenter ArenaPresenter { get; private set; }
        public bool IsStarted => _battleScript.IsPerformed;

        public event Action Inited;
        public event Action Started;

        private IBattleScript _battleScript;
        private IBattleArenaGenerator _arenaGenerator;
        private IBattleLoop _battleLoop;
        private IEntitySpawner _entitySpawner;
        private BattleEventBus _eventBus;
        private Transform _entitiesRoot;

        private void Awake()
        {
            _eventBus = new BattleEventBus();
        }

        public void Init(IBattleContext battleContext)
        {
            _entitySpawner = GetComponent<IEntitySpawner>();
            _arenaGenerator = new BattleArenaGenerator(_entitySpawner);
            _entitiesRoot = InstantiateEntitiesRoot();
            _battleLoop = new BattleLoop(_eventBus, this, _minTurnDurationInSecond);
            ArenaPresenter = _arenaGenerator.Generate(
                battleContext.ArenaPattern.CellarMap,
                _eventBus,
                _entitiesRoot,
                _tilemap);
            _battleScript = battleContext.BattleScript;
            _battleScript.Init(_battleLoop, _eventBus, ArenaPresenter, _entitySpawner);
            Inited?.Invoke();
            _inited.Invoke();
        }

        public void StartBattleScript()
        {
            _battleScript.Start();
            _started.Invoke();
            Started?.Invoke();
        }

        private Transform InstantiateEntitiesRoot()
        {
            var entitiesRootObject = new GameObject("Entities Root");
            entitiesRootObject.transform.parent = transform;
            return entitiesRootObject.transform;
        }
    }
}
