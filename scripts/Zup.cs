using UnityEngine;

public class Zup : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        Physics.gravity = new Vector3(0f, 0f, -9.81f);
    }


}
