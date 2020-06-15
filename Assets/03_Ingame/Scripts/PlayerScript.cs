using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D myrigidbody;
    Animator PAnimator;
    SpriteRenderer Renderer;

    [SerializeField] private float Power;
    [SerializeField] Transform Pos;
    [SerializeField] float CheckRadius = 0.35f;
    [SerializeField] LayerMask Islayer;
    [SerializeField] Camera MainCamera;
    [SerializeField] [Range(0.0f, 10.0f)] public float DashGauge;
    [SerializeField] private float hor;
    [SerializeField] private Vector3 PPos;

    [SerializeField] private float JumpTimeCounter;
    [SerializeField] private float SlowTimer = 0;
    [SerializeField] private float NullDashTimer = 0;

    private float PlayerScaleX;

    public float PlayTime = 1800;
    public float DashObjCnt = 0;

    public float Speed = 10;
    public float JumpTime;
    //public float animSpeed = 1.0f;
    //public Animator animator;

    public bool Isgraceperiod = false;
    public bool IsJumping = false;
    public bool IsSlow = false;
    public bool IsGround = false;
    public bool IsDash = false;
    public bool GameClear = false;
    public bool Dashminus = false;


    private void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        PAnimator = GetComponent<Animator>();
        Renderer = GetComponent<SpriteRenderer>();

        PlayerScaleX = transform.localScale.x;
    }

    private void Update()
    {
        //animator.speed = animSpeed;
        if (!(GameClear))
        {
            PlayTime += Time.deltaTime;

            if (DashGauge > 0 && DashGauge < 10)
            {
                DashGauge += 0.0005f;
            }


            if (!IsDash) //대쉬 중이 아닐 시 플레이어 스피드 
            {
                PAnimator.SetFloat("ASpeed", 1);
                if (Singleton.singleton.DAN.DAN) //아침
                {
                    Speed = 10 + Mathf.Lerp(0, 10, (DashGauge / 10));
                }
                else //밤
                {
                    Speed = 7 + Mathf.Lerp(0, 10, (DashGauge / 10));
                }
            }

            if (IsSlow && SlowTimer <= 2.5) //장애물에 걸렸을 때 속도가 일시적으로 느려짐
            {
                PAnimator.SetFloat("ASpeed", 0.5f);
                Power = 17;
                Speed -= 5f;
                SlowTimer += Time.deltaTime;
            }
            else //풀렸을 때
            {
                Power = 20f;
                IsSlow = false;
                SlowTimer = 0;
            }

            if (DashGauge <= 0) //대쉬게이지 모두 소모시 움직일 수 없음.
            {
                if (NullDashTimer < 3)
                {
                    Speed = 0;
                    PAnimator.SetBool("ATiredCHK", true);
                    NullDashTimer += Time.deltaTime;

                }
                else if (NullDashTimer >= 3) // 끝났을 때
                {
                    NullDashTimer = 0;
                    PAnimator.SetBool("ATiredCHK", false);
                    DashGauge += 1;
                }
            }

            //바닥에 닿아있는지 아닌지 확인하는 코드
            IsGround = Physics2D.OverlapCircle(Pos.position, CheckRadius, Islayer);

            if (hor > 0) //앞으로
            {
                //transform.eulerAngles = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(PlayerScaleX, transform.localScale.y);
            }
            else if (hor < 0) //뒤로
            {
                //transform.eulerAngles = new Vector3(0, 180, 0);
                transform.localScale = new Vector3(-PlayerScaleX, transform.localScale.y);
            }

            if (IsGround == true && Input.GetKeyDown(KeyCode.Space)) //점프
            {
                IsJumping = true;
                PAnimator.SetBool("AJumpChk", true);
                JumpTimeCounter = JumpTime * 1.5f;
                myrigidbody.velocity = Vector2.up * Power;
            }

            if (Input.GetKey(KeyCode.Space) && IsJumping == true)
            { //점프 중

                if (JumpTimeCounter > 0)
                {
                    PAnimator.SetBool("AJumpChk", true);
                    myrigidbody.velocity = Vector2.up * Power;
                    JumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    PAnimator.SetBool("ALandingChk", true);
                    IsJumping = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space)) //점프 종료
            {
                PAnimator.SetBool("ALandingChk", true);
                PAnimator.SetBool("AJumpChk", false);
                IsJumping = false;
            }

            if (IsGround == true) //땅에 닿아있을 때 착지모션 종료
            {
                PAnimator.SetBool("ALandingChk", false);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && DashGauge > 0 && (!(IsSlow)) && (!(hor == 0))) //대쉬 시작
            {
                IsDash = true;
            }
            if (Input.GetKey(KeyCode.LeftShift) && DashGauge > 0 && (!(hor == 0)) && (IsDash)) //대쉬 중
            {
                PAnimator.SetFloat("ASpeed", 2);
                Speed = 25;
                DashGauge -= 1.5f * Time.deltaTime;

                if (DashGauge <= 0)
                    IsDash = false;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)) //대쉬 종료
            {
                IsDash = false;
            }

            if (Dashminus)
            {
                if (DashGauge >= 1)
                    DashGauge -= 1;
                else if (DashGauge < 1)
                    DashGauge = 0;
                Dashminus = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!(GameClear))
        {
            hor = Input.GetAxisRaw("Horizontal");

            if (!(hor == 0))
                PAnimator.SetBool("ARunnigChk", true);
            else
                PAnimator.SetBool("ARunnigChk", false);
        }
        PPos = this.gameObject.transform.position;
        if (!GameClear)
        {
            //myrigidbody.velocity = new Vector2(hor * Speed, myrigidbody.velocity.y);
            transform.Translate(new Vector3(hor * Speed * Time.deltaTime, 0));
            //transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            if (PPos.x >= 1886)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                PAnimator.SetBool("ARunnigChk", false);
                PAnimator.SetBool("AJumpChk", false);
                PAnimator.SetBool("ALandingChk", false);
                PAnimator.SetBool("ATiredCHK", false);
            }
            else
                transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }

        }

    private void LateUpdate()
    {
        if (!(GameClear))
            MainCamera.transform.position = new Vector3(transform.position.x + 1.5f, MainCamera.transform.position.y, MainCamera.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DashObject")
        {
            DashObjCnt++;
            if(DashGauge <= 9)
                DashGauge += 1;
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "Obstacle" && !Isgraceperiod)
        {
            Isgraceperiod = true;
            StartCoroutine(GracePeriod());
            if (IsDash)
                IsDash = false;
            IsSlow = true;
            
            Dashminus = true;
        }

        if (collision.tag == "HT")
        {
            GameClear = true;
        }
    }

    IEnumerator GracePeriod()
    {
        Renderer.color = new Vector4(1, 1, 1, 0);
        yield return new WaitForSeconds(0.15f);
        Renderer.color = new Vector4(1, 1, 1, 1);
        yield return new WaitForSeconds(0.15f);
        Renderer.color = new Vector4(1, 1, 1, 0);
        yield return new WaitForSeconds(0.15f);
        Renderer.color = new Vector4(1, 1, 1, 1);
        yield return new WaitForSeconds(0.15f);
        Renderer.color = new Vector4(1, 1, 1, 0);
        yield return new WaitForSeconds(0.15f);
        Renderer.color = new Vector4(1, 1, 1, 1);
        yield return new WaitForSeconds(0.15f);
        Renderer.color = new Vector4(1, 1, 1, 0);
        yield return new WaitForSeconds(0.15f);
        Renderer.color = new Vector4(1, 1, 1, 1);
        yield return new WaitForSeconds(0.15f);
        Renderer.color = new Vector4(1, 1, 1, 0);
        yield return new WaitForSeconds(0.15f);
        Renderer.color = new Vector4(1, 1, 1, 1);
        yield return new WaitForSeconds(0.15f);
        Isgraceperiod = false;
    }
}
