using UnityEngine;

namespace cpGames.core.RapidIoC.examples.invadersExample.game
{
    public class Mover : MonoBehaviour
    {
        #region Fields
        public float speed;
        #endregion

        #region Methods
        private void Start()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
        #endregion
    }
}