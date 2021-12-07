using UnityEngine;

namespace Bounce
{
    public class Bonus : Destructible
    {
        [SerializeField] private int score;
        private void OnCollisionEnter(Collision collision)
        {
            var des = collision.gameObject.GetComponent<Destructible>();
            if (collision.gameObject.GetComponent<Ball>())
            {
                PlayerMetrics.Instance.CalculateScore(score);
                Destroy(gameObject);
            }
        }
    }
}