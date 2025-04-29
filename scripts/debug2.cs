using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class debug2 : MonoBehaviour
{

    int score = 0;

    // Start is called before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        gameObject.SetActive(false);
        score = 1;
        Debug.Log(" Din score är: " + score );
        Debug.LogWarning(" varning jag är farlig!!!" + gameObject.name);
        Debug.LogError(" I GONNA GET YOU !!!!");
        print("hello");
        
    }

    // Update is called once per frame
    void Update()
    {
         score = score + 1;        
         Debug.Log(" Din score är: " + score);
          
        
    }
}
