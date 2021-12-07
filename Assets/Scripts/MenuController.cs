using UnityEngine;


namespace Bounce
{
    public class MenuController : SingletonBase<MenuController>
    {
        [SerializeField] private GameObject startButton;
        [SerializeField] private GameObject restartButton;

        private void Start()
        {
            Time.timeScale = 0;
            startButton.SetActive(true);
            restartButton.SetActive(false);
        }
        public void RestartButton()
        {
            restartButton.SetActive(true);
            Time.timeScale = 0;
        }
        public void Restart()
        {
            startButton.SetActive(false);
            restartButton.SetActive(false);
            Time.timeScale = 1;
        }
    }
}