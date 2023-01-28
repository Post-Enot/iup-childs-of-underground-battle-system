namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Контекст события уничтожения сущности.
    /// </summary>
    public sealed class EntityDestroyedContext : BattleEventContext
    {
        public EntityDestroyedContext(ICellEntity entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// Ссылка на уничтоженную сущность.
        /// </summary>
        public ICellEntity Entity { get; }
    }
}
