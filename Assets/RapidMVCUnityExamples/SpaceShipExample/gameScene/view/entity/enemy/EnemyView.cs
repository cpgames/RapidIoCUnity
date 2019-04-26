using UnityEngine;

namespace cpGames.core.RapidMVC.examples.invadersExample.game
{
    public abstract class EnemyView : EntityView, IEnemy
    {
        #region Fields
        [SerializeField]
        private int _score;
        #endregion

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

        #region IEnemy Members
        public int Score => _score;
        #endregion
    }
}