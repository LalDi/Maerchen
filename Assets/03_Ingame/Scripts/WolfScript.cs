using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WolfScript : MonoBehaviour
{
    Animator WAnimator;

    Rigidbody2D myrigidbody;

    [SerializeField] private float WSp;
    [SerializeField] private float JumpPower;
    [SerializeField] private float JumpSpeed;

    [SerializeField] private GameObject GameOverObj;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject PauseBT;

    [SerializeField] private float WolfJumpWatingTimer = 0;
    [SerializeField] private float WolfJumpTimeCounter = 0;

    public float Speed;
    public float DistanceStandard = 50f;
    public bool Gameover = false;
    public bool WolfSpeedup = false;
    public bool WolfJumpWaiting = false;
    public bool WolfJump = false;
    private float DistancePW;

    // Start is called before the first frame update
    void Start()
    {
        WAnimator = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        DistancePW = Singleton.singleton.Player.transform.position.x - transform.position.x;
        if (!(Singleton.singleton.Player.GameClear))
        {
            //스피드 정하는 
            if (Singleton.singleton.Player.IsSlow && (!(WolfJumpWaiting)) ) //빨간망토가 장애물에 걸려 늑대 속도가 빨라짐
            {
                if (Singleton.singleton.DAN.DAN)
                {
                    WAnimator.SetBool("ADANChk", true);
                    WAnimator.SetFloat("ASpeed", 1.5f);
                    Speed = (WSp + 1);
                    if (DistancePW < DistanceStandard)
                        Speed = (WSp + 4);
                }
                else
                {
                    WAnimator.SetBool("ADANChk", false);
                    WAnimator.SetFloat("ASpeed", 2f);
                    Speed = (WSp + 3);
                    if (DistancePW < DistanceStandard)
                        Speed = (WSp + 6);
                }
            }
            else if (WolfJumpWaiting) //점프 대기 때라 스피드=0
            {
                if (WolfJumpWatingTimer <= 3)
                {
                    WAnimator.SetBool("AJumpWaitingChk", true);
                    WolfJumpWatingTimer += Time.deltaTime;
                    Speed = 0;
                }
                else
                {
                    GameObject.Find("SoundsManager").GetComponent<IGSoundManagerScripts>().SoundManage("SoundWolf2");
                    WolfJumpWatingTimer = 0;
                    WolfJumpWaiting = false;
                    WAnimator.SetBool("AJumpWaitingChk", false);
                    WolfJump = true;
                }
            }
            else //늑대 평소 속도
            {
                if (Singleton.singleton.DAN.DAN)
                {
                    WAnimator.SetBool("ADANChk", true);
                    WAnimator.SetFloat("ASpeed", 1f);
                    Speed = WSp;
                    if (DistancePW < DistanceStandard)
                        Speed = (WSp + 3);
                }
                else
                {
                    WAnimator.SetBool("ADANChk", false);
                    WAnimator.SetFloat("ASpeed", 1.5f);
                    Speed = (WSp + 4);
                    if (DistancePW < DistanceStandard)
                        Speed = (WSp + 7);
                }
            }

            //늑대 지속적으로 앞으로 가는 코드
            if (!(WolfJump) && (!(Singleton.singleton.Player.GameClear)))
            {
                transform.Translate(Vector3.right * Speed * Time.deltaTime);
            }
            //점프할 때 코드
            else
            {
                if (WolfJumpTimeCounter > 0)
                {
                    WAnimator.SetBool("AJumpChk", true);
                    myrigidbody.velocity = Vector2.up * JumpPower;
                    WolfJumpTimeCounter -= Time.deltaTime;
                    transform.Translate(Vector3.right * JumpSpeed * Time.deltaTime);
                }
                else
                {
                    WolfJumpTimeCounter = 1.5f;
                    WAnimator.SetBool("AJumpChk", false);
                    WolfJump = false;
                }

            }
        }
        else
        {
            WAnimator.SetBool("AJumpWaitingChk", true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) //늑대가 장애물에 충돌 시 장애물 없어짐.
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("DashObject"))
        {
            collision.gameObject.SetActive(false);
        }

        //if (collision.gameObject.CompareTag("Platform"))
        //{
        //    Destroy(collision.gameObject);
        //    //collision.gameObject.SetActive(false);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //늑대가 플레이어와 충돌 시 게임 끝
        {
            Gameover = true;

            UI.SetActive(false);
            PauseBT.SetActive(false);
        
            GameOverObj.SetActive(true);

            Time.timeScale = 0;
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            collision.gameObject.SetActive(false);
        }
    }

}
