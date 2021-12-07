using UnityEngine;

public class RegisterPlayer : MonoBehaviour
{
    private LevelGenerator lvlGen;
    /// <summary>
    /// ������� ��� �������� ������ 
    /// </summary>
    public delegate void PlayerFind();
    public event PlayerFind OnGenerate;

    private void Start()
    {
        GetComponentInParent<LevelGenerator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnGenerate();
        }
    }
}
