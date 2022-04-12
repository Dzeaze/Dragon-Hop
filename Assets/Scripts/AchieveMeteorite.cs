using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveMeteorite : MonoBehaviour
{
    public GameObject Meteorite;
    bool getAchievement;
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            //print(jump1LimitScore.text);
            //Meteorite.SetActive(true);
            Meteorite.GetComponent<MeteoriteAction>().meteoriteAction = true;
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

            Destroy(gameObject);
        }
    }
}
