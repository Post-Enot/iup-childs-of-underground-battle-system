using System.Collections.Generic;
using UnityEngine;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Интерфейс модели боевой арены.
    /// </summary>
    public interface IBattleArena
    {
        /// <summary>
        /// Ширина боевой арены в клетках.
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// Высота боевой арены в клетках.
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// Readonly-коллекция всех сущностей, находящихся на боевом поле.
        /// </summary>
        public IReadOnlyCollection<ICellEntity> Entities { get; }

        /// <summary>
        /// Индексатор для доступа к клеткам боевой арены.
        /// </summary>
        /// <param name="position">Координата клетки.</param>
        /// <returns>Возвращает ссылку на клетку по координатам, если координата находит в области 
        /// определения матрицы боевой арены; иначе возвращает ссылку на специальную клетку вне границ.</returns>
        public ICell this[Vector2Int position] { get; }

        /// <summary>
        /// Индексатор для доступа к клеткам боевой арены.
        /// </summary>
        /// <param name="x">X-компонента координаты клетки.</param>
        /// <param name="y">Y-компонента координаты клетки.</param>
        /// <returns>Возвращает ссылку на клетку по координатам, если координата находит в области 
        /// определения матрицы боевой арены; иначе возвращает ссылку на специальную клетку вне границ.</returns>
        public ICell this[int x, int y] { get; }
    }
}
