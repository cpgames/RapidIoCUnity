namespace cpGames.core.RapidMVC.examples.invadersExample.game
{
    // Enemy interface that rewards player with score points when killed
    public interface IEnemy : IEntity
    {
        #region Properties
        int Score { get; }
        #endregion
    }
}