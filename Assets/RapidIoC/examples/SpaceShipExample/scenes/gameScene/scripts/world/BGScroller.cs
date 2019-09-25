using UnityEngine;

namespace cpGames.core.RapidIoC.examples.invadersExample.game
{
    public class BGScroller : MonoBehaviour
    {
        #region Fields
        public float scrollSpeed;
        public float tileSizeZ;

        private Vector3 startPosition;
        #endregion

        #region Methods
        private void Start()
        {
            startPosition = transform.position;
        }

        private void Update()
        {
            var newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
            transform.position = startPosition + Vector3.forward * newPosition;
        }
        #endregion
    }
}