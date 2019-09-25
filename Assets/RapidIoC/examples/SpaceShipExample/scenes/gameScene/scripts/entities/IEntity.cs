namespace cpGames.core.RapidIoC.examples.invadersExample.game
{
    // Base game entity interface (this is any object that can be killed)
    public interface IEntity
    {
        #region Methods
        void Kill(bool explode);
        #endregion
    }
}