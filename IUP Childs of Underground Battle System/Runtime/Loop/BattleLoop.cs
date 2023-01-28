using IUP.Toolkits.CoroutineShells;
using System.Collections;
using UnityEngine;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public sealed class BattleLoop : IBattleLoop
    {
        public BattleLoop(
            IBattleEventBus eventBus,
            MonoBehaviour coroutinePerformer,
            float minTurnDurationInSecond)
        {
            _eventBus = eventBus;
            _eventBus.RegisterEventCallback<SpawnTurnQueueMemberContext>(AddMemberInTurnQueue);
            MinTurnDurationInSecond = minTurnDurationInSecond;
            _iterationRoutine = new CoroutineShell(coroutinePerformer, Iteration);
        }

        public bool IsIterating { get; private set; }
        public float MinTurnDurationInSecond { get; }

        private readonly TurnQueue _turnQueue = new();
        private readonly CoroutineShell _iterationRoutine;
        private readonly IBattleEventBus _eventBus;

        public void StartIteration()
        {
            IsIterating = true;
            _eventBus.InvokeEventCallbacks(GeneralBattleEvents.BattleLoopIterationStarted);
            if (_turnQueue.MembersCount == 0)
            {
                return;
            }
            _iterationRoutine.Start();
        }

        public void StopIteration()
        {
            if (IsIterating)
            {
                if (_iterationRoutine.IsPerformed)
                {
                    _iterationRoutine.Stop();
                }
                _eventBus.InvokeEventCallbacks(GeneralBattleEvents.BattleLoopIterationStopped);
            }
        }

        private IEnumerator Iteration()
        {
            while (_turnQueue.MembersCount != 0)
            {
                float turnStartTime = Time.time;
                yield return _turnQueue.CurrentMember.MakeTurn();
                _ = _turnQueue.MoveNext();
                float timeSpentPerTurn = Time.time - turnStartTime;
                float pauseDurationInSecond = MinTurnDurationInSecond - timeSpentPerTurn;
                if (pauseDurationInSecond > 0)
                {
                    yield return new WaitForSeconds(pauseDurationInSecond);
                }
            }
        }

        private void AddMemberInTurnQueue(SpawnTurnQueueMemberContext context)
        {
            _turnQueue.AddMember(context.Member);
            if (IsIterating && _turnQueue.MembersCount == 1 && !_iterationRoutine.IsPerformed)
            {
                _iterationRoutine.Start();
            }
        }
    }
}
