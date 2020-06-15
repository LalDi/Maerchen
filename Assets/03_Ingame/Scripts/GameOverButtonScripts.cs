using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverButtonScripts : MonoBehaviour
{
    string Level;
    // Start is called before the first frame update
    void Start()
    {
        Level = PlayerPrefs.GetString("CheckLevel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReStart()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        //SceneManager.LoadScene("Ingame");
        LoadSceneManager.Load(LoadSceneManager.Scene.Ingame);
    }

    public void Exit()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        //SceneManager.LoadScene("Title");
        LoadSceneManager.Load(LoadSceneManager.Scene.Title);
    }
}
