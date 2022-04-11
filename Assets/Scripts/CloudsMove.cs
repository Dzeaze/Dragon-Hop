using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMove : MonoBehaviour
{
    public float speed;
    private Transform trans;
    public GameObject cameraTarg;
    public GameObject clouds2;
    
    private float posClouds2;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        posClouds2 = clouds2.GetComponent<Transform>().position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveClouds();
    }

    void MoveClouds()
    {
        
        

        if (clouds2.GetComponent<Transform>().position.x - cameraTarg.GetComponent<Transform>().position.x < 0)
        {
            //print("time to move clouds pos=" + clouds2.GetComponent<Transform>().position.x);
            transform.position = new Vector3(cameraTarg.GetComponent<Transform>().position.x, trans.position.y, trans.position.z);
            clouds2.GetComponent<Transform>().position = new Vector3(posClouds2 + cameraTarg.GetComponent<Transform>().position.x, trans.position.y, trans.position.z);
            
        }
        else
        {
            //print("clouds moving, pos=" + clouds2.GetComponent<Transform>().position.x);
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            clouds2.GetComponent<Transform>().position = new Vector3(clouds2.transform.position.x + speed * Time.deltaTime, clouds2.transform.position.y, clouds2.transform.position.z);
        }
    }
}

