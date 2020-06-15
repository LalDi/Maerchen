using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OptionScript : MonoBehaviour
{
    RectTransform RectTrans;
    
    [SerializeField] private float Speed;
    [SerializeField] private GameObject Buttons;
    [SerializeField] private GameObject Name;
    [SerializeField] private GameObject BlackScene;

    void Start()
    {
        RectTrans = GetComponent<RectTransform>();
    }


    public void ExitOption()
    {
        Buttons.SetActive(true);
        Name.SetActive(true);
        RectTrans.DOLocalMoveY(1150, Speed);
        BlackScene.SetActive(false);

        PlayerPrefs.Save();
    }

}
