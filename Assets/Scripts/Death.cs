using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public GameObject player;
    Animator anim;

    public GameObject gameCanvas;
    public Text gameScore;
    public Text totalScore;
    public GameObject gameOverCanvas;
    public GameObject scoretext;

    public GameObject crown;

    // Start is called before the first frame update
    void Start()
    {
        anim = player.GetComponent<Animator>();
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < 0)
        {
            anim.SetInteger("State", 3);
            Invoke("PlatformFall", 1);
            Invoke("DeathScreen", 3);

            //Invoke("Death", 3);

        }
    }

    void PlatformFall()
    {
        var platforms = GameObject.FindGameObjectsWithTag("Ground");
        for (int i = 0; i < platforms.Length; i++)
            if (platforms[i].transform.position.y < 0)
                platforms[i].transform.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void DeathScreen()
    {
        gameCanvas.SetActive(false);
        scoreViever();
        gameOverCanvas.SetActive(true);
    }

    void scoreViever()
    {
        if (int.Parse(gameScore.text) < PlayerPrefs.GetInt("BestScore"))
        {
            totalScore.text = gameScore.text;
            crown.SetActive(false);
            //scoretext.GetComponent<RectTransform>().position.x = -19;
            //scoretext.GetComponent<RectTransform>().position = new Vector2(scoretext.GetComponent<RectTransform>().position.x - 19, scoretext.GetComponent<RectTransform>().position.y);
        }

        else
        {
            totalScore.text = "" + PlayerPrefs.GetInt("BestScore");
            crown.SetActive(true);
            //scoretext.GetComponent<RectTransform>().position = new Vector2(0, scoretext.transform.position.y);
        }

    }
}
