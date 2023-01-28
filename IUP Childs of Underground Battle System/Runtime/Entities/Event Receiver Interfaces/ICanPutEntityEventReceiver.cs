namespace IUP.ChildsOfUnderground.BattleSystem
{
    /// <summary>
    /// Нужно переименовать, чтобы по названию можно было понять, что это не столько обработка события, 
    /// сколько участие в процессе определения, можно ли поставить клетку или нет.
    /// </summary>
    public interface ICanPutEntityEventReceiver
    {
        public bool OnCanPutEntity(ICellEntity entity);
    }
}
