using System;
using System.Collections.Generic;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public sealed class BattleEventBus : IBattleEventBus
    {
        private readonly Dictionary<Type, List<object>> _callbacksWithContext = new();
        private readonly Dictionary<string, List<Action>> _callbacksWithoutContext = new();

        public void RegisterEventCallback<T>(Action<T> callback) where T : BattleEventContext
        {
            Type callbackType = typeof(T);
            if (!_callbacksWithContext.ContainsKey(callbackType))
            {
                _callbacksWithContext.Add(callbackType, new List<object>());
            }
            _callbacksWithContext[callbackType].Add(callback);
        }

        public void RegisterEventCallback(string eventName, Action callback)
        {
            if (!_callbacksWithoutContext.ContainsKey(eventName))
            {
                _callbacksWithoutContext.Add(eventName, new List<Action>());
            }
            _callbacksWithoutContext[eventName].Add(callback);
        }

        public bool UnregisterEventCallback<T>(Action<T> callback) where T : BattleEventContext
        {
            Type callbackType = typeof(T);
            if (_callbacksWithContext.ContainsKey(callbackType))
            {
                return _callbacksWithContext[callbackType].Remove(callback);
            }
            return false;
        }

        public bool UnregisterEventCallback(string eventName, Action callback)
        {
            if (_callbacksWithoutContext.ContainsKey(eventName))
            {
                return _callbacksWithoutContext[eventName].Remove(callback);
            }
            return false;
        }

        public void InvokeEventCallbacks<T>(T context) where T : BattleEventContext
        {
            Type callbackType = typeof(T);
            if (_callbacksWithContext.ContainsKey(callbackType))
            {
                foreach (object callback in _callbacksWithContext[callbackType])
                {
                    (callback as Action<T>)(context);
                }
            }
        }

        public void InvokeEventCallbacks(string eventName)
        {
            if (_callbacksWithoutContext.ContainsKey(eventName))
            {
                foreach (Action callback in _callbacksWithoutContext[eventName])
                {
                    callback();
                }
            }
        }
    }
}
