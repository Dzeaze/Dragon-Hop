using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achieveJumpBack : MonoBehaviour
{
    //public GameObject jump1Limit;
    public GameObject jump1Limit;
    private Text jump1LimitScore;
    bool getAchievement;


    // Start is called before the first frame update


    void Start()
    {

        jump1LimitScore = jump1Limit.GetComponent<Text>();



    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            //print(jump1LimitScore.text); 
            jump1LimitScore.text = "" + (int.Parse(jump1LimitScore.text) + 1);
            getAchievement = true;
        }


    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            getAchievement = false;

        }


    }



    // Update is called once per frame
    void Update()
    {
        if (getAchievement)
        {
            //transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y + 1000), 0.1f * Time.deltaTime);
            Destroy(gameObject);
        }
    }
}