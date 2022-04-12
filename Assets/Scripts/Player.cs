using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public bool isGround = false;

    public float force = 6;

    public float DistanceBetween;
    public GameObject ThePlatform;

    public GameObject scoreCount;
    private Text scoreText;

    public bool isJump;

    //public GameObject totalScore;
    //private Text totalScoreText;

    Animator anim;

    //private var platforms;





    void Start()
    {

        scoreText = scoreCount.GetComponent<Text>();

        //totalScoreText = totalScore.GetComponent<Text>();

        anim = GetComponent<Animator>();
        anim.SetInteger("State", 0);

    }





    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(123);
        //GameObject enteredObject = other.gameObject;
        if (col.collider.tag == "Ground")
        {

            //print("ISGROUND");
            ScoreCount(col.gameObject);
            transform.position = new Vector2(col.gameObject.transform.position.x, transform.position.y);
        }

    }




    public void ScoreCount(GameObject platform)
    {
        //GameObject count = platform.transform.GetChild(0).gameObject;
        string score = platform.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
        scoreText.text = "" + score;
    }


    void Update()
    {

    }


}



