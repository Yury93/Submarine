using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    /// <summary>
    /// Длина уровня
    /// </summary>
    private float lengthLvl;

    [SerializeField] private RegisterPlayer register;
    [SerializeField] private LevelGenerator ground;

    void Start()
    {
        var bounds = GetComponent<Collider>().bounds;
        lengthLvl = bounds.size.z;
        register.OnGenerate += GenerateActiveted;
    }

    public void GenerateActiveted()
    {
        var s =  lengthLvl - register.transform.position.z;//Расстояние до конца уровня
        Vector3 placeGenertion = new Vector3(transform.position.x, transform.position.y, transform.position.z + lengthLvl);
        ground = Instantiate(ground, placeGenertion, Quaternion.identity);
    }
}
