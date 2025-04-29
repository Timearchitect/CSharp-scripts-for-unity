using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;

    [SerializeField] private GameObject OnCollideSpawnGameObject; //praticle effekt gameobject?
    public float forceAmount = 500f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * forceAmount);   //höger enligt rotation av gameobjectet
        // rb.AddForceX(forceAmount);                //höger bara
    }



 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HIT");
        if (OnCollideSpawnGameObject) { //spawnaed Objected
       
           // GameObject go = Instantiate(Partikeleffekt);
           // go.transform.position = transform.position;
           
           // GameObject go = Instantiate(OnCollideSpawnGameObject, transform.position + new Vector3(3f,4f), Quaternion.identity);
            GameObject go = Instantiate(OnCollideSpawnGameObject, transform.position + new Vector3(0f,0f), transform.rotation);
            Destroy(go, 5.5f);
        
        }

        Destroy(gameObject); //förstör den
    }
}
