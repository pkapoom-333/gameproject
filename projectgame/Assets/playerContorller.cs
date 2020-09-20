using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerContorller : MonoBehaviour
{
    public Rigidbody2D MyRigidbody;
    //Defuit Playyer Jump
    public float PlayyerJump = 800f;
   
    public Animator MyAnim;
    public float PlayerDie = -1;

    public Collider2D MyCollider;
    //score
    public Text Scoretext;
    public float StartTime;
    //value jummping 
    private int jumpsLeft = 2;
    public AudioSource JumpSf;
    public AudioSource DeathSf;
    public GameObject UiGameOver;
    [SerializeField]
    GameObject[] lives;
    int LiveNumber;
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();
        MyAnim = GetComponent<Animator>();
        MyCollider = GetComponent<Collider2D>();

        StartTime = Time.time;
        //Defult life of game
        LiveNumber = 2;
       

        foreach (GameObject live in lives)
            live.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //setting jumpping
        if (PlayerDie == -1)
        {
            if (Input.GetButtonUp("Jump") && jumpsLeft > 0)
            {
                if (MyRigidbody.velocity.y < 0)
                {
                    MyRigidbody.velocity = Vector2.zero;
                }
                if (jumpsLeft <= 1)
                {
                    MyRigidbody.AddForce(transform.up * PlayyerJump * 0.75f);
                }
                else
                {
                    MyRigidbody.AddForce(transform.up * PlayyerJump);
                }

                jumpsLeft--;
                JumpSf.Play();
            }
            //calculate score
            MyAnim.SetFloat("Velocity", Mathf.Abs(MyRigidbody.velocity.y));
            Scoretext.text = (Time.time - StartTime).ToString("0.0");
      
        }
        else
        {
            if (Time.time > PlayerDie + 2)
            {
                //restart game
                //Application.LoadLevel(Application.loadedLevel);
                UiGameOver.SetActive(true);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //setting value charactor

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            LiveNumber -= 1;
            //Destroy heart
            lives[LiveNumber].SetActive(false);
           

            if (LiveNumber <= 0)
            {
                foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>())
                {
                    //stop spawn object
                    spawner.enabled = false;
                }

                foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>())
                {
                    //stop move left
                    moveLefter.enabled = false;
                }
                //save value time
                PlayerDie = Time.time;
                //sound dead
                DeathSf.Play();
                //call AnitionHurt
                MyAnim.SetBool("playerHurt", true);
                //Stop movement when die
                MyRigidbody.velocity = Vector2.zero;
                MyRigidbody.AddForce(transform.up * PlayyerJump);
                //setting high score
                float currentHightScore = PlayerPrefs.GetFloat("TextHightScore", 0);
                float currentScore = (Time.time - StartTime);
                if (currentScore > currentHightScore)
                {
                    PlayerPrefs.SetFloat("TextHightScore", currentScore);
                }
            }
        }
        else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("road"))
        {
            //setting jump on the ground
            jumpsLeft = 2;    
        }
    }

}
