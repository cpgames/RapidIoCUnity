using UnityEngine;

namespace cpGames.core.RapidIoC.examples.invadersExample.game
{
    public class EnemyBoltView : EntityView
    {
        #region Properties
        [Inject] public PlayerHitSignal PlayerHitSignal { get; set; }
        #endregion

        #region Listeners
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                PlayerHitSignal.Dispatch(other.transform.FindFirstParent<IPlayer>());
            }
        }
        #endregion
    }
}