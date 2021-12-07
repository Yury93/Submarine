using UnityEngine;

namespace Bounce
{
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// Префаб игрока
        /// </summary>
        [SerializeField] private GameObject prefabPlayer;
        /// <summary>
        /// Игрок на сцене
        /// </summary>
        private GameObject player;
        public GameObject PlayerGO => player;

        [SerializeField] private SyncTransform camera;
        void Start()
        {
            Respawn();
        }
        private void Update()
        {
            if (camera.Target == null)
            {
                Respawn();
            }
        }
        private void Respawn()
        {
            MenuController.Instance.RestartButton();
            player = Instantiate(prefabPlayer, transform.position, Quaternion.identity);
            camera.SetTarget(player);

            if (player.GetComponent<Destructible>())
            {
                PlayerMetrics.Instance.Lives.text = player.GetComponent<Destructible>().CurrentLives.ToString();
                PlayerMetrics.Instance.ResetScore();
            }
        }
    }
}