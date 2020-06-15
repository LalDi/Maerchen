using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonsOnPointerScripts : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Sprite[] ButtonsObj = new Sprite[2];
    public SpriteRenderer Buttons_Image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData data)
    {
        gameObject.GetComponent<Image>().sprite = ButtonsObj[1];
    }

    public void OnPointerExit(PointerEventData data)
    {
        gameObject.GetComponent<Image>().sprite = ButtonsObj[0];
    }

    public void OnPointerDown(PointerEventData data)
    {
        gameObject.GetComponent<Image>().sprite = ButtonsObj[0];
    }

}

