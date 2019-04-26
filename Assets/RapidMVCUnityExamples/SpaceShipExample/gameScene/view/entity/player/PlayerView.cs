using System;
using UnityEngine;

namespace cpGames.core.RapidMVC.examples.invadersExample.game
{
    [Serializable]
    public class Boundary
    {
        #region Fields
        public float xMin, xMax, zMin, zMax;
        #endregion
    }

    public class PlayerView : EntityView, IPlayer
    {
        #region Fields
        public float speed;
        public float tilt;
        public Boundary boundary;
        public PlayerBoltView shot;
        public Transform shotSpawn;
        public float fireRate;

        private float _nextFire;
        #endregion

        #region Properties
        [Inject("EntityRoot")] public GameObject EntityRoot { get; set; }
        [Inject] public GameOverSignal GameOverSignal { get; set; }
        #endregion

        #region Methods
        private void Update()
        {
            if (Input.GetButton("Fire1") && Time.time > _nextFire)
            {
                _nextFire = Time.time + fireRate;
                EntityRoot.AddChild(shot, shotSpawn.position, shotSpawn.rotation, Vector3.one);
                GetComponent<AudioSource>().Play();
            }
        }

        private void FixedUpdate()
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");

            var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            GetComponent<Rigidbody>().velocity = movement * speed;

            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );

            GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
        }

        public override void Kill(bool explode)
        {
            base.Kill(explode);
            GameOverSignal.Dispatch();
        }
        #endregion
    }
}