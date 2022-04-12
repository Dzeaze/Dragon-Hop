using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{
    public bool isGround = false;

    void OnCollisionStay2D(Collision2D col)

    {               
        if (col.collider.tag == "Ground") { isGround = true; }
    }
    void OnCollisionExit2D(Collision2D col)
    {              
        if (col.collider.tag == "Ground") { isGround = false; }     
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}