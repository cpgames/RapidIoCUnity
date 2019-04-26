using System.Collections;
using UnityEngine;

namespace cpGames.core.RapidMVC.examples.invadersExample.game
{
    // GameView handles some of the game state logic
    // It is recommended to keep this fairly light and handle the grunt of game logic via Commands for better code organization and encapsulation
    public class GameView : ComponentView
    {
        #region Fields
        public PlayerView playerPrefab;
        public EnemyView[] enemyPrefabs;
        public Vector3 spawnValues;
        public int hazardCount;
        public float spawnWait;
        public float startWait;
        public float waveWait;

        private bool _gameOver;
        #endregion

        #region Properties
        // Root gameobject where entities spawn (for cleaner scene hierarchy)
        [Inject("EntityRoot")] public GameObject EntityRoot { get; set; }
        // We listen to this to know when to start new game
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        // We listen to this to know when game is over
        [Inject] public GameOverSignal GameOverSignal { get; set; }
        // We dispatch this to restart a game
        [Inject] public RestartSignal RestartSignal { get; set; }
        #endregion

        #region Listeners
        public void OnStartGame()
        {
            StartGame();
        }

        public void OnGameOver()
        {
            StopGame();
        }

        public void OnRestart()
        {
            RestartGame();
        }
        #endregion

        #region Methods
        private void StartGame()
        {
            EntityRoot.AddChild(playerPrefab);
            StartCoroutine(SpawnWaves());
        }

        private void StopGame()
        {
            _gameOver = true;
        }

        private void RestartGame()
        {
            EntityRoot.DeleteChildren();
            _gameOver = false;
            StartGameSignal.Dispatch();
        }

        private IEnumerator SpawnWaves()
        {
            yield return new WaitForSeconds(startWait);
            while (!_gameOver)
            {
                for (var i = 0; i < hazardCount; i++)
                {
                    var enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                    var spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    var spawnRotation = Quaternion.identity;
                    EntityRoot.AddChild(enemyPrefab, spawnPosition, spawnRotation, Vector3.one);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
        #endregion
    }
}