using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonScript : MonoBehaviour
{
    //public Sprite[] ButtonsObj = new Sprite[1];
    //public SpriteRenderer Buttons_Image;

    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject Name;
    [SerializeField] private float Speed;

    public Button StartButton;
    public Button OptionButton;
    public Button RecordButton;
    public Button ExitButton;

    public Text CheckExitButton;

    public Image OptionWin;
    public Image RecordWin;

    public GameObject Title;
    public GameObject BlackScene;

    public void ClickStartButton()
    { 
        //gameObject.GetComponent<Image>().sprite = ButtonsObj[0];

        //SceneManager.LoadScene("SelectLevel");
        LoadSceneManager.Load(LoadSceneManager.Scene.SelectLevel);
    }

    public void ClickOptionButton()
    {
        //gameObject.GetComponent<Image>().sprite = ButtonsObj[0];

        OptionWin.gameObject.SetActive(true);
        OptionWin.rectTransform.DOLocalMoveY(0, Speed);
        Button.SetActive(false);
        Name.SetActive(false);
        BlackScene.SetActive(true);
    }

    public void ClickRecordButton()
    {
        //gameObject.GetComponent<Image>().sprite = ButtonsObj[0];

        RecordWin.gameObject.SetActive(true);
        RecordWin.rectTransform.DOLocalMoveY(0, Speed);
        Button.SetActive(false);
        Name.SetActive(false);
        BlackScene.SetActive(true);
    }

    public void ClickExitButton()
    {
        //gameObject.GetComponent<Image>().sprite = ButtonsObj[0];

        CheckExitButton.gameObject.SetActive(true);

        StartButton.gameObject.SetActive(false);
        OptionButton.gameObject.SetActive(false);
        RecordButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        BlackScene.gameObject.SetActive(true);
    }

    public void CheckExitYes()
    {
        Application.Quit();
    }

    public void CheckExitNo()
    {
        CheckExitButton.gameObject.SetActive(false);

        StartButton.gameObject.SetActive(true);
        OptionButton.gameObject.SetActive(true);
        RecordButton.gameObject.SetActive(true);
        ExitButton.gameObject.SetActive(true);
        Title.gameObject.SetActive(true);
        BlackScene.gameObject.SetActive(false);
    }

}
