using UnityEngine;

namespace Bounce
{
    public class Ball : Destructible
    {
        #region Properties
        /// <summary>
        /// Текущая скорость
        /// </summary>
        [SerializeField] private float speed;
        public float Speed => speed;
        /// <summary>
        /// Направление
        /// </summary>
        [SerializeField] private float direction;

        [SerializeField] private Rigidbody rbody;
        /// <summary>
        /// Скорость шарика в начале уровня
        /// </summary>
        private float startSpeed;
        /// <summary>
        /// Скорость шарика зависимая от количества набранных очков
        /// </summary>
        private float bonusSpeed;
        /// <summary>
        /// Скорость после интерполяции
        /// </summary>
        private float newSpeed;
        /// <summary>
        /// Время за которое увеличится скорость
        /// </summary>
        private float time = 0f;
        #endregion

        private void Start()
        {
            startSpeed = speed;
            newSpeed = speed;
        }
        private void Update()
        {
            Move();
            AddSpeed();
        }

        /// <summary>
        /// Метод движения шарика
        /// </summary>
        private void Move()
        {
            Vector3 moving = new Vector3(direction, 0, speed);

            if (Input.GetMouseButtonDown(0))
            {
                direction = -direction;
            }

            rbody.AddForce(moving * Time.deltaTime, ForceMode.Impulse);
        }
        /// <summary>
        /// Прибавление скорости
        /// </summary>
        private void AddSpeed()
        {
            var activity = true;

            if (activity == true)
                switch (PlayerMetrics.Instance.CurrentScore)
                {
                    case 10:
                        bonusSpeed = startSpeed * 1.5f;
                        activity = false;
                        break;
                    case 25:
                        bonusSpeed = startSpeed * 2f;
                        activity = false;
                        break;
                    case 50:
                        bonusSpeed = startSpeed * 3f;
                        activity = false;
                        break;
                    case 100:
                        bonusSpeed = startSpeed * 4f;
                        activity = false;
                        break;
                    case 0:
                        speed = startSpeed;
                        activity = false;
                        break;
                }
            if (speed != bonusSpeed && bonusSpeed != 0)
            {
                time += Time.deltaTime / 2;
                speed = Mathf.Lerp(newSpeed, bonusSpeed, time);
            }
            if (speed == bonusSpeed)
            {
                newSpeed = speed;
                time = 0;
            }
        }
    }
}