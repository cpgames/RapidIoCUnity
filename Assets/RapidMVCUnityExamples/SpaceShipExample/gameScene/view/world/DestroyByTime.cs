using UnityEngine;

namespace cpGames.core.RapidMVC.examples.invadersExample.game
{
    public class DestroyByTime : MonoBehaviour
    {
        #region Fields
        public float lifetime;
        #endregion

        #region Methods
        private void Start()
        {
            Destroy(gameObject, lifetime);
        }
        #endregion
    }
}