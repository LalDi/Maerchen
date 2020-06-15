using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public Button Easy;
    public Button Normal;
    public Button Hard;

    public GameObject OB_Easy_Level;
    public GameObject OB_Normal_Level;
    public GameObject OB_Hard_Level;

    public GameObject IT_Easy_Level;
    public GameObject IT_Normal_Level;
    public GameObject IT_Hard_Level;

    private int CountButton = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ClickRightKey();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ClickLeftKey();
        }
    }

    public void ClickRightKey()
    {
        if (CountButton == 0)
        {
            Easy.gameObject.SetActive(false);
            Normal.gameObject.SetActive(true);

            OB_Easy_Level.gameObject.SetActive(true);
            OB_Normal_Level.gameObject.SetActive(true);
            OB_Hard_Level.gameObject.SetActive(false);

            IT_Easy_Level.gameObject.SetActive(true);
            IT_Normal_Level.gameObject.SetActive(true);
            IT_Hard_Level.gameObject.SetActive(false);

            CountButton++;
        }
        else if (CountButton == 1)
        {
            Normal.gameObject.SetActive(false);
            Hard.gameObject.SetActive(true);

            OB_Easy_Level.gameObject.SetActive(true);
            OB_Normal_Level.gameObject.SetActive(true);
            OB_Hard_Level.gameObject.SetActive(true);

            IT_Easy_Level.gameObject.SetActive(true);
            IT_Normal_Level.gameObject.SetActive(false);
            IT_Hard_Level.gameObject.SetActive(false);

            CountButton++;
        }
        else
        {
            Hard.gameObject.SetActive(false);
            Easy.gameObject.SetActive(true);

            OB_Easy_Level.gameObject.SetActive(true);
            OB_Normal_Level.gameObject.SetActive(false);
            OB_Hard_Level.gameObject.SetActive(false);

            IT_Easy_Level.gameObject.SetActive(true);
            IT_Normal_Level.gameObject.SetActive(true);
            IT_Hard_Level.gameObject.SetActive(true);

            CountButton = 0;
        }
    }

    public void ClickLeftKey()
    {
        if (CountButton == 0)
        {
            Easy.gameObject.SetActive(false);
            Hard.gameObject.SetActive(true);

            OB_Easy_Level.gameObject.SetActive(true);
            OB_Normal_Level.gameObject.SetActive(true);
            OB_Hard_Level.gameObject.SetActive(true);

            IT_Easy_Level.gameObject.SetActive(true);
            IT_Normal_Level.gameObject.SetActive(false);
            IT_Hard_Level.gameObject.SetActive(false);

            CountButton = 2;
        }
        else if (CountButton == 1)
        {
            Normal.gameObject.SetActive(false);
            Easy.gameObject.SetActive(true);

            OB_Easy_Level.gameObject.SetActive(true);
            OB_Normal_Level.gameObject.SetActive(false);
            OB_Hard_Level.gameObject.SetActive(false);

            IT_Easy_Level.gameObject.SetActive(true);
            IT_Normal_Level.gameObject.SetActive(true);
            IT_Hard_Level.gameObject.SetActive(true);

            CountButton--;
        }
        else
        {
            Hard.gameObject.SetActive(false);
            Normal.gameObject.SetActive(true);

            OB_Easy_Level.gameObject.SetActive(true);
            OB_Normal_Level.gameObject.SetActive(true);
            OB_Hard_Level.gameObject.SetActive(false);

            IT_Easy_Level.gameObject.SetActive(true);
            IT_Normal_Level.gameObject.SetActive(true);
            IT_Hard_Level.gameObject.SetActive(false);

            CountButton--;
        }
    }

    public void ClickEasyButton()
    {
        PlayerPrefs.SetString("CheckLevel", "Easy");
        //SceneManager.LoadScene("Ingame");
        LoadSceneManager.Load(LoadSceneManager.Scene.Ingame);
    }

    public void ClickNormalButton()
    {
        PlayerPrefs.SetString("CheckLevel", "Normal");
        //SceneManager.LoadScene("Ingame");
        LoadSceneManager.Load(LoadSceneManager.Scene.Ingame);
    }

    public void ClickHardButton()
    {
        PlayerPrefs.SetString("CheckLevel", "Hard");
        //SceneManager.LoadScene("Ingame");
        LoadSceneManager.Load(LoadSceneManager.Scene.Ingame);
    }

    public void ExitStartScnen()
    {
        //SceneManager.LoadScene("Title");
        LoadSceneManager.Load(LoadSceneManager.Scene.Title);
    }
}
