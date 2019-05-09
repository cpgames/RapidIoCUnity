using UnityEngine;

namespace cpGames.core.RapidIoC.examples.invadersExample.game
{
    public class EntityView : ComponentView, IEntity
    {
        #region Fields
        public GameObject explosion;
        #endregion

        #region IEntity Members
        public virtual void Kill(bool explode)
        {
            if (explode && explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
        #endregion
    }
}