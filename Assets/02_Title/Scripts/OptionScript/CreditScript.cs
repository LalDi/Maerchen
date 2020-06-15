using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CreditScript : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    [SerializeField] private float DuringTime;

    private void Start()
    {
        if (Text != null)
        {
            Text.transform.DOLocalMoveY(3000, DuringTime);
        }
    }

    public void ClickCredit()
    {
        //SceneManager.LoadScene("Credit");
        LoadSceneManager.Load(LoadSceneManager.Scene.Credit);
    }

    public void ClickExit()
    {
        //SceneManager.LoadScene("Title");
        LoadSceneManager.Load(LoadSceneManager.Scene.Title);
    }
}
