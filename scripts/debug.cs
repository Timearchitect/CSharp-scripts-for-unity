using UnityEngine;

public class debug : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World!");
        Debug.LogWarning("Custom Warning!");
        Debug.LogError("Custom Error!");
        print("HelloWorld from print!");
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.3f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(2, 2, 2));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
