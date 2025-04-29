using UnityEngine;

public class projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    [SerializeField] public GameObject Partikeleffekt; //praticle effekt gameobject?
    public float forceAmount = 500f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * forceAmount);   //höger enligt rotation av gameobjectet
        // rb.AddForceX(forceAmount);                //höger bara
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HIT");
        if (Partikeleffekt) {
       
           // GameObject go = Instantiate(Partikeleffekt);
           // go.transform.position = transform.position;
            GameObject go = Instantiate(Partikeleffekt, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
        
        }
        Destroy(gameObject); //förstör den
    }
}
