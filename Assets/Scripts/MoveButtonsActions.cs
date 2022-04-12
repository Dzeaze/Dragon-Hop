using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButtonsActions : MonoBehaviour
{

    //public Button button;
    //public Button button2;
    //public Button button3;

    private int buttonValue;
    //private int button2Value;
    //private int button3Value;

    public GameObject playerGO;
    private Rigidbody2D player;

    public float DistanceBetween;
    public GameObject ThePlatform;

    private float PlatformWidth;

    private float distance;

    Animator anim;

    public GameObject jump1Limit;
    private Text jump1LimitScore;
    public int jumpLimit;

    //private bool coroutineIsOn = false;



    // Start is called before the first frame update 
    void Start()
    {
        anim = playerGO.GetComponent<Animator>();
        anim.SetInteger("State", 0);
        player = playerGO.GetComponent<Rigidbody2D>();
        PlatformWidth = ThePlatform.GetComponent<BoxCollider2D>().size.x;

        jump1LimitScore = jump1Limit.GetComponent<Text>();
        jumpLimit = int.Parse(jump1LimitScore.text);

        //buttonValue = int.Parse(button.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        //button2Value = int.Parse(button2.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        //button3Value = int.Parse(button3.transform.GetChild(0).gameObject.GetComponent<Text>().text);
    }

    public void Jump()
    {

        if (playerGO.GetComponent<IsGround>().isGround && !playerGO.GetComponent<Player>().isJump && playerGO.transform.position.y >= 0.5f)
        {
            buttonValue = int.Parse(transform.GetChild(0).gameObject.GetComponent<Text>().text);
            //if (buttonValue <= 0 && jumpLimit > 0)
                //jumpLimit--;
            if (buttonValue > 0)
                StartCoroutine(JumpAndStop(buttonValue));
            if (buttonValue < 0 && jumpLimit > 0)
            {
                StartCoroutine(JumpAndStop(buttonValue));
                jumpLimit--;
            }
        }

        jump1LimitScore.text = "" + jumpLimit;
    }


    IEnumerator JumpAndStop(int buttonValue)
    {


        playerGO.GetComponent<Player>().isJump = true;
        
        float playerX = playerGO.transform.position.x;
        distance = buttonValue * (PlatformWidth + DistanceBetween);
        //print("buttonValue= " + buttonValue + " distance= " + distance);

        


        player.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        player.AddForce(Vector2.right * distance, ForceMode2D.Impulse);

        if (distance < 0)
            anim.SetInteger("State", 2);
        else anim.SetInteger("State", 1);

        if (distance < 0)
            yield return new WaitWhile(() => (playerGO.transform.position.x >= playerX + distance));
        
        else yield return new WaitWhile(() => (playerGO.transform.position.x <= playerX + distance));
        
        player.velocity = Vector3.zero;

        

        anim.SetInteger("State", 0);
        playerGO.transform.position = new Vector2(playerX + distance, playerGO.transform.position.y);

        playerGO.GetComponent<Player>().isJump = false;


    }

    // Update is called once per frame
    void Update()
    {
        jumpLimit = int.Parse(jump1LimitScore.text);
    }

    private float Distance(int jumpCount)
    {
        distance = jumpCount * (PlatformWidth + DistanceBetween);
        return distance;
    }
}
