using UnityEngine;

namespace Bounce
{
    public class Ball : Destructible
    {
        #region Properties
        /// <summary>
        /// ������� ��������
        /// </summary>
        [SerializeField] private float speed;
        public float Speed => speed;
        /// <summary>
        /// �����������
        /// </summary>
        [SerializeField] private float direction;

        [SerializeField] private Rigidbody rbody;
        /// <summary>
        /// �������� ������ � ������ ������
        /// </summary>
        private float startSpeed;
        /// <summary>
        /// �������� ������ ��������� �� ���������� ��������� �����
        /// </summary>
        private float bonusSpeed;
        /// <summary>
        /// �������� ����� ������������
        /// </summary>
        private float newSpeed;
        /// <summary>
        /// ����� �� ������� ���������� ��������
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
        /// ����� �������� ������
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
        /// ����������� ��������
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