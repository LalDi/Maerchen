using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class OpeningScript : MonoBehaviour
{
    [SerializeField] private AudioSource BGM;
    [SerializeField] private Text Text;
    [SerializeField] private string [] TextMessage = new string[8];

    [SerializeField] private float Speed;
    [SerializeField] private float TypingTime;
    [SerializeField] private int MessageStac = 0;

    private float ColorA = 0;
    private bool StartTyping = false;
    private float BGM_Volume;
    private bool OpeningSkip;

    private void Awake()
    {
        OpeningSkip = PlayerPrefsX.GetBool("SkipOpening", false);
        if (OpeningSkip)
        {
            LoadSceneManager.Load(LoadSceneManager.Scene.Title);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        TextMessage[0] = "\"할머니 손이 왜 이렇게 커요?\"";
        TextMessage[1] = "\"빨간망토 너를 더 많이 쓰다듬기 위해서란다.\"";
        TextMessage[2] = "\"할머니 눈이 왜 이렇게 커요?\"";
        TextMessage[3] = "\"빨간망토 너를 더 제대로 보기 위해서란다.\"";
        TextMessage[4] = "\"그럼 할머니...\"";
        TextMessage[5] = "\"입이 왜 이렇게 커요?\"";
        TextMessage[6] = "\"그건 말이다...\"";
        TextMessage[7] = "너를 잡아먹기 위해서란다.";

    }

    // Update is called once per frame
    void Update()
    {
        BGM_Volume = (float)PlayerPrefs.GetInt("BGM_Value", 50) / 100f;
        BGM.volume = BGM_Volume;

        ColorA += Time.deltaTime;
        if (MessageStac < 7)
        {
            Text.text = TextMessage[MessageStac];
            Text.color = new Vector4(1, 1, 1, Mathf.PingPong(ColorA * Speed, 255) / 255);
        }
        if (MessageStac == 7)
        {
            Text.color = new Vector4(147.0f / 255.0f, 0, 0, 1);
            if (!StartTyping)
            {
                Text.text = null;
                Text.DOText(TextMessage[7], TypingTime);
                StartCoroutine(ChangeScene());
                StartTyping = true;
            }
        }
        if (MessageStac > 7 || Input.GetMouseButton(0) || Input.anyKeyDown)
            LoadSceneManager.Load(LoadSceneManager.Scene.Title);
        if (ColorA > 510 / Speed && MessageStac < 7)
        {
            ColorA = 0;
            MessageStac++;
        }
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(TypingTime);
        MessageStac++;
        yield return 0;
    }
}
