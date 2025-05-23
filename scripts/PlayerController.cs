using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{

   
    public Rigidbody2D rb; //skapar variabeln/containern för ridgidbody2d
    Vector3 ogScale;
    private bool grounded;

    void Start()
    {
        ogScale = gameObject.transform.localScale;
        rb = GetComponent<Rigidbody2D>(); //hämtar Componenten Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(  Input.GetAxis("Horizontal") );
        /*
                if(Input.GetAxis("Horizontal") > 0 ) // h�ger gammal
                {
                    rb.AddForceX(2);
                }

                if (Input.GetAxis("Horizontal") < 0) // v�nster gammal
                {
                    rb.AddForceX(-2);
                }

                if(Input.GetAxis("Horizontal")!=0)
                    rb.AddForceX(Input.GetAxis("Horizontal")*2);
                */
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3( ogScale.x,ogScale.y );  // flip normal
            rb.AddForce(new Vector2(5.5f, 0.0f));
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3( -ogScale.x,ogScale.y); //flip negativ (left)
            rb.AddForce(new Vector2(-5.5f, 0.0f));

        }



        if (Input.GetAxis("Vertical") > 0) // UPP
        {
            rb.AddForceY(5);
        }

        if (grounded && Input.GetButtonDown("Jump")) // Hoppa
        {
            grounded = false;
            rb.AddForceY(2000);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Untagged")
        {
            grounded = true;
        }
    }
}
