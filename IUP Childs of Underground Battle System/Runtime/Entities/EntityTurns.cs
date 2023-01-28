using System;
using System.Collections;
using UnityEngine;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public sealed class EntityTurns
    {
        public EntityTurns(EntityTurn foveRoutine, int turnsCount = 1)
        {
            _foveRoutine = foveRoutine;
            _turnsCount = turnsCount;
        }

        public int TurnsLeft { get; set; }
        public int TurnsCount
        {
            get => _turnsCount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Количество ходов сущности не " +
                        "может быть меньше 0.");
                }
                _turnsCount = value;
            }
        }

        public event Action<int> TurnCompleted;

        private readonly EntityTurn _foveRoutine;
        private EntityTurn _turn;
        private int _turnsCount;

        public IEnumerator MakeTurn()
        {
            TurnsLeft = TurnsCount;
            _foveRoutine.Reset();
            _turn = _foveRoutine;
            while (TurnsLeft > 0)
            {
                while (_turn.MoveNext())
                {
                    yield return _turn.Current;
                }
                TurnCompleted?.Invoke(TurnsLeft);
            }
        }

        public void SetTurnRoutine(EntityTurn turn)
        {
            _turn = turn;
        }

        public void ReturnToFoveRoutine()
        {
            _turn = _foveRoutine;
        }
    }
}
