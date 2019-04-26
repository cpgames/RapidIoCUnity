using UnityEngine;

namespace cpGames.core.RapidMVC.examples.invadersExample.game
{
    public class PlayerBoltView : EntityView
    {
        #region Properties
        [Inject] public EnemyHitSignal EnemyHitSignal { get; set; }
        #endregion

        #region Listeners
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy")
            {
                EnemyHitSignal.Dispatch(other.transform.FindFirstParent<IEnemy>());
            }
        }
        #endregion
    }
}