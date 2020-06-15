using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTimeScript : MonoBehaviour
{
    private float Timer;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Timer = PlayerPrefs.GetFloat("PlayTime", 0);
    }

    void FixedUpdate()
    {
        Timer += Time.deltaTime;
        PlayerPrefs.SetFloat("PlayTime", Timer);
        //print(Timer);
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        Timer = 0;
    }
}
