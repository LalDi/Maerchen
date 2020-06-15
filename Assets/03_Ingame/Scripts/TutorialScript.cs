using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    private bool CheckFirstTry;

    [SerializeField] private GameObject BlackScene;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject UI_DashGaugue;
    [SerializeField] private GameObject UI_TimerFrame;
    [SerializeField] private GameObject UI_MapGaugue;
    [SerializeField] private GameObject NextButton;

    private GameObject[] Tutorial = new GameObject[10];
    private int TutorialStack = 0;

    // Start is called before the first frame update
    void Start()
    {
        CheckFirstTry = PlayerPrefsX.GetBool("FirstTry", true);
        //CheckFirstTry = true;
        Tutorial[0] = transform.Find("Tutorial (1)").gameObject;
        Tutorial[1] = transform.Find("Tutorial (2)").gameObject;
        Tutorial[2] = transform.Find("Tutorial (2-1)").gameObject;
        Tutorial[3] = transform.Find("Tutorial (3)").gameObject;
        Tutorial[4] = transform.Find("Tutorial (4)").gameObject;
        Tutorial[5] = transform.Find("Tutorial (5)").gameObject;
        Tutorial[6] = transform.Find("Tutorial (6)").gameObject;
        Tutorial[7] = transform.Find("Tutorial (7)").gameObject;
        Tutorial[8] = transform.Find("Tutorial (8)").gameObject;
        Tutorial[9] = transform.Find("Tutorial (9)").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckFirstTry && TutorialStack < 10)
        {
            Time.timeScale = 0;
            BlackScene.SetActive(true);
            //NextButton.SetActive(true);
            Pause.SetActive(false);
            UI_DashGaugue.SetActive(false);
            UI_TimerFrame.SetActive(false);
            UI_MapGaugue.SetActive(false);

            Tutorial[TutorialStack].SetActive(true);
        }
        else gameObject.SetActive(false);
        if (Input.anyKeyDown && CheckFirstTry)
        {
            NextTutorial();
        }
    }

    public void NextTutorial()
    {
        Tutorial[TutorialStack].SetActive(false);
        TutorialStack++;
        if (TutorialStack == 10)
        {
            Time.timeScale = 1;
            CheckFirstTry = false;
            PlayerPrefsX.SetBool("FirstTry", CheckFirstTry);

            BlackScene.SetActive(false);
            Pause.SetActive(true);
            UI_DashGaugue.SetActive(true);
            UI_TimerFrame.SetActive(true);
            UI_MapGaugue.SetActive(true);
            NextButton.SetActive(false);

            gameObject.SetActive(false);
        }
    }
}
