using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNightScript : MonoBehaviour
{
    public float Delay;
    public bool DAN = true;
    public bool IsTreeGo = false;

    public GameObject Grid_Day;
    public GameObject Grid_Night;
    
    public GameObject Platform_Day;
    public GameObject Platform_Night;
    
    public GameObject Platform_Day_Easy;
    public GameObject Platform_Night_Easy;
    
    public GameObject Platform_Day_Normal;
    public GameObject Platform_Night_Normal;
    
    public GameObject Platform_Day_Hard;
    public GameObject Platform_Night_Hard;
    
    public GameObject NightLantern;

    float Timer = 0;
    string Level;

    void Awake()
    {
        Level = PlayerPrefs.GetString("CheckLevel");
    }

    void Start()
    {
        if (Level == "Easy")
        {
            Platform_Day = Platform_Day_Easy;
            Platform_Night = Platform_Night_Easy;
        }
        else if (Level == "Normal")
        {
            Platform_Day = Platform_Day_Normal;
            Platform_Night = Platform_Night_Normal;

        }
        else if (Level == "Hard")
        {
            Platform_Day = Platform_Day_Hard;
            Platform_Night = Platform_Night_Hard;

        }

        Grid_Day.transform.position = new Vector3(0, 0, 0);
        //Grid_Day.SetActive(true);
        Grid_Night.transform.position = new Vector3(0, -8, 0);
        //Grid_Night.SetActive(false);
        Platform_Day.SetActive(true);
        Platform_Night.SetActive(false);
        NightLantern.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= Delay - 0.3f && !IsTreeGo)
            IsTreeGo = true;
        if (Timer >= Delay)
        {
            if (DAN)
            {
                DAN = false;
                GameObject.Find("SoundsManager").GetComponent<IGSoundManagerScripts>().SoundManage("SoundWolfHawling");

                Grid_Day.transform.position = new Vector3(0, -8, 0);
                //Grid_Day.SetActive(false);
                Grid_Night.transform.position = new Vector3(0, 0, 0);
                //Grid_Night.SetActive(true);
                Platform_Day.SetActive(false);
                Platform_Night.SetActive(true);
                NightLantern.SetActive(true);
            }
            else
            {
                DAN = true;

                Grid_Day.transform.position = new Vector3(0, 0, 0);
                //Grid_Day.SetActive(true);
                Grid_Night.transform.position = new Vector3(0, -8, 0);
                //Grid_Night.SetActive(false);
                Platform_Day.SetActive(true);
                Platform_Night.SetActive(false);
                NightLantern.SetActive(false);
            }
            Timer = 0;
        }
        //if (DAN)
        //{
            
        //}
        //else
        //{
        //    Grid_Day.transform.position = new Vector3(0, -8, 0);
        //    //Grid_Day.SetActive(false);
        //    Grid_Night.transform.position = new Vector3(0, 0, 0);
        //    //Grid_Night.SetActive(true);
        //    Platform_Day.SetActive(false);
        //    Platform_Night.SetActive(true);
        //    NightLantern.SetActive(true);
        //}

    }
}
