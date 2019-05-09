using UnityEngine;

namespace cpGames.core.RapidIoC.examples.invadersExample.game
{
    public class BoundaryController : MonoBehaviour
    {
        #region Listeners
        private void OnTriggerExit(Collider other)
        {
            other.transform.FindFirstParent<IEntity>().Kill(false);
        }
        #endregion
    }
}