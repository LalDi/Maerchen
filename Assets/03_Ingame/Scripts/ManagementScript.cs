using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementScript : MonoBehaviour
{
    [SerializeField] private GameObject Easy;
    [SerializeField] private GameObject Normal;
    [SerializeField] private GameObject Hard;

    private string CheckLevel;

    private int EasyClear;
    private int NormalClear;
    private int HardClear;

    private int EasyClearTemp;
    private int NormalClearTemp;
    private int HardClearTemp;

    private float BestClearTime;
    private float WorstClearTime;

    // Start is called before the first frame update
    void Awake()
    {
        CheckLevel = PlayerPrefs.GetString("CheckLevel");

        EasyClearTemp = PlayerPrefs.GetInt("E_Clear", 0);
        NormalClearTemp = PlayerPrefs.GetInt("N_Clear", 0);
        HardClearTemp = PlayerPrefs.GetInt("H_Clear", 0);

        BestClearTime = PlayerPrefs.GetFloat("S_ClearTime", 0);
        WorstClearTime = PlayerPrefs.GetFloat("L_ClearTime", 0);

        if (CheckLevel == "Easy")
        {
            Easy.SetActive(true);
            Normal.SetActive(false);
            Hard.SetActive(false);
        }

        if (CheckLevel == "Normal")
        {
            Easy.SetActive(false);
            Normal.SetActive(true);
            Hard.SetActive(false);
        }

        if (CheckLevel == "Hard")
        {
            Easy.SetActive(false);
            Normal.SetActive(false);
            Hard.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Singleton.singleton.Player.transform.position;
        if (Singleton.singleton.Clear.GameEndWaiting)
        {
            if (CheckLevel == "Easy")
            {
                EasyClear = EasyClearTemp + 1;
                PlayerPrefs.SetInt("E_Clear", EasyClear);
            }

            if (CheckLevel == "Normal")
            {
                NormalClear = NormalClearTemp + 1;
                PlayerPrefs.SetInt("N_Clear", NormalClear);
            }

            if (CheckLevel == "Hard")
            {
                HardClear = HardClearTemp + 1;
                PlayerPrefs.SetInt("H_Clear", HardClear);
            }

            if (Singleton.singleton.Player.PlayTime < BestClearTime || BestClearTime == 0)
            {
                BestClearTime = Singleton.singleton.Player.PlayTime;
                PlayerPrefs.SetFloat("S_ClearTime", BestClearTime);
                PlayerPrefs.SetString("S_ClearTime_Level", CheckLevel);
            }

            if (Singleton.singleton.Player.PlayTime > WorstClearTime)
            {
                WorstClearTime = Singleton.singleton.Player.PlayTime;
                PlayerPrefs.SetFloat("L_ClearTime", WorstClearTime);
                PlayerPrefs.SetString("L_ClearTime_Level", CheckLevel);
            }
        }
    }
}
