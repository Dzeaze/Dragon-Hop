using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReturnAction : MonoBehaviour
{
    Rigidbody2D player;
    private GameObject firstPlatform;
    private GameObject secondPlatform;
    private GameObject savedPlatform;
    private int jumpIterator;
    private bool isGround;
    Animator anim;
    //private float PlatformWidth;

    private int firstPlatformNumber = 1;
    private int secondPlatformNumber = 1;



    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(123);
        //GameObject enteredObject = other.gameObject;
        if (col.collider.tag == "Ground")
        {
            try
            {
                if (jumpIterator == 1)
                { secondPlatform = col.collider.gameObject; firstPlatform = savedPlatform; }
                else { firstPlatform = secondPlatform; secondPlatform = col.collider.gameObject; savedPlatform = secondPlatform; }

                firstPlatformNumber = int.Parse(firstPlatform.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text);
                secondPlatformNumber = int.Parse(secondPlatform.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text);
            }

            catch (NullReferenceException)
            {
                //Debug.Log("No object for platform, looser hahaha");
            }

            if (jumpIterator == 1)
                jumpIterator++;
            else jumpIterator = 1;

            //print(firstPlatformNumber + " firstPlatformNumber ");
            //print(secondPlatformNumber + " secondPlatformNumber ");
        }

    }

    void OnCollisionStay2D(Collision2D col)

    {    //Debug.Log(1234);           
        if (col.collider.tag == "Ground") { isGround = true; }
    }
    void OnCollisionExit2D(Collision2D col)
    {              //если из триггера что то вышло и у обьекта тег "ground"
        if (col.collider.tag == "Ground") { isGround = false; }     //то вџключаем переменную "на земле"
    }


    // Start is called before the first frame update
    void Start()
    {
        jumpIterator = 1;
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("State", 0);


    }

    public void BackToFirstPlatform()
    {
        //player.isKinematic = true;
        if (isGround)
        {
            
            if (firstPlatform.transform.position.x < secondPlatform.transform.position.x)
                StartCoroutine(JumpBack());
            if (firstPlatform.transform.position.x > secondPlatform.transform.position.x) StartCoroutine(JumpForward());
        }
        //transform.position = new Vector2(firstPlatform.transform.position.x, transform.position.y);
        //player.isKinematic = false;
        //print(firstPlatform.transform.position.x + " firstPlatform.transform.position.x ");
        //print(secondPlatform.transform.position.x + " secondPlatform.transform.position.x ");
    }

    IEnumerator JumpForward()
    {
        //jump

        float playerX = transform.position.x;
        float distance = (firstPlatformNumber - secondPlatformNumber) * (1 + 3);
        //float platformCenter = transform.position.x + Distance3;


        player.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        player.AddForce(Vector2.right * distance, ForceMode2D.Impulse);
        anim.SetInteger("State", 1);

        


        
        yield return new WaitWhile(() => transform.position.x < (playerX + distance));
        player.velocity = Vector3.zero;
        anim.SetInteger("State", 0);
        transform.position = new Vector2(playerX + distance, transform.position.y);
    }

    IEnumerator JumpBack()
    {
        

        float playerX = transform.position.x;
        float distance = (secondPlatformNumber - firstPlatformNumber) * (1 + 3);
        


        player.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        player.AddForce(Vector2.right * -distance, ForceMode2D.Impulse);
        anim.SetInteger("State", 2);

        


        
        yield return new WaitWhile(() => transform.position.x > (playerX - distance));
        player.velocity = Vector3.zero;
        anim.SetInteger("State", 0);
        transform.position = new Vector2(playerX - distance, transform.position.y);

        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
