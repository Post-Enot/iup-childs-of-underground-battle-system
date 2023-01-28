using System;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Интерфейс шины событий боевой арены.
    /// </summary>
    public interface IBattleEventBus
    {
        /// <summary>
        /// Регистрирует обратный вызов на событие, определеяемое через возвращаемый контекст.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого контекста события.</typeparam>
        /// <param name="callback">Функция обратного вызова, принимающая в качестве аргумента 
        /// контекст события.</param>
        public void RegisterEventCallback<T>(Action<T> callback) where T : BattleEventContext;

        /// <summary>
        /// Регистрирует обратный вызов на событие, определяемое по названию.
        /// </summary>
        /// <param name="eventName">Название события.</param>
        /// <param name="callback">Функция обратного вызова.</param>
        public void RegisterEventCallback(string eventName, Action callback);

        /// <summary>
        /// Удаляет регистрацию обратного вызова на событие, определяемое через возвращаемый контекст.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого контекста события.</typeparam>
        /// <param name="callback">Функция обратного вызова, принимающая в качестве аргумента 
        /// контекст события.</param>
        /// <returns>Возвращает true в случае обнаружения и успешного удаления обратного вызова; 
        /// иначе false.</returns>
        public bool UnregisterEventCallback<T>(Action<T> callback) where T : BattleEventContext;

        /// <summary>
        /// Удаляет регистрацию обратного вызова на событие, определяемое по названию.
        /// </summary>
        /// <param name="eventName">Название события.</param>
        /// <param name="callback">Функция обратного вызова.</param>
        /// <returns>Возвращает true в случае обнаружения и успешного удаления обратного вызова; 
        /// иначе false.</returns>
        public bool UnregisterEventCallback(string eventName, Action callback);

        /// <summary>
        /// Инициирует вызов всех зарегистрированных функций на событие, определяемое через передаваемый контекст.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого контекста события.</typeparam>
        /// <param name="context">Контекст вызываемого события.</param>
        public void InvokeEventCallbacks<T>(T context) where T : BattleEventContext;

        /// <summary>
        /// Инициирует вызов всех зарегистрированных функций на событие, определяемое по названию.
        /// </summary>
        /// <param name="eventName">Название события.</param>
        public void InvokeEventCallbacks(string eventName);
    }
}
