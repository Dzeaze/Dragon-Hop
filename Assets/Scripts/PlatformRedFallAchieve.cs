using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRedFallAchieve : MonoBehaviour
{
    bool getAchievement;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            
            player.GetComponent<PlatformRedFallAction>().platformRedFallAction = true;
            player.GetComponent<PlatformRedFallAction>().platformCounter = 1;

            getAchievement = true;

        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (getAchievement)
        {
            
            Destroy(gameObject);
        }
    }
}
