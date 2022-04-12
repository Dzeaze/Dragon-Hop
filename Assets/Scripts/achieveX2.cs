using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achieveX2 : MonoBehaviour
{
    bool getAchievement;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            //print(jump1LimitScore.text);
            //Meteorite.SetActive(true);
            player.GetComponent<X2Action>().x2Action = true;
            //print("run x2");
            getAchievement = true;

        }


    }
    // Start is called before the first frame update
    void Start()
    {
        //Meteorite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (getAchievement)
        {
            //player.GetComponent<X2Action>().x2Action = false;
            Destroy(gameObject);
        }
    }
}
