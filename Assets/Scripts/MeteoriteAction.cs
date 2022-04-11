using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteAction : MonoBehaviour
{
    //private GameObject platformToDestroy;
    public GameObject SpawnTarget;
    private Vector3 SpawnPosition;
    private float targetShift;
    public bool meteoriteAction;
    private float coroutineIterator = 1;
    public GameObject hitAnimation;
    //private bool isCollided = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(123);
        //GameObject enteredObject = other.gameObject;
        if (col.collider.tag == "Ground")
        {
            //isCollided = true;
            //print("ISGROUND");
            col.gameObject.transform.GetComponent<Rigidbody2D>().isKinematic = false;
            hitAnimation.SetActive(true);
            //platformToDestroy = col.gameObject;

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        targetShift = (transform.position.x - SpawnTarget.transform.position.x);
        hitAnimation.SetActive(false);
        SpawnPosition = new Vector3(SpawnTarget.transform.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(SpawnTarget.transform.position.x + targetShift, SpawnPosition.y, 0);
        //print("SpawnPosition=" + SpawnPosition + " targetShift=" + targetShift);
        GetComponent<Rigidbody2D>().isKinematic = true;
        meteoriteAction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (meteoriteAction && coroutineIterator == 1)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * 10f, ForceMode2D.Force);
            StartCoroutine(DestroyPlatfromRespawnMeteor());
        }
    }

    public void MeteoriteActionOnClick()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * 10f, ForceMode2D.Force);
        StartCoroutine(DestroyPlatfromRespawnMeteor());
    }

    IEnumerator DestroyPlatfromRespawnMeteor()
    {
        //yield return new WaitWhile(() => transform.position.y >= 1.38);
        coroutineIterator++;
        yield return new WaitUntil(() => transform.position.y < -20);

        

        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        transform.eulerAngles = new Vector3(0, 0, 0);

        transform.position = new Vector3(SpawnTarget.transform.position.x + targetShift, SpawnPosition.y, 0);
        meteoriteAction = false;
        hitAnimation.SetActive(false);
        coroutineIterator = 1;

        

        //gameObject.SetActive(false);




    }

    
}
