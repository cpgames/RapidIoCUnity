using UnityEngine;

namespace cpGames.core.RapidIoC.examples.invadersExample.game
{
    public class RandomRotator : MonoBehaviour
    {
        #region Fields
        public float tumble;
        #endregion

        #region Methods
        private void Start()
        {
            GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        }
        #endregion
    }
}