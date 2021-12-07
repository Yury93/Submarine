using System.Collections;
using UnityEngine;

namespace Bounce
{
    /// <summary>
    /// Спавн бонусов и препятствий
    /// </summary>
    public class SpawnEnvironment : Factory<Destructible>
    {
        /// <summary>
        /// Количество объектов(Сколько нужно создать объектов на сцене)
        /// </summary>
        [SerializeField] private int countObjects;
        [SerializeField] private float timerCreate;
        private void Start()
        {
            StartCoroutine(CorInstance());
        }

        public IEnumerator CorInstance()
        {
            yield return new WaitForSeconds(timerCreate);
            for (int i = 0; i < countObjects; i++)
            {
                GetNewInstance();
            }
        }
    }
}