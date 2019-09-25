using UnityEngine;

namespace cpGames.core.RapidIoC.examples.invadersExample.game
{
    public class EnemyWeaponView : ComponentView
    {
        #region Fields
        public EnemyBoltView shot;
        public Transform shotSpawn;
        public float fireRate;
        public float delay;
        #endregion

        #region Properties
        [Inject("EntityRoot")] public GameObject EntityRoot { get; set; }
        #endregion

        #region Methods
        private void Start()
        {
            InvokeRepeating("Fire", delay, fireRate);
        }

        private void Fire()
        {
            EntityRoot.AddChild(shot, shotSpawn.position, shotSpawn.rotation, Vector3.one);
            GetComponent<AudioSource>().Play();
        }
        #endregion
    }
}