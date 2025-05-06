using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    public float cooldown = 0.5f;
    private float timestamp = 0f;
    public int layerIndex = -1;  // layer index -1 finns ej
    public string tag= "Fire";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("FIRE ENTERED TRIGGER");
    
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time >= timestamp)
        {
            if (collision.CompareTag(tag) || collision.gameObject.layer == layerIndex)   // detect  tagg eller layer men det är i index nummer
            {
               // Debug.LogWarning("STAYING: " + collision.name + " | time = " + Time.time);
                 Debug.Log("FIRE STAYING");
                timestamp = Time.time + cooldown;  //sätt tid & CD
            }
        }
    }
}

