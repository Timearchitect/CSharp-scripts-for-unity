using UnityEngine;

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
            GameObject go = Instantiate(OnCollideSpawnGameObject, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
        
        }

        Destroy(gameObject); //förstör den
    }
}
