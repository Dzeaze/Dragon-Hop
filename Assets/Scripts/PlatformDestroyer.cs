using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject platformDestructionPoint;
    public GameObject platformDestructionPointBottom;
    // Start is called before the first frame update
    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
        platformDestructionPointBottom = GameObject.Find("PlatformDestructionPointBottom");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < platformDestructionPointBottom.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}