using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RecordScript : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private GameObject Buttons;
    [SerializeField] private GameObject Name;
    [SerializeField] private GameObject BlackScene;


    [SerializeField] private Text PlayTime;

    [SerializeField] private Text Shortest_ClearTime;
    [SerializeField] private Text Longest_ClearTime;

    [SerializeField] private Text EasyClear;
    [SerializeField] private Text NormalClear;
    [SerializeField] private Text HardClear;

    RectTransform RectTrans;

    private float PlayTime_Value;
    private float Shortest_ClearTime_Value;
    private float Longest_ClearTime_Value;
    private int EasyClear_Value;
    private int NormalClear_Value;
    private int HardClear_Value;

    private int PlayTime_Hou;
    private int PlayTime_Min;
    private float PlayTime_Sec;

    private int Shortest_ClearTime_Min;
    private float Shortest_ClearTime_Sec;
    private string Shortest_ClearTime_Level;

    private int Longest_ClearTime_Min;
    private float Longest_ClearTime_Sec;
    private string Longest_ClearTime_Level;

    void Start()
    {
        //Buttons.SetActive(false);
        RectTrans = GetComponent<RectTransform>();
        Shortest_ClearTime_Value = PlayerPrefs.GetFloat("S_ClearTime");
        Shortest_ClearTime_Level = PlayerPrefs.GetString("S_ClearTime_Level", "없음");
        Longest_ClearTime_Value = PlayerPrefs.GetFloat("L_ClearTime");
        Longest_ClearTime_Level = PlayerPrefs.GetString("L_ClearTime_Level", "없음");
        EasyClear_Value = PlayerPrefs.GetInt("E_Clear", 0);
        NormalClear_Value = PlayerPrefs.GetInt("N_Clear", 0);
        HardClear_Value = PlayerPrefs.GetInt("H_Clear", 0);
    }

    void Update()
    {
        PlayTime_Value = PlayerPrefs.GetFloat("PlayTime");

        PlayTime_Hou = (int)PlayTime_Value / 3600;
        PlayTime_Min = ((int)PlayTime_Value % 3600) / 60;
        PlayTime_Sec = (PlayTime_Value % 3600f) % 60f;

        Shortest_ClearTime_Min = (int)Shortest_ClearTime_Value / 60;
        Shortest_ClearTime_Sec = Shortest_ClearTime_Value % 60f;

        Longest_ClearTime_Min = (int)Longest_ClearTime_Value / 60;
        Longest_ClearTime_Sec = Longest_ClearTime_Value % 60f;
    }

    public void ExitRecord()
    {
        Buttons.SetActive(true);
        Name.SetActive(true);
        BlackScene.SetActive(false);
        RectTrans.DOLocalMoveY(1100, Speed);
    }

    public void ClickRecord()
    {
        PlayTime.text = PlayTime_Hou.ToString("D2") + " : " + PlayTime_Min.ToString("D2") + " : " + PlayTime_Sec.ToString("00.00");
        Shortest_ClearTime.text = Shortest_ClearTime_Min.ToString("D2") + " : " + Shortest_ClearTime_Sec.ToString("00.00") + " (" + Shortest_ClearTime_Level + ")";
        Longest_ClearTime.text = Longest_ClearTime_Min.ToString("D2") + " : " + Longest_ClearTime_Sec.ToString("00.00") + " (" + Longest_ClearTime_Level + ")";
        EasyClear.text = EasyClear_Value.ToString() + "회";
        NormalClear.text = NormalClear_Value.ToString() + "회";
        HardClear.text = HardClear_Value.ToString() + "회";
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        Shortest_ClearTime_Value = PlayerPrefs.GetFloat("S_ClearTime");
        Longest_ClearTime_Value = PlayerPrefs.GetFloat("L_ClearTime");
        EasyClear_Value = PlayerPrefs.GetInt("E_Clear", 0);
        NormalClear_Value = PlayerPrefs.GetInt("N_Clear", 0);
        HardClear_Value = PlayerPrefs.GetInt("H_Clear", 0);
    }
}
