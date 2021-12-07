using UnityEngine;

public class Factory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform pointToSpawn;
    [SerializeField] private Transform positionParent;
    [SerializeField] private T prefab;

    public T GetNewInstance()
    {
        Vector3 pos = new Vector3(pointToSpawn.position.x + (Random.Range(-6f, 6f)), pointToSpawn.position.y, 
            pointToSpawn.position.z + (Random.Range(20,500)));

        return Instantiate(prefab, pos, Quaternion.identity, positionParent);
    }
}