using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRedFallAction : MonoBehaviour
{
    public bool platformRedFallAction;
    public int redPlatformsCount = 5;
    public int platformCounter = 1;
    private GameObject platform;
    

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.collider.tag == "Ground" && platformRedFallAction)
        {

            platform = col.gameObject;
            
            StartCoroutine(PlatformFall(col.gameObject));
            




        }

    }

    /*private void RedFallAction(GameObject platform)
    {
        if (platformCounter <= redPlatformsCount)
            StartCoroutine(PlatformRed(platform));
        else
        {
            platformRedFallAction = false;
            platformCounter = 1;
        }

    }*/

    

    IEnumerator PlatformFall(GameObject platform)
    {
        
        yield return new WaitForSeconds(1f);
        platform.transform.GetComponent<Rigidbody2D>().isKinematic = false;
        platformCounter++;
    }

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

          if (platformRedFallAction && platformCounter <= redPlatformsCount && platform != null && transform.position.y >= 0.5f)
            {
                if (platform.GetComponent<SpriteRenderer>().color.g > 0)
                    platform.GetComponent<SpriteRenderer>().color = new Color(1f, platform.GetComponent<SpriteRenderer>().color.g - 0.02f, platform.GetComponent<SpriteRenderer>().color.b - 0.02f);
                //StartCoroutine(PlatformFall(platform));
                //platform = null;

            }
        

        if (platformCounter > redPlatformsCount)
        {
            platformRedFallAction = false;
            platformCounter = 1;
            platform = null;
        }
    }
}
