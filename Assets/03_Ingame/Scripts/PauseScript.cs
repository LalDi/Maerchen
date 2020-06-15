using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    [SerializeField] private GameObject PauseScene;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject PauseOption;

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            PauseScene.SetActive(true);
            UI.SetActive(false);
            PauseOption.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            PauseScene.SetActive(false);
            UI.SetActive(true);
            PauseOption.SetActive(false);
        }
    }
}
