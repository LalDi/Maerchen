using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton singleton = null;

    public bool IsGame = true;

    public PlayerScript Player;
    public DayAndNightScript DAN;
    public WolfScript Wolf;
    public HTScripts Clear;

    public GameObject PlayerObj;
    public GameObject DANObj;
    public GameObject WolfObj;
    public GameObject ClearObj;

    private void Awake()
    {
        if (singleton != null)
            Destroy(singleton);

        singleton = this;

        Player = PlayerObj.GetComponent<PlayerScript>();
        DAN = DANObj.GetComponent<DayAndNightScript>();
        Wolf = WolfObj.GetComponent<WolfScript>();
        Clear = ClearObj.GetComponent<HTScripts>();

        Application.targetFrameRate = 144;
    }
}
