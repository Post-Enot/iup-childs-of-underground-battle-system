using System.Collections.Generic;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public interface IReadonlyTagSet : IEnumerable<string>
    {
        /// <summary>
        /// Проверяет наличие тега в наборе.
        /// </summary>
        /// <param name="tag">Проверяемый тег.</param>
        /// <returns>Возвращает true, если тег присутствует в наборе; иначе false.</returns>
        public bool HasTag(string tag);
    }
}
