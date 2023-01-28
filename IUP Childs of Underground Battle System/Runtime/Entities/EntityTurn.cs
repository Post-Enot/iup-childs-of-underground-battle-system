using System;
using System.Collections;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public sealed class EntityTurn : IEnumerator
    {
        public EntityTurn(Func<IEnumerator> getRoutine)
        {
            _getRoutine = getRoutine;
            _routine = getRoutine();
        }

        private readonly Func<IEnumerator> _getRoutine;
        private IEnumerator _routine;

        public object Current => _routine.Current;

        public bool MoveNext()
        {
            return _routine.MoveNext();
        }

        public void Reset()
        {
            _routine = _getRoutine();
        }
    }
}
