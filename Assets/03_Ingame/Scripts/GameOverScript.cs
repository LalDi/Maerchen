using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private Text PlayTimeText;
    [SerializeField] private Text BestScoreText;

    [SerializeField] private GameObject GameFail;
    [SerializeField] private GameObject GameClear;

    [SerializeField] private GameObject NightLantern;
    [SerializeField] private GameObject DeadScene;

    private int TimeM = 0;
    private float TimeS = 0;

    private int BestTimeM = 0;
    private float BestTimeS = 0;

    //[SerializeField] private string 

    // Start is called before the first frame update
    void Start()
    {
        BestTimeM = (int)PlayerPrefs.GetFloat("S_ClearTime") / 60;
        BestTimeS = PlayerPrefs.GetFloat("S_ClearTime") % 60f;

        NightLantern.SetActive(false);
        DeadScene.SetActive(true);

        if (Singleton.singleton.Wolf.Gameover) {
            GameFail.SetActive(true);
            GameClear.SetActive(false);
        }
        else if(Singleton.singleton.Player.GameClear){
            GameFail.SetActive(false);
            GameClear.SetActive(true);
        }

        TimeS = Singleton.singleton.Player.PlayTime;
        if (TimeS >= 60)
        {
            TimeM = ((int)TimeS / 60);
            TimeS = (TimeS % 60);
        }

        PlayTimeText.text = TimeM.ToString("D2") + " : " + TimeS.ToString("00.00");
        BestScoreText.text = BestTimeM.ToString("D2") + " : " + BestTimeS.ToString("00.00");
    }

}
