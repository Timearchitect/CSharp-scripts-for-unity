using UnityEngine;

public class CanvasBehavior : MonoBehaviour
{



    public void HideUI( )
    {
        Debug.Log("Gömmer GUI");
        gameObject.SetActive(false);
    }

}
