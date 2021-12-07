using UnityEngine;

namespace Bounce
{
    public class Obstacle : Destructible
    {
        private void OnCollisionEnter(Collision collision)
        {
            var des = collision.gameObject.GetComponent<Destructible>();
            if (collision.gameObject.GetComponent<Ball>())
            {
                gameObject.GetComponent<Destructible>().ApplyDamage(1);
                des.ApplyDamage(1);
                PlayerMetrics.Instance.Lives.text = des.CurrentLives.ToString();
            }
        }
    }
}