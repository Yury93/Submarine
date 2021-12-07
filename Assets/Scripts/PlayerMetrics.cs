using UnityEngine;
using UnityEngine.UI;

namespace Bounce
{
    public class PlayerMetrics : SingletonBase<PlayerMetrics>
    {
        [SerializeField] private Text lives;
        public Text Lives => lives;

        [SerializeField] private Text score;
        public Text Score => score;

        [SerializeField] private int currentScore;
        public int CurrentScore => currentScore;

        [SerializeField] private Text record;
        private int newRecord = 0;

        public event ScoreUpdater OnUpdateRecord;
        public delegate void ScoreUpdater();

        private void Start()
        {
                newRecord = PlayerPrefs.GetInt("newRecord");
                record.text = "Record: " + newRecord.ToString();
        }
        public void CalculateScore(int addScore)
        {
            currentScore += addScore;
            score.text = "Score: " + currentScore.ToString();
            if(currentScore > newRecord)
            {
                newRecord = currentScore;
                record.text = "Record: " + newRecord;
                PlayerPrefs.SetInt("newRecord", newRecord);
            }
        }

        public void ResetScore()
        {
            currentScore = 0;
            score.text = currentScore.ToString();
        }
    }
}